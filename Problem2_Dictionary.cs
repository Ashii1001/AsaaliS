using System;
using System.Collections.Generic;

class Student
{
    public string StudentNumber, Name, Program;
    public int YearLevel;

    public Student(string sn, string name, string program, int year)
    {
        StudentNumber = sn;
        Name = name;
        Program = program;
        YearLevel = year;
    }
}

class Program
{
    Dictionary<string, Student> studentDictionary =
        new Dictionary<string, Student>();

    static void Main()
    {
        new Program().Run();
    }

    void Run()
    {
        int choice;

        do
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("       STUDENT LOOKUP USING DICTIONARY");
            Console.WriteLine("==============================================");
            Console.WriteLine();
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Display All Students");
            Console.WriteLine("4. Exit");
            Console.WriteLine();

            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) AddStudent();
            else if (choice == 2) SearchStudent();
            else if (choice == 3) DisplayStudents();

        } while (choice != 4);
    }

    void AddStudent()
    {
        Console.Write("Enter Student Number: ");
        string number = Console.ReadLine();

        if (studentDictionary.ContainsKey(number))
        {
            Console.WriteLine("Student Number already exists!");
            return;
        }

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Program: ");
        string program = Console.ReadLine();

        Console.Write("Enter Year Level: ");
        int year = int.Parse(Console.ReadLine());

        studentDictionary.Add(number,
            new Student(number, name, program, year));

        Console.WriteLine();
        Console.WriteLine("Student added successfully!");
    }

    void SearchStudent()
    {
        Console.Write("Enter Student Number to search: ");
        string number = Console.ReadLine();

        if (studentDictionary.TryGetValue(number, out Student s))
        {
            Console.WriteLine();
            Console.WriteLine("Student Found!");
            Console.WriteLine("Student Number: " + s.StudentNumber);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Program: " + s.Program);
            Console.WriteLine("Year Level: " + s.YearLevel);
        }
        else
            Console.WriteLine("Student Number does not exist.");
    }

    void DisplayStudents()
    {
        foreach (Student s in studentDictionary.Values)
        {
            Console.WriteLine("Student Number: " + s.StudentNumber);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Program: " + s.Program);
            Console.WriteLine("Year Level: " + s.YearLevel);
            Console.WriteLine();
        }
    }
}
