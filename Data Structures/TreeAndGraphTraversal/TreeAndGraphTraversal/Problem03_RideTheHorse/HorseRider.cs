using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03_RideTheHorse
{
    public class HorseRider
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startColumn = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, columns];

            Point startPoint = new Point(startColumn, startRow, 1);
            matrix[startRow, startColumn] = 1;

            Queue<Point> visitedPoints = new Queue<Point>();
            visitedPoints.Enqueue(startPoint);

            while(visitedPoints.Any())
            {
                Point currentPoint = visitedPoints.Dequeue();
                EnqueuePoint(currentPoint, visitedPoints, matrix, -1, 2, rows, columns);
                EnqueuePoint(currentPoint, visitedPoints, matrix, 1, 2, rows, columns);
                EnqueuePoint(currentPoint, visitedPoints, matrix, 2, 1, rows, columns);
                EnqueuePoint(currentPoint, visitedPoints, matrix, 2, -1, rows, columns);
                EnqueuePoint(currentPoint, visitedPoints, matrix, 1, -2, rows, columns);
                EnqueuePoint(currentPoint, visitedPoints, matrix, -1, -2, rows, columns);
                EnqueuePoint(currentPoint, visitedPoints, matrix, -2, -1, rows, columns);
                EnqueuePoint(currentPoint, visitedPoints, matrix, -2, 1, rows, columns);
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(matrix[i, columns/2]);
            }
        }  
      
        private static void EnqueuePoint(
            Point currentPoint, 
            Queue<Point> visitedPoints, 
            int[,] matrix,
            int deltaX, 
            int deltaY,
            int rows,
            int columns)
        {
            int newX = currentPoint.X + deltaX;
            int newY = currentPoint.Y + deltaY;
            int newValue = currentPoint.Value + 1;

            if (newX >=0 && newX < columns && newY >= 0 && newY < rows && matrix[newY, newX] == 0)
            {
                Point newPoint = new Point(newX, newY, newValue);
                matrix[newY, newX] = newValue;
                visitedPoints.Enqueue(newPoint);
            }
        }
    }
}