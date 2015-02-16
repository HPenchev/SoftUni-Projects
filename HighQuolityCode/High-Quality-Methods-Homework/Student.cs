using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.DayOfBirth;
            DateTime secondDate = other.DayOfBirth;
            return firstDate > secondDate;
        }
    }
}
