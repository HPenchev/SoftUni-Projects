using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EventListener
{
    private Student student;
    public Student Student
    {
        get
        {
            return this.student;
        }
        set
        {
            this.student = value;
        }
    }
    public EventListener(Student student)
    {
        this.Student = student;
        student.PropertyChanged += new ChangedEvent(ChangedProperty);
    }
    private void ChangedProperty(object sender, EventArgs e)
    {
        Console.WriteLine("Property changed: {0} (from {1} to {2}");

    }
    public void Detach()
    {

        student.PropertyChanged -= new ChangedEvent(ChangedProperty);
        student = null;
    }

}

