using System;

public class Student
{
    public string Name;
    public int Age;
    public Student Next;
    public Student Left;
    public Student Right;

    public Student()
    {
        this.Name = "Unknown";
        this.Age = 0;
        this.Next = null;
        this.Left = null;
        this.Right = null;
    }

    public Student(string name)
    {
        this.Name = name;
        this.Age = 0;
        this.Next = null;
        this.Left = null;
        this.Right = null;
    }

    public Student(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Next = null;
        this.Left = null;
        this.Right = null;
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

public class StudentStack //стек
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

public class StudentTree //древо
{
    private Student root;

    public void Insert(string name, int age)
    {
        Student newStudent = new Student(name, age);
        if (root == null) { root = newStudent; return; }

        Student current = root;
        while (true)
        {
            if (age < current.Age || (age == current.Age && string.Compare(name, current.Name) < 0))
            {
                if (current.Left == null) { current.Left = newStudent; break; }
                current = current.Left;
            }
            else
            {
                if (current.Right == null) { current.Right = newStudent; break; }
                current = current.Right;
            }
        }
    }

    public void Print() => PrintRec(root);

    private void PrintRec(Student node)
    {
        if (node == null) return;
        PrintRec(node.Left);
        Console.WriteLine($"{node.Name} ({node.Age})");
        PrintRec(node.Right);
    }

    public Student Find(string name) => FindRec(root, name);

    private Student FindRec(Student node, string name)
    {
        if (node == null) return null;
        if (node.Name == name) return node;
        return FindRec(node.Left, name) ?? FindRec(node.Right, name);
    }

    public void Delete(string name) => root = DeleteRec(root, name);

    private Student DeleteRec(Student node, string name)
    {
        if (node == null) return null;

        if (node.Name == name)
        {
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;

            Student min = node.Right;
            while (min.Left != null) min = min.Left;
            node.Name = min.Name;
            node.Age = min.Age;
            node.Right = DeleteRec(node.Right, min.Name);
            return node;
        }

        node.Left = DeleteRec(node.Left, name);
        node.Right = DeleteRec(node.Right, name);
        return node;
    }

    public int Count() => CountRec(root);

    private int CountRec(Student node) => node == null ? 0 : 1 + CountRec(node.Left) + CountRec(node.Right);
}

class Program
{
    static void Main()
    {
        StudentQueue queue = new StudentQueue();
        StudentStack stack = new StudentStack();
        StudentTree tree = new StudentTree();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1 - Добавить студента в очередь");
            Console.WriteLine("2 - Показать очередь");
            Console.WriteLine("3 - Удалить студента из очереди");
            Console.WriteLine("4 - Добавить студента в стек");
            Console.WriteLine("5 - Показать стек");
            Console.WriteLine("6 - Удалить студента из стека");
            Console.WriteLine("7 - Добавить студента в дерево");
            Console.WriteLine("8 - Показать дерево");
            Console.WriteLine("9 - Найти студента в дереве");
            Console.WriteLine("10 - Удалить студента из дерева");
            Console.WriteLine("11 - Количество студентов в дереве");
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

                case 7:
                    Console.Write("Имя: ");
                    string nameTree = Console.ReadLine();
                    Console.Write("Возраст: ");
                    int ageTree = Convert.ToInt32(Console.ReadLine());
                    tree.Insert(nameTree, ageTree);
                    Console.WriteLine("Студент добавлен в дерево.");
                    break;

                case 8:
                    Console.WriteLine("\nДерево студентов:");
                    tree.Print();
                    break;

                case 9:
                    Console.Write("Введите имя для поиска: ");
                    string searchName = Console.ReadLine();
                    Student found = tree.Find(searchName);
                    Console.WriteLine(found != null ? $"Найден: {found.Name} ({found.Age})" : "Студент не найден");
                    break;

                case 10:
                    Console.Write("Введите имя для удаления: ");
                    string deleteName = Console.ReadLine();
                    tree.Delete(deleteName);
                    Console.WriteLine("Студент удален из дерева (если был найден)");
                    break;

                case 11:
                    Console.WriteLine($"Количество студентов в дереве: {tree.Count()}");
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
