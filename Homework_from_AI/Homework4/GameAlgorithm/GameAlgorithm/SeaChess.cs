using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static GameAlgorithm.SeaChess;

namespace GameAlgorithm
{
    public class SeaChess
    {
        #region Data members
        private const int MAX_DEPTH = 10;

        private MARK[,]? chess;
        private Player currentPlayer;
        private int depth;
        public enum MARK { X = 1, O = 0, EMPTY = 100 };
        public enum Player { COMPUTER, HUMAN, NO_PLAYER}
        #endregion
        #region Constructors
        public SeaChess(Player firstPlayer, MARK[,]? chess, int depth)
        {
            Chess = chess!;
            currentPlayer = firstPlayer;
            this.depth = depth;
        }

        public SeaChess(Player firstPlayer) : this(firstPlayer, null, 0) { }

        public SeaChess() : this(Player.COMPUTER, null, 0) { }

        public SeaChess(SeaChess s) : this(s.currentPlayer, s.chess, s.depth) { }

        #endregion
        #region Properties
        public MARK[,] Chess
        {
            get
            {
                var chessTemp = new MARK[3, 3];
                for (int i = 0; i < chess!.GetLength(0); i++)
                {
                    for (int j = 0; j < chess.GetLength(1); j++)
                        chessTemp[i, j] = chess[i, j];
                }
                return chessTemp;
            }
            private set
            {
                chess = new MARK[3, 3];
                if (value != null && value.GetLength(0) == 3 && value.GetLength(1) == 3)
                {
                    for (int i = 0; i < chess.GetLength(0); i++)
                    {
                        for (int j = 0; j < chess.GetLength(1); j++)
                            chess[i, j] = value[i, j];
                    }
                }
                else
                {
                    for (int i = 0; i < chess.GetLength(0); i++)
                    {
                        for (int j = 0; j < chess.GetLength(1); j++)
                            chess[i, j] = MARK.EMPTY;
                    }
                }

            }
        }

        public MARK this[int index1, int index2]
        {
            get
            { /* return the specified index here */
                return index1 >= 0 && index1 < 3 &&
                        index2 >= 0 && index2 < 3 ? chess![index1, index2] : MARK.EMPTY;
            }
            set
            { /* set the specified index to value here */
                if (index1 >= 0 && index1 < 3 &&
                        index2 >= 0 && index2 < 3 &&
                            chess![index1, index2] == MARK.EMPTY) chess[index1, index2] = value;


            }
        }
        #endregion

        #region Methods Game

        public static void Game()
        {
            Console.WriteLine("Who is the first player Computer(0) or Human(1): ");
            var str = Console.ReadLine();
            int choise = int.Parse(str!);
            SeaChess turn;
            if ((Player)choise == Player.COMPUTER)
                turn = new SeaChess(Player.COMPUTER);
            else
                turn = new SeaChess(Player.HUMAN);

            Console.WriteLine(turn);
            if (turn.currentPlayer == Player.HUMAN) 
            {
                turn = turn.PlayHuman();
                Console.WriteLine();
                Console.WriteLine(turn);
            }
            //turn.currentPlayer = Player.HUMAN;
            var state = turn.TerminalTest();
            while(!state.Item1)
            {
                Console.WriteLine("Computer turn.");
                turn = turn.AlphaBetaSearch();
                state = turn.TerminalTest();
                Console.WriteLine(turn);
                if (state.Item1) break;

                turn = turn.PlayHuman();
                Console.WriteLine();
                Console.WriteLine(turn);
                state = turn.TerminalTest();
            }
            if(state.Item2 == Player.COMPUTER)
                Console.WriteLine("Winer is Computer");
            else if (state.Item2 == Player.HUMAN)
                Console.WriteLine("Winer is Human");
            else
                Console.WriteLine("It is a Tie");
        }
        public SeaChess AlphaBetaSearch()
        {
            int alphan = int.MinValue;
            int beta = int.MaxValue;
            int u = MaxValue(alphan,beta);
            return FindSucBy(u, Successors());
        }
        //TODO Search, Min-Value, Max-Value, FindSucBy

        public SeaChess FindSucBy(int value, SeaChess[] successors)
        {
            int alphan = int.MinValue;
            int beta = int.MaxValue;
            int temp;
            foreach (var suc in successors)
            {
                temp = suc.MinValue(alphan, beta);
                if(temp == value) return suc;
            }
            return new SeaChess();
        }
        public int MaxValue(int alphan, int beta)
        {
            var testEnd = TerminalTest();
            if(testEnd.Item1) return UtilityValue(testEnd.Item2);

            int a = alphan;
            int b = beta;
            int u = int.MinValue;
            var successors = Successors();
            foreach (var suc in successors)
            {
                u = Math.Max(u, suc.MinValue(a, b));
                if (u > b) return u;
                a = Math.Max(a, u);
            }
            return u;
        }

        public int MinValue(int alphan,int beta)
        {
            var testEnd = TerminalTest();
            if (testEnd.Item1) return UtilityValue(testEnd.Item2);

            int a = alphan;
            int b = beta;
            int u = int.MaxValue;
            var successors = Successors();
            foreach (var suc in successors)
            {
                u = Math.Min(u, suc.MaxValue(a,b));
                if (u <= a) return u;
                b = Math.Min(b, u);
            }
            return u;
        }
        public SeaChess[] Successors()
        {
            //variables
            SeaChess[] array = new SeaChess[MAX_DEPTH - 1 - depth];
            int index = 0;
            SeaChess nextChess = new SeaChess(this);
            Player nextPlayer;

            //init
            if (this.currentPlayer == Player.HUMAN)
                nextPlayer = Player.COMPUTER;
            else
                nextPlayer = Player.HUMAN;

            //nextChess.currentPlayer = nextPlayer;
            nextChess.depth += 1;

            //process
            for (int i = 0; i < chess!.GetLength(0); i++)
                for (int j = 0; j < chess!.GetLength(1); j++)
                    if (chess[i, j] == MARK.EMPTY)
                    {
                        array[index] = new SeaChess(nextChess);
                        array[index][i, j] = this.currentPlayer == Player.COMPUTER ? MARK.O : MARK.X;
                        array[index].currentPlayer = nextPlayer;
                        index++;
                    }
            return array;
        }
        public int UtilityValue(Player player)
        {
            if (player == Player.COMPUTER )//|| player == Player.NO_PLAYER
                return MAX_DEPTH - depth + 1;
            else if(player == Player.NO_PLAYER)
                return MAX_DEPTH - depth;
            else
            return 0;
        }
        public (bool, Player) TerminalTest()
        {
            // rows: 3  cols: 3  d1: 1  d2: 1
            int[] rowColD1D2ComputerWin = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] rowColD1D2HumanWin = { 1, 1, 1, 1, 1, 1, 1, 1 };
            bool isThereEmpty = false;

            for (int i = 0; i < chess!.GetLength(0); i++)
            {

                for (int j = 0; j < chess.GetLength(1); j++)
                {
                    rowColD1D2ComputerWin[3 + j % 3] += (int)chess[i, j];
                    rowColD1D2HumanWin[3 + j % 3] *= (int)chess[i, j];
                    rowColD1D2ComputerWin[i % 3] += (int)chess[i, j];
                    rowColD1D2HumanWin[i % 3] *= (int)chess[i, j];
                    if (i - j == 0)
                    {
                        rowColD1D2ComputerWin[6] += (int)chess[i, j];
                        rowColD1D2HumanWin[6] *= (int)chess[i, j];
                    }
                    if (i + j == 2)
                    {
                        rowColD1D2ComputerWin[7] += (int)chess[i, j];
                        rowColD1D2HumanWin[7] *= (int)chess[i, j];
                    }
                    if (chess[i, j] == MARK.EMPTY)
                        isThereEmpty = true;
                }
            }
            for (int i = 0; i < rowColD1D2ComputerWin.Length; i++)
            {
                if (rowColD1D2ComputerWin[i] == 0) return (true, Player.COMPUTER);
                if (rowColD1D2HumanWin[i] == 1) return (true, Player.HUMAN);
            }
            if (!isThereEmpty) return (true, Player.NO_PLAYER);


            return (false, Player.NO_PLAYER);
        }
        public SeaChess PlayHuman()
        {
            SeaChess nesxChess = new SeaChess(Player.HUMAN, this.chess, this.depth + 1);
            string line;
            string[] parts;
            int ind1;
            int ind2;

            while (true)
            {
                Console.WriteLine("Payer turn, please enter ind1(0,1,2) ind2(0,1,2):");

                line = Console.ReadLine()!;
                if (line == null) continue;
                parts = line.Split(" ");
                if (parts.Length < 2) continue;

                if (!int.TryParse(parts[0], out ind1)) continue;
                if (!int.TryParse(parts[1], out ind2)) continue;
                if (ind1 >= 0 && ind1 < 3 &&
                        ind2 >= 0 && ind2 < 3)
                    if (nesxChess![ind1, ind2] == MARK.EMPTY)
                    {
                        nesxChess[ind1, ind2] = MARK.X;
                        break;
                    }

            }
            nesxChess.currentPlayer = Player.COMPUTER;
            return nesxChess;
        }

        #endregion
        public override string ToString()
        {
            //return base.ToString();
            string str = "";
            for (int i = 0; i < chess!.GetLength(0); i++)
            {
                for (int j = 0; j < chess.GetLength(1); j++)
                    str += chess[i, j] == MARK.EMPTY ? "_" : chess[i, j] == MARK.X ? "X" : "O";
                str += "\n";
            }

            return str;
        }
    }
}
