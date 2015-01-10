using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


static class Storage
{
    public static Path3D ReadPath()
    {
        
        
        List<Point3D> points = new List<Point3D>();
        using (StreamReader reader = new StreamReader(@"../../paths/paths.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] pointsString = line.Split(',');
                float x = float.Parse(pointsString[0].Trim());
                float y = float.Parse(pointsString[1].Trim());
                float z = float.Parse(pointsString[2].Trim());
                Point3D point = new Point3D(x, y, z);
                points.Add(point);
            }
        }
        Path3D path = new Path3D(points);
        return path;
        
    }
    public static void WritePath(Path3D path)
    {
        
        using (StreamWriter writer = new StreamWriter(@"../../paths/pathsoutput.txt"))
        {
            string pathString = path.ToString();
            pathString = pathString.Replace("\n", Environment.NewLine);
            writer.WriteLine(pathString);
        }

    }
}

