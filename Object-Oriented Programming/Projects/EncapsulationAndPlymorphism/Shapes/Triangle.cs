using System;

public class Triangle : IShape
{
    private double a;
    private double b;
    private double c;

    public Triangle(double a, double b, double c)
    {
        this.CheckTriangleValidity(a, b, c);

        this.A = a;
        this.B = b;
        this.C = c;
    }

    public double A
    {
        get
        {
            return this.a;
        }

        set
        {
            Checkers.CheckSide(value);

            this.a = value;
        }
    }

    public double B
    {
        get
        {
            return this.b;
        }

        set
        {
            Checkers.CheckSide(value);

            this.b = value;
        }
    }

    public double C
    {
        get
        {
            return this.c;
        }

        set
        {
            Checkers.CheckSide(value);

            this.c = value;
        }
    }    

    public double CalculatePerimeter()
    {
        double perimeter = this.A + this.B + this.C;

        return perimeter;
    }

    public double CalculateArea()
    {
        double halfPerimeter = this.CalculatePerimeter() / 2;
        double area = Math.Sqrt(halfPerimeter * (halfPerimeter - this.A) * (halfPerimeter - this.B) *
            (halfPerimeter - this.C));

        return area;
    }

    private void CheckTriangleValidity(double a, double b, double c)
    {
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            throw new ArgumentException("Sides given can't form a triangle");
        }
    }
}