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

public class StudentStack
{
    private Student top;

    public void Push(string name, int age)
    {
        Student newStudent = new Student(name, age);
        newStudent.Next = top;
        top = newStudent;
    }

    public void Pop()
    {
        if (top == null)
        {
            Console.WriteLine("Стек пустой");
            return;
        }

        Console.WriteLine($"Удаляется студент из стека: {top.Name}");
        top = top.Next;
        GC.Collect();
    }

    public void Print()
    {
        Student current = top;

        if (current == null)
        {
            Console.WriteLine("Стек пустой");
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
        StudentStack stack = new StudentStack();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1 - Добавить студента в очередь");
            Console.WriteLine("2 - Показать очередь");
            Console.WriteLine("3 - Удалить студента из очереди");
            Console.WriteLine("4 - Добавить студента в стек");
            Console.WriteLine("5 - Показать стек");
            Console.WriteLine("6 - Удалить студента из стека");
            Console.WriteLine("0 - Выход");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Имя: ");
                    string nameQueue = Console.ReadLine();

                    Console.Write("Возраст: ");
                    int ageQueue = Convert.ToInt32(Console.ReadLine());

                    queue.Enqueue(nameQueue, ageQueue);
                    Console.WriteLine("Студент добавлен в очередь.");
                    break;

                case 2:
                    Console.WriteLine("\nОчередь студентов:");
                    queue.Print();
                    break;

                case 3:
                    queue.Dequeue();
                    break;

                case 4:
                    Console.Write("Имя: ");
                    string nameStack = Console.ReadLine();

                    Console.Write("Возраст: ");
                    int ageStack = Convert.ToInt32(Console.ReadLine());

                    stack.Push(nameStack, ageStack);
                    Console.WriteLine("Студент добавлен в стек.");
                    break;

                case 5:
                    Console.WriteLine("\nСтек студентов:");
                    stack.Print();
                    break;

                case 6:
                    stack.Pop();
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
