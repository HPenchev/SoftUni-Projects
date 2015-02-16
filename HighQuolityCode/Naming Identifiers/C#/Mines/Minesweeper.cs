using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Minesweeper
    {
        public class Ranking
        {
            private string name;

            private int points;

            public string Name
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }

            public int Points
            {
                get
                {
                    return points;
                }

                set
                {
                    points = value;
                }
            }

            public Ranking()
            {
            }

            public Ranking(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }
        }

        private static void Main(string[] arguments)
        {
            string command = string.Empty;
            char[,] field = CreatePlayField();
            char[,] bombs = DeployBombs();
            int turnsCounter = 0;
            bool explosion = false;
            List<Ranking> champions = new List<Ranking>(6);
            int row = 0;
            int column = 0;
            bool flag = true;
            const int max = 35;
            bool flag2 = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine(
                        "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki."
                        + " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    Dumpp(field);
                    flag = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Rank(champions);
                        break;
                    case "restart":
                        field = CreatePlayField();
                        bombs = DeployBombs();
                        Dumpp(field);
                        explosion = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                Play(field, bombs, row, column);
                                turnsCounter++;
                            }

                            if (max == turnsCounter)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                Dumpp(field);
                            }
                        }
                        else
                        {
                            explosion = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (explosion)
                {
                    Dumpp(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", turnsCounter);
                    string nikname = Console.ReadLine();
                    Ranking t = new Ranking(nikname, turnsCounter);
                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < t.Points)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Ranking r1, Ranking r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Ranking r1, Ranking r2) => r2.Points.CompareTo(r1.Points));
                    Rank(champions);

                    field = CreatePlayField();
                    bombs = DeployBombs();
                    turnsCounter = 0;
                    explosion = false;
                    flag = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    Dumpp(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string rankingName = Console.ReadLine();
                    Ranking rankingPoints = new Ranking(rankingName, turnsCounter);
                    champions.Add(rankingPoints);
                    Rank(champions);
                    field = CreatePlayField();
                    bombs = DeployBombs();
                    turnsCounter = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Rank(List<Ranking> rankingPoints)
        {
            Console.WriteLine("\nTo4KI:");
            if (rankingPoints.Count > 0)
            {
                for (int i = 0; i < rankingPoints.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, rankingPoints[i].Name, rankingPoints[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void Play(char[,] field, char[,] bombs, int row, int column)
        {
            char numberOfBombs = CheckQuontity(bombs, row, column);
            bombs[row, column] = numberOfBombs;
            field[row, column] = numberOfBombs;
        }

        private static void Dumpp(char[,] board)
        {
            int row = board.GetLength(0);
            int column = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < column; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] DeployBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] playField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> randomPositions = new List<int>();
            while (randomPositions.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!randomPositions.Contains(randomNumber))
                {
                    randomPositions.Add(randomNumber);
                }
            }

            foreach (int randomNumber in randomPositions)
            {
                int col = randomNumber / columns;
                int row = randomNumber % columns;
                if (row == 0 && randomNumber != 0)
                {
                    col--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                playField[col, row - 1] = '*';
            }

            return playField;
        }

        private static void Calculations(char[,] field)
        {
            int col = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char kolkoo = CheckQuontity(field, i, j);
                        field[i, j] = kolkoo;
                    }
                }
            }
        }

        private static char CheckQuontity(char[,] field, int width, int height)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            if (width - 1 >= 0)
            {
                if (field[width - 1, height] == '*')
                {
                    count++;
                }
            }

            if (width + 1 < rows)
            {
                if (field[width + 1, height] == '*')
                {
                    count++;
                }
            }

            if (height - 1 >= 0)
            {
                if (field[width, height - 1] == '*')
                {
                    count++;
                }
            }

            if (height + 1 < rows)
            {
                if (field[width, height + 1] == '*')
                {
                    count++;
                }
            }

            if ((width - 1 >= 0) && (height - 1 >= 0))
            {
                if (field[width - 1, height - 1] == '*')
                {
                    count++;
                }
            }

            if ((width - 1 >= 0) && (height + 1 < rows))
            {
                if (field[width - 1, height + 1] == '*')
                {
                    count++;
                }
            }

            if ((width + 1 < rows) && (height - 1 >= 0))
            {
                if (field[width + 1, height - 1] == '*')
                {
                    count++;
                }
            }

            if ((width + 1 < rows) && (height + 1 < rows))
            {
                if (field[width + 1, height + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}