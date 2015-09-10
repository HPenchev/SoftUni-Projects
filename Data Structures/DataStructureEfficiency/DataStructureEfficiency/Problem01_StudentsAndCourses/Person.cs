using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01_StudentsAndCourses
{
    class Person : IComparable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Person otherPerson= obj as Person;
            if (otherPerson != null)
                return (this.LastName + this.FirstName)
                    .CompareTo(otherPerson.LastName + otherPerson.FirstName);
            else
                throw new ArgumentException("Object is not a Person");
        }
    }
}