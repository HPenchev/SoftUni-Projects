using System;


class Point3D
{
    private float x;
    private float y;
    private float z;

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

