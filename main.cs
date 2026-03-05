using sistem
class student
{
    public string Name{get;set;}
    public int Age {get;set;}
    public List<int> Grades{get;set;}
    public student(string name,int age)
    {
        this.Name = name;
        this.Age = age;
        this.Grades = new List<int>();
    }
    public void AddGrade(int grade)
    {
        if (grade >= 0&& grade <=100)
        {
            this.Grades.Add(grade);
        }
        else
        {
            Console.WriteLine($"оценка должна быть от 0 до 100");
        }
    }
}