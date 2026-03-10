using System;

public class Student
{
    public string Name;
    public int Age;
    public Student Next;


    public Student()
    {
        this.Name = "Unknown";
        this.Age = 0;
        this.Next = null;
    }


    public Student(string name)
    {
        this.Name = name;
        this.Age = 0;
        this.Next = null;
    }

    public Student(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Next = null;
    }


    ~Student()
    {
        Console.WriteLine($"Студент {this.Name} удален из памяти");
    }
}

public class StudentQueue
{
    private Student head;
    private Student tail;

    public void Enqueue(string name, int age)
    {
        Student newStudent = new Student(name, age);

        if (this.tail != null)
        {
            this.tail.Next = newStudent;
        }

        this.tail = newStudent;

        if (this.head == null)
        {
            this.head = newStudent;
        }
    }
    public void Dequeue()
    {
        if (this.head == null)
        {
            Console.WriteLine("Очередь пустая");
            return;
        }

        Console.WriteLine($"Удаляется студент: {this.head.Name}");

        this.head = this.head.Next;

        if (this.head == null)
        {
            this.tail = null;
        }

        GC.Collect();
    }

    public void Print()
    {
        Student current = this.head;

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
            Console.WriteLine("3 - Удалить студента");
            Console.WriteLine("0 - Выход");

            int choice = Convert.ToInt32(Console.ReadLine());7

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

                case 3:
                    queue.Dequeue();
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