public interface IStudent
{
    string Name { get; set; }
    void Enroll(IFaculty faculty);
    void TakeExam(string subject, int grade);
    List<int> GetGrades();
    double GetAverageGrade();
}

public interface IFaculty
{
    string Name { get; set; }
    void AddStudent(IStudent student);
    void RemoveStudent(IStudent student);
    List<IStudent> GetStudents();
}

public interface IUniversity
{
    void AddFaculty(IFaculty faculty);
    void RemoveFaculty(IFaculty faculty);
    List<IFaculty> GetFaculties();
}

public class University : IUniversity
{
    private List<IFaculty> faculties;

    public University()
    {
        faculties = new List<IFaculty>();
    }

    public void AddFaculty(IFaculty faculty)
    {
        faculties.Add(faculty);
    }

    public void RemoveFaculty(IFaculty faculty)
    {
        faculties.Remove(faculty);
    }

    public List<IFaculty> GetFaculties()
    {
        return faculties;
    }
}

public class Student : IStudent
{
    private string name;
    private IFaculty faculty;
    private List<int> grades;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Student(string name)
    {
        this.name = name;
        grades = new List<int>();
    }

    public void Enroll(IFaculty faculty)
    {
        this.faculty = faculty;
    }

    public void TakeExam(string subject, int grade)
    {
        grades.Add(grade);
    }

    public List<int> GetGrades()
    {
        return grades;
    }

    public double GetAverageGrade()
    {
        if (grades.Count == 0)
            return 0;

        int sum = 0;
        foreach (int grade in grades)
        {
            sum += grade;
        }
        return (double)sum / grades.Count;
    }
}

public class Faculty : IFaculty
{
    private string name;
    private List<IStudent> students;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Faculty(string name)
    {
        this.name = name;
        students = new List<IStudent>();
    }

    public void AddStudent(IStudent student)
    {
        students.Add(student);
    }

    public void RemoveStudent(IStudent student)
    {
        students.Remove(student);
    }

    public List<IStudent> GetStudents()
    {
        return students;
    }
}

public class Teacher
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Teacher(string name)
    {
        this.name = name;
    }

    public List<IStudent> GetStudents(IFaculty faculty)
    {
        return faculty.GetStudents();
    }

    public void AssignGrade(IStudent student, string subject, int grade)
    {
        student.TakeExam(subject, grade);
    }

    public void ExpelStudent(IStudent student)
    {
        student.Enroll(null);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IUniversity university = new University();

        IFaculty faculty = new Faculty("Computer Science");
        university.AddFaculty(faculty);

        IStudent student1 = new Student("John Doe");
        student1.Enroll(faculty);
        faculty.AddStudent(student1);

        IStudent student2 = new Student("Jane Smith");
        student2.Enroll(faculty);
        faculty.AddStudent(student2);

        Teacher teacher = new Teacher("Professor Johnson");

        List<IStudent> studentsOnFaculty = teacher.GetStudents(faculty);
        Console.WriteLine("Students on faculty: ");
        foreach (IStudent student in studentsOnFaculty)
        {
            Console.WriteLine(student.Name);
        }

        teacher.AssignGrade(student1, "Math", 4);
        teacher.AssignGrade(student1, "English", 5);
        teacher.AssignGrade(student2, "Math", 3);
        teacher.AssignGrade(student2, "English", 4);

        List<int> grades = student1.GetGrades();
        Console.WriteLine("Grades for student1: ");
        foreach (int grade in grades)
        {
            Console.WriteLine(grade);
        }

        Console.WriteLine("Average grade for student1: " + student1.GetAverageGrade());
    }
}