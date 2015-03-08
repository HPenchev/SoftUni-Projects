namespace Matrix
{
    using System;

    public class WalkInMatrix 
    {
        private const int NMinValue = 1;

        private const int NMaxValue = 99;

        public static void Main()
        {
            int n = TakeInput();            
           
            int[,] matrix = BuildMatrix(n);

            PrintMatrix(matrix);
        }        

        public static int[,] BuildMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            
            int i = 0;
            int j = 0;
            int counter = 1;            

            counter = WalkMatrix(matrix, i, j, counter);

            counter++;

            int[] coordinatesOfNewPoint = ChooseCell(matrix);
            i = coordinatesOfNewPoint[0];
            j = coordinatesOfNewPoint[1];

            if (i != 0 && j != 0)
            {
                WalkMatrix(matrix, i, j, counter);
            }

            return matrix;
        }

        private static int WalkMatrix(int[,] matrix, int i, int j, int counter)
        {
            int n = matrix.GetLength(0);
            int diagonalX = 1;
            int diagonalY = 1;

            while (true)
            { 
                matrix[i, j] = counter;

                if (!IsDirectionAvailable(matrix, i, j))
                {
                    break;
                }                            

                while (
                    i + diagonalX >= n ||
                    i + diagonalX < 0 ||
                    j + diagonalY >= n ||
                    j + diagonalY < 0 ||
                    matrix[i + diagonalX, j + diagonalY] != 0)
                {
                    int[] direction = ChooseDirection(diagonalX, diagonalY);
                    diagonalX = direction[0];
                    diagonalY = direction[1];
                }                

                i += diagonalX;
                j += diagonalY;
                counter++;
            }

            return counter;
        }

        private static int[] ChooseDirection(int directionX, int directionY)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirection = 0;
            int length = dirX.Length;

            for (int i = 0; i < length; i++)
            {
                if (dirX[i] == directionX && dirY[i] == directionY)
                {
                    currentDirection = i;
                    break;
                }
            }

            if (currentDirection == length - 1)
            {
                directionX = dirX[0];
                directionY = dirY[0];

                return new int[] { directionX, directionY };
            }

            directionX = dirX[currentDirection + 1];
            directionY = dirY[currentDirection + 1];

            return new int[] { directionX, directionY };
        }

        private static bool IsDirectionAvailable(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int length = dirX.Length;

            for (int i = 0; i < length; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < length; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static int[] ChooseCell(int[,] arr)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return new int[] { x, y };
                    }
                }
            }

            return new int[] { x, y };
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static int TakeInput()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n <= NMinValue || n >= NMaxValue)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return n;
        }
    }
}