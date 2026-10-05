using System;
using System.Collections.Generic;

class Program
{
    struct StudentRequest
    {
        public string StudentNumber;
        public string StudentName;
        public string RequestType;
    }

    Queue<StudentRequest> requestQueue =
        new Queue<StudentRequest>();

    static void Main()
    {
        new Program().Menu();
    }

    void Menu()
    {
        int choice;

        do
        {
            Console.WriteLine("======================================");
            Console.WriteLine("STUDENT REQUEST QUEUE");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Add Request");
            Console.WriteLine("2. View Pending Requests");
            Console.WriteLine("3. Process Request");
            Console.WriteLine("4. Exit");

            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1) AddRequest();
            else if (choice == 2) ViewRequests();
            else if (choice == 3) ProcessRequest();

        } while (choice != 4);
    }

    void AddRequest()
    {
        StudentRequest r = new StudentRequest();

        Console.Write("Enter Student Number: ");
        r.StudentNumber = Console.ReadLine();

        Console.Write("Enter Student Name: ");
        r.StudentName = Console.ReadLine();

        Console.Write("Enter Request Type: ");
        r.RequestType = Console.ReadLine();

        requestQueue.Enqueue(r);

        Console.WriteLine();
        Console.WriteLine("Request added successfully!");
    }

    void ViewRequests()
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("No pending requests.");
            return;
        }

        Console.WriteLine("REQUEST QUEUE");

        int i = 1;
        foreach (StudentRequest r in requestQueue)
        {
            Console.WriteLine(i + ". " + r.StudentName +
                " - " + r.RequestType);
            i++;
        }

        Console.WriteLine();
    }

    void ProcessRequest()
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("No pending requests.");
            return;
        }

        StudentRequest r = requestQueue.Dequeue();

        Console.WriteLine("Processing Request: " +
            r.StudentName + " - " + r.RequestType);

        Console.WriteLine();
        Console.WriteLine("Request processed successfully!");
    }
}
