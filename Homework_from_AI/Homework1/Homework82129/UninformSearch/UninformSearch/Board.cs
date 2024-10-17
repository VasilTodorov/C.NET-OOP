using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UninformSearch
{
    public class Board
    {
        #region Datamembers

        public int[,] BoardValue { get; init; }
        public (int, int) WantedZeroPoint { get; private set; }
        public (int, int) CurrentZeroPoint { get; private set; }
        public int Distance { get; private set; }
        public enum Direction
        {
            LEFT, UP, RIGHT, DOWN, NO_DIRECTION
        }
        public Direction ComesFrom { get; private set; }

        public int Manhaten { get; private set; }

        public int Position { get; private set; }
        #endregion

        #region Constructors
        public Board(int[,] value, int position = -1, int distance = 0, Direction comesFrom = Direction.NO_DIRECTION)
        {
            BoardValue = new int[value.GetLength(0), value.GetLength(1)];
            Array.Copy(value, BoardValue, BoardValue.Length);

            if (position != -1)
                WantedZeroPoint = (position / BoardValue.GetLength(0), position % BoardValue.GetLength(0));
            else
                WantedZeroPoint = (BoardValue.GetLength(0) - 1, BoardValue.GetLength(0) - 1);

            CurrentZeroPoint = FindPositonOf(0);

            Distance = distance;
            ComesFrom = comesFrom;
            Position = position;
            Manhaten = -1;
        }
        #endregion

        #region Methods
        #region MethodsEstimatedPath

        public int FScore()
        {
            return CalculateManhaten() + Distance;
        }
        public bool IsGoal()
        {
            return CalculateManhaten() == 0;
        }
        public int CalculateManhaten()
        {
            if (Manhaten >= 0) return Manhaten;
            int sum = 0;
            for (int i = 0; i < BoardValue.Length; i++)
            {
                sum += CalculateSingle(i);
            }
            Manhaten = sum;
            return sum;
        }
        public int CalculateSingle(int indexWantedPoint)
        {
            //chek validity
            if (indexWantedPoint == 0) return 0;

            //declaration of variables;
            int indexZero;
            (int, int) positionWantedPoint;
            (int, int) positionPoint;

            //init
            indexZero = WantedZeroPoint.Item1 * BoardValue.GetLength(0) +
                        WantedZeroPoint.Item2;

            positionPoint = FindPositonOf(indexWantedPoint);

            if (indexWantedPoint <= indexZero) indexWantedPoint--;
            positionWantedPoint = (indexWantedPoint / BoardValue.GetLength(0),
                                    indexWantedPoint % BoardValue.GetLength(0));
            //process
            return Math.Abs(positionPoint.Item1 - positionWantedPoint.Item1) +
                    Math.Abs(positionPoint.Item2 - positionWantedPoint.Item2);
        }
        #endregion

        #region MethodsSolvable
        public bool IsSolvable()
        {
            if (BoardValue.GetLength(0) % 2 == 1)
            {
                return CalculateInversions() % 2 == 0;
            }
            else
            {
                return (CalculateInversions() + CurrentZeroPoint.Item1) % 2 == 1;
            }
        }
        public int CalculateInversions()
        {
            //variables
            int valueLeft;
            int valueRight;
            int count;

            //process
            count = 0;
            for (int i = 0; i < BoardValue.Length; i++)
            {
                valueLeft = BoardValue[i / BoardValue.GetLength(0),
                                       i % BoardValue.GetLength(0)];
                if (valueLeft == 0) continue;
                for (int j = i + 1; j < BoardValue.Length; j++)
                {
                    valueRight = BoardValue[j / BoardValue.GetLength(0),
                                            j % BoardValue.GetLength(0)];
                    if (valueRight == 0) continue;
                    if (valueLeft > valueRight) count++;
                }
            }

            return count;
        }

        #endregion

        #region MethodsGeneral

        public IEnumerable<Board> Successors()
        {
            List<Board> result = new List<Board>();
            int[,] newBoard = new int[BoardValue.GetLength(0),
                                          BoardValue.GetLength(1)]; ;
            Array.Copy(BoardValue, newBoard, BoardValue.Length);

            //Up
            if ((CurrentZeroPoint.Item1 + 1) < BoardValue.GetLength(0))
            {
                SwapDirection(newBoard, Direction.UP);

                //result.Add();
                
                result.Add(CreateSuccessorBoard(newBoard, Direction.UP));
                //result.Last().CalculateSingle
                SwapDirection(newBoard, Direction.UP);

            }
            //DOWN
            if ((CurrentZeroPoint.Item1 - 1) >= 0)
            {
                SwapDirection(newBoard, Direction.DOWN);
                
                result.Add(CreateSuccessorBoard(newBoard, Direction.DOWN)); 
                SwapDirection(newBoard, Direction.DOWN);
            }


            //Left
            if ((CurrentZeroPoint.Item2 + 1) < BoardValue.GetLength(0))
            {
                SwapDirection(newBoard, Direction.LEFT);
                
                result.Add(CreateSuccessorBoard(newBoard,Direction.LEFT));
                SwapDirection(newBoard, Direction.LEFT);
            }

            //Right
            if ((CurrentZeroPoint.Item2 - 1) >= 0)
            {
                SwapDirection(newBoard, Direction.RIGHT);                

                result.Add(CreateSuccessorBoard(newBoard, Direction.RIGHT));
                SwapDirection(newBoard, Direction.RIGHT);
            }

            return result.OrderBy(x => x.FScore());
        }

        private Board CreateSuccessorBoard(int[,] newBoard, Direction direction)
        {
            var board = new Board(newBoard,
                   WantedZeroPoint.Item1 * BoardValue.GetLength(0) + WantedZeroPoint.Item2,
                   Distance + 1,
                   direction);
            var a = board.CalculateSingle(board.BoardValue[this.CurrentZeroPoint.Item1, this.CurrentZeroPoint.Item2]);
            var b = this.CalculateSingle(this.BoardValue[board.CurrentZeroPoint.Item1, board.CurrentZeroPoint.Item2]);
            board.Manhaten = this.Manhaten;
            board.Manhaten += a - b;

            return board;
        }

        private void SwapDirection(int[,] board, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    Swap(ref board[CurrentZeroPoint.Item1, CurrentZeroPoint.Item2],
                    ref board[CurrentZeroPoint.Item1 + 1, CurrentZeroPoint.Item2]);
                    break;
                case Direction.DOWN:
                    Swap(ref board[CurrentZeroPoint.Item1, CurrentZeroPoint.Item2],
                    ref board[CurrentZeroPoint.Item1 - 1, CurrentZeroPoint.Item2]);
                    break;
                case Direction.LEFT:
                    Swap(ref board[CurrentZeroPoint.Item1, CurrentZeroPoint.Item2],
                    ref board[CurrentZeroPoint.Item1, CurrentZeroPoint.Item2 + 1]);
                    break;
                case Direction.RIGHT:
                    Swap(ref board[CurrentZeroPoint.Item1, CurrentZeroPoint.Item2],
                    ref board[CurrentZeroPoint.Item1, CurrentZeroPoint.Item2 - 1]);
                    break;
                case Direction.NO_DIRECTION:
                    break;
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        private (int, int) FindPositonOf(int number)
        {
            for (int i = 0; i < BoardValue.GetLength(0); i++)
            {
                for (int j = 0; j < BoardValue.GetLength(1); j++)
                {
                    if (BoardValue[i, j] == number)
                    {
                        return (i, j);
                    }
                }

            }

            return (-1, -1);
        }
        public override string ToString()
        {
            string str = "";
            str +=   (Position) + "\n";
            for (int i = 0; i < BoardValue.GetLength(0); i++)
            {
                for (int j = 0; j < BoardValue.GetLength(1); j++)
                {
                    str += BoardValue[i, j].ToString() + " ";
                }

                str += "\n";
            }
            return str;
        }

        public override bool Equals(object? other)
        {
            if (other == null && this != null) return false;
            if (other == null && this == null) return true;

            if (BoardValue.Length != ((Board)other!).BoardValue.Length) return false;
            for (int i = 0; i < BoardValue.GetLength(0); i++)
            {
                for (int j = 0; j < BoardValue.GetLength(1); j++)
                {
                    if (BoardValue[i, j] != ((Board)other!).BoardValue[i, j])
                    {
                        return false;
                    }
                }

            }

            return true;
        }



        #endregion

        #region MethodsAlgorithm
        public string Ida_Start()
        {
            //variables
            int bound;          //treshold
            Stack<Board> path = new Stack<Board>();  //path of boards

            //init
            bound = CalculateManhaten();
            path.Push(this);
            //Console.WriteLine(path.First().ToString() + "Dis: "+ path.First().Distance);


            if (!IsSolvable()) return "-1";
            while (true)
            {
                int t = Search(path, bound);
                if (t == -1) return path.First().Distance + "\n" + GetDirections(path);
                if (t == -2) return "NOT_FOUND";
                bound = t;
            }
        }

        private int Search(Stack<Board> path, int bound)
        {
            Board node = path.First();
            node.Equals(this);

            if (node.FScore() > bound) return node.FScore();
            if (node.IsGoal()) return -1;
            var min = double.PositiveInfinity;

            foreach (var succ in node.Successors())
            {
                if (!path.Contains(succ))
                {
                    path.Push(succ);
                    //Console.WriteLine(path.First().ToString() + "Dis: " +path.First().Distance);
                    int t = Search(path, bound);
                    if (t == -1) return -1;
                    if (t < min && t != -2) min = t;
                    path.Pop();
                }
            }
            if (min == double.PositiveInfinity) 
                return -2;
            return (int)min;
        }

        private string GetDirections(Stack<Board> path)
        {
            var memoryArray = path.Reverse().ToArray();
            string memoryDirection = "";
            string direction;
            for (int i = 1; i < memoryArray.Length; i++)
            {
                direction = memoryArray[i].ComesFrom switch
                {
                    Direction.RIGHT => "right",
                    Direction.LEFT => "left",
                    Direction.UP => "up",
                    Direction.DOWN => "down",
                    Direction.NO_DIRECTION => "start",
                    _ => "end"
                };

                memoryDirection += direction + "\n";
            }

            return memoryDirection;
        } 
        #endregion
        #endregion
    }


}
