namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        ICollection<Course> courses;        

        public Student()
        {
            this.courses = new HashSet<Course>();            
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<Course> Courses
        { 
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }
    }
}