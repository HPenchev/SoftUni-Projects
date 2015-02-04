// Единствено правоъгълникът наследява BasicShape, понеже Width и Height нямат смисъл в триъгълник и кръг.
// Rectangle is the only class that inherits BasicShape as Width and Height make no sence in triangle or circle.

using System;

public class ShapesTest
{
    public static void Main()
    {
        Rectangle rectangle = new Rectangle(3, 5);
        Triangle triangle = new Triangle(2, 6, 5);
        Circle circle = new Circle(5);

        IShape[] figures = { rectangle, triangle, circle };

        foreach (IShape figure in figures)
        {
            Console.WriteLine(figure.CalculateArea() + " " + figure.CalculatePerimeter());
        }
    }
}