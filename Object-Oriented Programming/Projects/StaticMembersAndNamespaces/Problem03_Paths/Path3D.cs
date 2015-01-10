using System;
using System.Collections.Generic;



class Path3D
{
    private List<Point3D> path = new List<Point3D>();
    public List<Point3D> Path
    {
        get 
        {
            return this.path;
        }
        set
        {
            this.path = value;
        }
    }
    public Path3D(List<Point3D> path)
    {
        this.Path = path;
    }
    public override string ToString()
    {
        string output = "";
        foreach(Point3D point in this.Path)
        {
            output += point.ToString() + "\n\r";
            
        }
        return string.Format(output);
    }
}

