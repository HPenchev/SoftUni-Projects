using System;

[AttributeUsage(
        AttributeTargets.Struct |
        AttributeTargets.Class |
        AttributeTargets.Interface |
        AttributeTargets.Method |
        AttributeTargets.Enum)]

class VersionAttribute : System.Attribute
{    
    private int major;
    private int minor;
    public int Major
    {
        get
        {
            return this.major;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Major can't be negative");
            this.major = value;
        }
    }
    public int Minor
    {
        get
        {
            return this.minor;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Major can't be negative");
            this.minor = value;
        }
    }
    public override string ToString()
    {
        string output = this.Major + "." + this.Minor;
        return string.Format(output);
    }
    public VersionAttribute(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
    }
}

