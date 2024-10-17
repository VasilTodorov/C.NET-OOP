using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstrainSatisfaction
{
    public class Queens
    {
        #region Fields
        private readonly int SIZE;
        private const double REPEAT = 0.5;

        private int[] nQueens;
        private int[] queensPerRow;
        private int[] queensPerD1;
        private int[] queensPerD2;
        #endregion

        #region Properties
        public int[] N_Queens
        {
            get { return nQueens; }
            private set
            {
                if (value != null)
                {
                    nQueens = new int[value.Length];
                    for (int i = 0; i < nQueens.Length; i++)
                    {
                        if (value[i] < nQueens.Length && value[i] > 0)
                        {
                            nQueens[i] = value[i];
                        }
                        else
                        {
                            nQueens[i] = 0;

                        }
                    }
                }
            }
        }
        private int[] QueensPerRow
        {
            get { return queensPerRow; }
            set
            {
                if (value != null)
                {
                    queensPerRow = new int[value.Length];
                    for (int i = 0; i < queensPerRow.Length; i++)
                    {
                        queensPerRow[i] = 0;
                    }
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] >= 0 && value[i] < queensPerRow.Length)
                            queensPerRow[value[i]]++;
                    }
                }
                else
                {
                    queensPerRow = new int[SIZE];
                    for (int i = 0; i < queensPerRow.Length; i++)
                    {
                        queensPerRow[i] = 0;
                    }
                }
            }

        }
        private int[] QueensPerD1
        {
            get { return queensPerD1; }
            set
            {
                if (value != null)
                {
                    queensPerD1 = new int[value.Length * 2 - 1];
                    for (int i = 0; i < queensPerD1.Length; i++)
                    {
                        queensPerD1[i] = 0;
                    }
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (i - value[i] > -value.Length && i - value[i] < value.Length)
                            queensPerD1[i - value[i] + value.Length - 1]++;
                    }
                }
                else
                {
                    queensPerD1 = new int[SIZE * 2 - 1];
                    for (int i = 0; i < queensPerD1.Length; i++)
                    {
                        queensPerD1[i] = 0;
                    }
                }
            }
        }
        private int[] QueensPerD2
        {
            get { return queensPerD2; }
            set
            {
                if (value != null)
                {
                    queensPerD2 = new int[value.Length * 2 - 1];
                    for (int i = 0; i < queensPerD2.Length; i++)
                    {
                        queensPerD2[i] = 0;
                    }
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (i + value[i] >= 0 && i + value[i] < queensPerD2.Length)
                            queensPerD2[i + value[i]]++;
                    }
                }
                else
                {
                    queensPerD2 = new int[SIZE * 2 - 1];
                    for (int i = 0; i < queensPerD2.Length; i++)
                    {
                        queensPerD2[i] = 0;
                    }
                }
            }
        }
        #endregion

        #region Constructor

        public Queens(int size)
        {
            if (size > 0) SIZE = size;
            else SIZE = 8;

            int[] data = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
                data[i] = i;

            N_Queens = data.OrderBy(n => Guid.NewGuid()).ToArray();
            QueensPerRow = N_Queens;
            QueensPerD1 = N_Queens;
            QueensPerD2 = N_Queens;
        }

        #endregion

        #region Methods
        public void Restart()
        {
            int[] data = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
                data[i] = i;

            N_Queens = data.OrderBy(n => Guid.NewGuid()).ToArray();
            QueensPerRow = N_Queens;
            QueensPerD1 = N_Queens;
            QueensPerD2 = N_Queens;
        }
        public void Solve()
        {
            //variables
            int iter = 0;
            int col;
            int row;

            //proccess
            if (SIZE == 2 || SIZE == 3) return;
            while (iter++ < REPEAT * SIZE)
            {
                // Randomly if two or more!
                col = GetColWithQueenWithMaxConf();
                // Randomly if two or more!
                row = GetRowWithMinConflictInCol(col);

                Exchange(col, row);
            }

            if (HasConflict())
            {
                // Restart
                Restart();
                Solve();
            }


        }
        public bool HasConflict()
        {
            int maxColConf = GetColWithQueenWithMaxConf();
            return GetQeenConfInCol(maxColConf) > 0;
        }
        public int GetRowWithMinConflictInCol(int col)
        {
            if ((col < 0) || (col >= SIZE)) return -1;
            //datamembers
            int rowOfQueen;             //queen in col
            int min;                    //min conflic in col
            int rowConf;                //conflic in row

            List<int> minList = new List<int>();    //list of min Queens in colums
            int[] minArray;                         //array of result of list of min Queens

            //init
            rowOfQueen = N_Queens[col];
            min = SIZE;                 //maximum conflic

            //process
            for (int row = 0; row < SIZE; row++)
            {
                rowConf = GetConfInCord(col, row);
                if (row == rowOfQueen)
                    rowConf -= 3;                   //substracting queen in row, D1, D2

                if (rowConf < min)
                {
                    min = rowConf;
                    minList.Clear();
                    minList.Add(row);
                }
                else if (rowConf == min)
                    minList.Add(row);
            }

            //randomize
            minArray = minList.ToArray();
            Random random = new Random();

            return minArray[random.Next(0, minArray.Length)];

        }
        public int GetColWithQueenWithMaxConf()
        {
            //data memebers
            List<int> maxList = new List<int>();    //list of max Queens in colums
            int[] maxArray;

            int max = 0;                     //curren max conflict
            int colConf = 0;                        //conflic in colum

            //capacity
            maxList.Capacity = SIZE;

            //proccess
            for (int col = 0; col < SIZE; col++)
            {
                colConf = GetQeenConfInCol(col);
                if (colConf > max)
                {
                    maxList.Clear();
                    max = colConf;
                    maxList.Add(col);
                }
                else if (colConf == max)
                    maxList.Add(col);
            }

            //randomaze
            maxArray = maxList.ToArray();
            Random random = new Random();
            return maxArray[random.Next(0, maxArray.Length)];

        }
        public int GetQeenConfInCol(int col)
        {
            if ((col < 0) || (col >= SIZE)) return -1;

            int count = 0;  //counter of conflict

            int row = N_Queens[col];

            //except queen in col by row, D1, D2

            count += QueensPerRow[row] - 1;                 //get other queens in row

            count += QueensPerD1[GetD1ByCord(col, row)] - 1;              //get other queens in D1

            count += QueensPerD2[GetD2ByCord(col, row)] - 1;              //get other queens in D2

            return count;

        }
        public int GetConfInCord(int col, int row)
        {
            if ((col < 0) || (col >= SIZE) ||
                (row < 0) || (row >= SIZE)) return -1;

            int count = 0;  //counter of conflict            

            count += QueensPerRow[row];                 //get other queens in row

            count += QueensPerD1[GetD1ByCord(col, row)];              //get other queens in D1

            count += QueensPerD2[GetD2ByCord(col, row)];              //get other queens in D2

            return count;
        }

        private void Exchange(int colQueen, int rowDes)
        {
            if ((colQueen < 0) || (colQueen > SIZE) ||
                (rowDes < 0) || (rowDes > SIZE)) return;

            //init
            int rowQueen = N_Queens[colQueen];
            int d1 = GetD1ByCord(colQueen, rowQueen);
            int d2 = GetD2ByCord(colQueen, rowQueen);

            int d1Des = GetD1ByCord(colQueen, rowDes);
            int d2Des = GetD2ByCord(colQueen, rowDes);

            //process
            N_Queens[colQueen] = rowDes;

            //rows
            QueensPerRow[rowQueen]--;
            QueensPerRow[rowDes]++;

            //d1 and d2

            QueensPerD1[d1]--;
            QueensPerD2[d2]--;

            QueensPerD1[d1Des]++;
            QueensPerD2[d2Des]++;
        }
        private int GetD1ByCord(int col, int row)
        {
            return col - row + SIZE - 1;
        }
        private int GetD2ByCord(int col, int row)
        {
            return col + row;
        }
        public string ToStringSpecial()
        {
            string str = "Queens initial configuration\n";
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (N_Queens[j] == i)
                        str += "*";
                    else str += "_";
                }
                str += "\n";
            }
            str += "Queens per row\n";
            for (int i = 0; i < SIZE; i++)
            {
                str += $"Queens in row[{i}]: " + QueensPerRow[i].ToString() + "\n";
            }
            str += "Queens per D1\n";
            for (int i = 0; i < SIZE * 2 - 1; i++)
            {
                str += $"Queens in D1[{i}]: " + QueensPerD1[i].ToString() + "\n";
            }
            str += "Queens per D2\n";
            for (int i = 0; i < SIZE * 2 - 1; i++)
            {
                str += $"Queens in D2[{i}]: " + QueensPerD2[i].ToString() + "\n";
            }
            return str;
        }

        public override string ToString()
        {
            if (SIZE == 2 || SIZE == 3) return "-1";
            string str;
            str = "[";

            for(int i = 0;i < SIZE-1; i++)
            {
                str += N_Queens[i].ToString()+", ";
            }

            str += N_Queens[SIZE - 1].ToString() + "]";

            return str;
        }
        #endregion
    }
}
