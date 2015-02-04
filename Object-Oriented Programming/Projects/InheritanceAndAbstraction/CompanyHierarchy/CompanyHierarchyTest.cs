using System;
using System.Collections.Generic;


class CompanyHierarchyTest
{
    static void Main()
    {
        string dateString = "15.01.2015";
        DateTime date = DateTime.Parse(dateString);
        List<Project> projects = new List<Project>();
        Project project = new Project("Diablo", date, "Ausome game", "open");
        projects.Add(project);

        dateString = "09.12.2015";
        date = DateTime.Parse(dateString);
        project = new Project("Fasty", date, "Storage program", "open");
        projects.Add(project);

        dateString = "09.09.2009";
        date = DateTime.Parse(dateString);
        project = new Project("Red Alert 3", date, "Game", "closed");
        projects.Add(project);

        List<Sale> sales = new List<Sale>();
        dateString = "09.01.2015";
        date = DateTime.Parse(dateString);
        Sale sale = new Sale("Entersort ERP", date ,100000);
        sales.Add(sale);

        dateString = "05.01.2015";
        date = DateTime.Parse(dateString);
        sale = new Sale("SAP", date ,1000000);
        sales.Add(sale);


        List<Employee> employees = new List<Employee>();
        List<Employee> subordinates = new List<Employee>();
        Employee employee = new Developer("Ivan", "Ivanov", 2342342, 7000, "Production", projects);
        subordinates.Add(employee);

        employee = new Developer("Petar", "Nikolov", 2345454, 5000, "Production", projects);
        subordinates.Add(employee);

        employee = new SalesEmployee("Snezhana", "Ilieva", 5666454, 3000, "Sales", sales);
        subordinates.Add(employee);

        employees = subordinates;
        employee = new Manager("Ivan", "Georgiev", 656465654, 30000, "Sales", subordinates);
        //employees.Add(employee);
        foreach (Employee empl in subordinates)
        {
            Console.WriteLine(empl.ToString());
        }

        



    }
}

