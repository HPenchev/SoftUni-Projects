using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        Student student = new Student("Ivan", "Nikolov", "sfdg82");
        students.Add(student);
        student = new Student("Maria", "Georgieva", "345435dfs");
        students.Add(student);
        student = new Student("Petar", "Stoyanov", "8079d7gdfg");
        students.Add(student);
        student = new Student("Georgi", "Ivanov", "sdf34r2");
        students.Add(student);
        student = new Student("Nikola", "Hristov", "sadfsdf43");
        students.Add(student);
        student = new Student("Stanislava", "Toneva", "23423423s");
        students.Add(student);
        student = new Student("Mirela", "Atanasova", "234asaaa");
        students.Add(student);
        student = new Student("Petar", "Antonov", "234234sdf");
        students.Add(student);
        student = new Student("Maya", "Stefanova", "sdfsdfsd");
        students.Add(student);
        student = new Student("Lyubomira", "Tsvetanova", "12sdf");
        students.Add(student);
        students = students.OrderBy(s => s.FacultyNumber)
            .Select(s => s).ToList();
        
        foreach (Student stdt in students)
        {
            Console.WriteLine(stdt.FacultyNumber + " " + stdt.FirstName + " " + stdt.LastName);
        }
        Console.WriteLine();
        Console.WriteLine();

        List<Worker> workers = new List<Worker>();
        Worker worker = new Worker("Ivan", "Petrov", 8, 500);
        workers.Add(worker);
        worker = new Worker("Nikola", "Stoyanov", 7, 520);
        workers.Add(worker);
        worker = new Worker("Georgi", "Mihaylov", 12, 300);
        workers.Add(worker);
        worker = new Worker("Georgi", "Georgiev", 8, 550);
        workers.Add(worker);
        worker = new Worker("Tsvetelina", "Misheva", 9, 250);
        workers.Add(worker);
        worker = new Worker("Stevan", "Stefanov", 4, 100);
        workers.Add(worker);
        worker = new Worker("Georgi", "Zarev", 6, 800);
        workers.Add(worker);
        worker = new Worker("Lidiya", "Ivanova", 7, 660);
        workers.Add(worker);
        worker = new Worker("Nadezhda", "Veleva", 8, 440);
        workers.Add(worker);
        worker = new Worker("Nikola", "Popov", 8, 300);
        workers.Add(worker);

        workers = workers.OrderByDescending(w => w.MoneyPerHour())
            .Select(w => w).ToList();

        foreach (Worker wkr in workers)
        {
            Console.WriteLine("{0} {1} {2}", wkr.MoneyPerHour(), wkr.FirstName, wkr.LastName);
        }
        Console.WriteLine();
        Console.WriteLine();
        var people = students.Cast<Human>().Concat(workers.Cast<Human>())
            .OrderBy(person => person.FirstName)
            .ThenBy(person => person.LastName)
            .Select(person => person);
        foreach (var person in people)
        {
            Console.WriteLine(person.FirstName + " " + person.LastName);
        }
        
        
        
    }
}

