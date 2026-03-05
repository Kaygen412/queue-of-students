using System;

public class Student
{
    public string Name;
    public int Age;
    public Student Next;

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
        Next = null;
    }
}

public class StudentQueue
{
    private Student head;
    private Student tail;

    public void Enqueue(string name, int age)
    {
        Student newStudent = new Student(name, age);

        if (tail != null)
        {
            tail.Next = newStudent;
        }

        tail = newStudent;

        if (head == null)
        {
            head = newStudent;
        }
    }

    public void Print()
    {
        Student current = head;

        if (current == null)
        {
            Console.WriteLine("Очередь пустая");
            return;
        }

        while (current != null)
        {
            Console.WriteLine($"{current.Name} ({current.Age})");
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        StudentQueue queue = new StudentQueue();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1 - Добавить студента");
            Console.WriteLine("2 - Показать очередь");
            Console.WriteLine("0 - Выход");
            Console.Write("Выбор: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Имя: ");
                    string name = Console.ReadLine();

                    Console.Write("Возраст: ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    queue.Enqueue(name, age);
                    Console.WriteLine("Студент добавлен.");
                    break;

                case 2:
                    queue.Print();
                    break;

                case 0:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
} 