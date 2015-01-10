using System;

public delegate void ChangedEvent(object sender, EventArgs e);
class Student
{
    public event ChangedEvent PropertyChanged;
    private string name;
    private uint age;
    private PropertyChangedEventArgs previousProperties;
    public string Name
    {

        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Name can't be empty");
            this.PreviousProperties.Name = this.Name;
            this.name = value;
            OnChanged(EventArgs.Empty);
        }
    }
    public uint Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.PreviousProperties.Age = this.Age;
            this.age = value;
            OnChanged(EventArgs.Empty);
        }
    }
    public Student(string name, uint age)
    {
        
        this.name = name;
        this.age = age;
        this.PreviousProperties = new PropertyChangedEventArgs(name, age);
    }
    public PropertyChangedEventArgs PreviousProperties
    {
        get
        {
            return this.previousProperties;
        }
        set
        {
            this.previousProperties = value;
        }
    }
    protected virtual void OnChanged(EventArgs e)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, e);
    }
    
}
class PropertyChangedEventArgs
{
    private string name;
    private uint age;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }
    public uint Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }
    public PropertyChangedEventArgs(string name, uint age)
    {
        this.Name = name;
        this.Age = age;

    }
    

}

