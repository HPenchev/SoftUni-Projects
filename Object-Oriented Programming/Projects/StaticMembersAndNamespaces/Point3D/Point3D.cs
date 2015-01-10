using System;



class Point3D
{
    private static float xStart = 0f;
    private static float yStart = 0f;
    private static float zStart = 0f;
    public static string StartCoordinates;
    private float x;
    private float y;
    private float z;

    public float XStart
    {
        get
        {
            return xStart;
        }
    }
    public float YStart
    {
        get
        {
            return yStart;
        }
    }
    public float ZStart
    {
        get
        {
            return yStart;
        }
    }
    public static string StartingPoints
    {
        get
        {
            return xStart + ", " + yStart + ", " + zStart;
        }
    }
    public float X
    {
        get
        {
            return this.x;
        }
        set
        {
            this.x = value;
        }
    }
    public float Y
    {
        get
        {
            return this.y;
        }
        set
        {
            this.y = value;
        }
    }
    public float Z
    {
        get
        {
            return this.z;
        }
        set
        {
            this.z = value;
        }
    }

    public Point3D(float x, float y, float z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public override string ToString()
    {
        string output = this.X + ", " + this.Y + ", " + this.Z;
        return string.Format(output);
    }
    
}


