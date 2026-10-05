using System;
using System.Collections.Generic;

class Program
{
    struct Operation
    {
        public string Action;
        public string StudentNumber;
        public string StudentName;
    }

    Stack<Operation> operationHistory = new Stack<Operation>();

    static void Main()
    {
        new Program().Run();
    }

    void Run()
    {
        Add("Added", "2026-0001", "Juan");
        Add("Added", "2026-0002", "Maria");
        Add("Updated", "2026-0001", "Juan");
        Add("Deleted", "2026-0003", "Pedro");

        int choice;

        do
        {
            Console.WriteLine("====================================");
            Console.WriteLine("          OPERATION HISTORY");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine("1. View Operation History");
            Console.WriteLine("2. View Last Operation");
            Console.WriteLine("3. Remove Last Operation");
            Console.WriteLine("4. Exit");
            Console.WriteLine();

            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) ViewHistory();
            else if (choice == 2) ViewLast();
            else if (choice == 3) RemoveLast();

        } while (choice != 4);
    }

    void Add(string action, string number, string name)
    {
        operationHistory.Push(new Operation
        {
            Action = action,
            StudentNumber = number,
            StudentName = name
        });
    }

    void ViewHistory()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No operation records.");
            return;
        }

        Console.WriteLine("OPERATION HISTORY");
        Console.WriteLine();

        Operation[] list = operationHistory.ToArray();

        for (int i = list.Length - 1, n = 1; i >= 0; i--, n++)
            Console.WriteLine(n + ". " + list[i].Action + " " + list[i].StudentName);

        Console.WriteLine();
    }

    void ViewLast()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No operation records.");
            return;
        }

        Operation o = operationHistory.Peek();

        Console.WriteLine("Last Operation: " +
            o.Action + " " + o.StudentName);
        Console.WriteLine();
    }

    void RemoveLast()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No operation records.");
            return;
        }

        operationHistory.Pop();

        Console.WriteLine("Last operation removed successfully!");
        Console.WriteLine();
    }
}
