using System;

struct Student
{
    public string StudentNumber, Name, program;
    public int YearLevel;
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[10];
        int count = 0;

        while (true)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" STUDENT RECORD MANAGEMENT");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (count >= 10)
                    Console.WriteLine("Cannot add more than 10 students.");
                else
                {
                    Student s = new Student();

                    Console.Write("Enter Student Number: ");
                    s.StudentNumber = Console.ReadLine();

                    Console.Write("Enter Name: ");
                    s.Name = Console.ReadLine();

                    Console.Write("Enter Program: ");
                    s.program = Console.ReadLine();

                    Console.Write("Enter Year Level: ");
                    s.YearLevel = int.Parse(Console.ReadLine());

                    students[count++] = s;
                    Console.WriteLine("Student added successfully!");
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("========================================");
                Console.WriteLine(" STUDENT RECORDS");
                Console.WriteLine("========================================");

                if (count == 0)
                    Console.WriteLine("No student records found.");
                else
                    for (int i = 0; i < count; i++)
                        Display(students[i]);
            }
            else if (choice == "3")
            {
                Console.Write("Enter Student Number to search: ");
                int i = Find(students, count, Console.ReadLine());

                if (i == -1)
                    Console.WriteLine("Student not found.");
                else
                {
                    Console.WriteLine("Student Found!");
                    Display(students[i]);
                }
            }
            else if (choice == "4")
            {
                Console.Write("Enter Student Number to update: ");
                int i = Find(students, count, Console.ReadLine());

                if (i == -1)
                    Console.WriteLine("Student not found.");
                else
                {
                    Console.Write("Enter New Name: ");
                    students[i].Name = Console.ReadLine();

                    Console.Write("Enter New Program: ");
                    students[i].program = Console.ReadLine();

                    Console.Write("Enter New Year Level: ");
                    students[i].YearLevel = int.Parse(Console.ReadLine());

                    Console.WriteLine("Student updated successfully!");
                }
            }
            else if (choice == "5")
            {
                Console.Write("Enter Student Number to delete: ");
                int i = Find(students, count, Console.ReadLine());

                if (i == -1)
                    Console.WriteLine("Student not found.");
                else
                {
                    for (int j = i; j < count - 1; j++)
                        students[j] = students[j + 1];

                    count--;
                    Console.WriteLine("Student deleted successfully!");
                }
            }
            else if (choice == "6")
            {
                break;
            }
        }
    }

    static int Find(Student[] students, int count, string number)
    {
        for (int i = 0; i < count; i++)
            if (students[i].StudentNumber == number)
                return i;

        return -1;
    }

    static void Display(Student s)
    {
        Console.WriteLine("Student Number: " + s.StudentNumber);
        Console.WriteLine("Name: " + s.Name);
        Console.WriteLine("Program: " + s.program);
        Console.WriteLine("Year Level: " + s.YearLevel);
        Console.WriteLine();
    }
}
