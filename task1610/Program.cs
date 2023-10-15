using System.Text.RegularExpressions;
using task1610.Interface;

namespace task1610
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task1



            //Student student1 = new Student("Yusif", "Jalilov");
            //Student student2 = new Student("Xeyal", "Huseynov");
            //Student student3 = new Student("Samir", "Kerimov"); 

            //Console.WriteLine($"Student 1 - CodeEmail: {student1.CodeEmail}");
            //Console.WriteLine($"Student 2 - CodeEmail: {student2.CodeEmail}");

            //task2

            //int num1 = 5;
            //int num2 = 10;
            //string text1 = "Yyusif007";
            //string text2 = "fxghghvkh";


            //Console.WriteLine($"{num1} is odd: {num1.IsOdd()}");
            //Console.WriteLine($"{num2} is even: {num2.IsEven()}");
            //Console.WriteLine($"{text1} has a digit: {text1.HasDigit()}");
            //Console.WriteLine($"{text2} has a digit: {text2.HasDigit()}");


            //string capitalizedText = "yusif celilli".Capitalize();
            //Console.WriteLine(capitalizedText);


            //task3

             Group group1 = new Group("Group 1");
 Group group2 = new Group("Group 2");

 Student student1 = new Student("Yusif", "Celilli");
 Student student2 = new Student("Xeyal", "Huseynov");
 Student student3 = new Student("Kenan", "Pasayev");
 Student student4 = new Student("Samir", "Kerimov");

 group1.AddStudent(student1);
 group1.AddStudent(student2);
 group2.AddStudent(student3);
 group2.AddStudent(student4);

 Group.ShowAllGroups();

 Console.WriteLine();
 group1.ShowStudents();
 Console.WriteLine();
 group2.ShowStudents();

 Console.WriteLine();
 group1.Search("Yusif");
 group2.RemoveStudent(3);

 Console.WriteLine();
 group1.ShowStudents();
 Console.WriteLine();
 group2.ShowStudents();




        }
    }
    //task1
    //class Student : ICodeAcademy
    //{
    //    public static int Count { get; private set; } = 0;
    //    public int Id { get; private set; }
    //    public string Name { get; private set; }
    //    public string Surname { get; private set; }
    //    public string CodeEmail { get; set; }

    //    public Student(string name, string surname)
    //    {
    //        if (CheckName(name) && CheckName(surname))
    //        {
    //            Name = name;
    //            Surname = surname;
    //            Count++;
    //            Id = Count;
    //            GenerateEmail();
    //        }
    //        else
    //        {
    //            throw new ArgumentException("Invalid Name or Surname");
    //        }
    //    }

    //    public static bool CheckName(string name)
    //    {
    //        if (name.Length >= 3 && name.Length <= 25 && Regex.IsMatch(name, @"^[A-Za-z]+$"))
    //        {
    //            return true;
    //        }
    //        return false;
    //    }

    //    public void GenerateEmail()
    //    {
    //        string lowercaseName = Name.ToLower();
    //        string lowercaseSurname = Surname.ToLower();
    //        string email = $"{lowercaseName}.{lowercaseSurname}{Id}@code.edu.az";
    //        CodeEmail = email;
    //    }
    //}


    //task2



    //public static class Helper
    //    {
    //        public static bool IsOdd(this int number)
    //        {
    //            return number % 2 != 0;
    //        }

    //        public static bool IsEven(this int number)
    //        {
    //            return number % 2 == 0;
    //        }

    //        public static bool HasDigit(this string text)
    //        {
    //            return !string.IsNullOrEmpty(text) && text.Any(char.IsDigit);
    //        }

    //        public static bool CheckPassword(this string password)
    //        {
    //            if (string.IsNullOrWhiteSpace(password))
    //                return false;

    //            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
    //        }

    //        public static string Capitalize(this string text)
    //        {
    //            if (string.IsNullOrEmpty(text))
    //                return text;

    //            return char.ToUpper(text[0]) + text.Substring(1);
    //        }
    //    }



    //task3
    class Student
{
    public static int Count { get; private set; } = 0;
    public int Id { get; }
    public string Name { get; }
    public string Surname { get; }

    public Student(string name, string surname)
    {
        Id = ++Count;
        Name = name;
        Surname = surname;
    }

    public string GetInfo()
    {
        return $"Student ID: {Id}, Name: {Name}, Surname: {Surname}";
    }
}

class Group
{
    public static List<Group> Groups { get; } = new List<Group>();
    public static int GroupCount => Groups.Count;
    public int GroupId { get; }
    public string GroupName { get; }
    public List<Student> Students { get; } = new List<Student>();

    public Group(string groupName)
    {
        GroupId = Groups.Count + 1;
        GroupName = groupName;
        Groups.Add(this);
    }

    public string GetGroupInfo()
    {
        return $"Group ID: {GroupId}, Group Name: {GroupName}, Number of Members: {Students.Count}";
    }

    public Student GetStudent(int id)
    {
        return Students.Find(student => student.Id == id);
    }

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public void Search(string searchString)
    {
        Console.WriteLine($"Searching for students with names containing '{searchString}':");
        foreach (var student in Students)
        {
            if (student.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) || student.Surname.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(student.GetInfo());
            }
        }
    }

    public void RemoveStudent(int id)
    {
        Student studentToRemove = Students.Find(student => student.Id == id);
        if (studentToRemove != null)
        {
            Students.Remove(studentToRemove);
        }
    }

    public void ShowStudents()
    {
        Console.WriteLine($"Students in Group {GroupName}:");
        foreach (var student in Students)
        {
            Console.WriteLine(student.GetInfo());
        }
    }

    public static void ShowAllGroups()
    {
        Console.WriteLine("All Groups:");
        foreach (var group in Groups)
        {
            Console.WriteLine(group.GetGroupInfo());
        }
    }

    public static void AddGroup(Group group)
    {
        Groups.Add(group);
    }




}
