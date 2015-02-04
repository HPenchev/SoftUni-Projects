using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01_School
{
    class Test
    {
        static void Main()
        {
            Student student = new Student(1, "Ivan Ivanov", "Otlichnik");
            List<Student> classOneStudents = new List<Student>();
            List<Student> classTwoStudents = new List<Student>();
            List<Student> mathStudents = new List<Student>();
            List<Student> informaticsStudents = new List<Student>();
            List<Student> biologyStudents = new List<Student>();
            classOneStudents.Add(student);
            mathStudents.Add(student);
            informaticsStudents.Add(student);
            student = new Student(2, "Ivan Petrov");
            classOneStudents.Add(student);
            mathStudents.Add(student);
            biologyStudents.Add(student);
            student = new Student(3, "Petar Petrov");
            classOneStudents.Add(student);
            mathStudents.Add(student);
            biologyStudents.Add(student);
            informaticsStudents.Add(student);
            student = new Student(4, "Nadia Stoyanova");
            classOneStudents.Add(student);
            biologyStudents.Add(student);
            informaticsStudents.Add(student);
            student = new Student(5, "Elena Ivanova");
            classOneStudents.Add(student);
            biologyStudents.Add(student);
            informaticsStudents.Add(student);
            student = new Student(6, "Milena Nikolova");
            classTwoStudents.Add(student);
            mathStudents.Add(student);
            informaticsStudents.Add(student);
            student = new Student(7, "Georgi Petrov");
            classTwoStudents.Add(student);
            mathStudents.Add(student);
            informaticsStudents.Add(student);
            student = new Student(8, "Petar Stefanov");
            classTwoStudents.Add(student);
            mathStudents.Add(student);
            biologyStudents.Add(student);
            student = new Student(9, "Georgi Petrov");
            classTwoStudents.Add(student);
            biologyStudents.Add(student);
            informaticsStudents.Add(student);
            student = new Student(9, "Ivelina Nikolova");
            classTwoStudents.Add(student);
            biologyStudents.Add(student);
            informaticsStudents.Add(student);
            mathStudents.Add(student);
            Discipline math = new Discipline("Math", 18, mathStudents);
            Discipline informatics = new Discipline("Informatics", 10, informaticsStudents);
            Discipline biology = new Discipline("biology", 12, biologyStudents);
            Teacher stoyanNikolov = new Teacher("Stoyan Nikolov", new List<Discipline>(new Discipline[] { math, informatics }));
            Teacher gerganaPetrova = new Teacher("Gergana Petrova", new List<Discipline>(new Discipline[] { biology }));
            Teacher ivanNikolov = new Teacher("Ivan Nikolov", new List<Discipline>(new Discipline[] { math }));
            Class a = new Class("A", new List<Teacher>(new Teacher[] { stoyanNikolov, gerganaPetrova, ivanNikolov }), classOneStudents, "Elite students");
            Class b = new Class("B", new List<Teacher>(new Teacher[] { stoyanNikolov, gerganaPetrova}), classTwoStudents);
            School school = new School(new List<Class>(new Class[]{a, b}));
        }
    }
}
