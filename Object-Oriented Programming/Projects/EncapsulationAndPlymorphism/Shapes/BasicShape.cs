using System;

public abstract class BasicShape : IShape
{
    private double width;
    private double height;

    public BasicShape(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width
    {
        get
        {
            return this.width;
        }

        set
        {
            Checkers.CheckSide(value);

            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }

        set
        {
            Checkers.CheckSide(value);            

            this.height = value;
        }    
    }

    public abstract double CalculateArea();

    public abstract double CalculatePerimeter();
}