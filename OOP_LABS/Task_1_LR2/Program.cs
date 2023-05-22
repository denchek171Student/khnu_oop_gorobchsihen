
public class University
{
    private List<Student> students;
    private List<Faculty> faculties;

    public University()
    {
        students = new List<Student>();
        faculties = new List<Faculty>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        students.Remove(student);
    }

    public void AddFaculty(Faculty faculty)
    {
        faculties.Add(faculty);
    }

    public void RemoveFaculty(Faculty faculty)
    {
        faculties.Remove(faculty);
    }

    public List<Student> GetStudents()
    {
        return students;
    }

    public List<Faculty> GetFaculties()
    {
        return faculties;
    }
}

public class Student
{
    private string name;
    private Faculty faculty;
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

    public void Enroll(Faculty faculty)
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

public class Faculty
{
    private string name;
    private List<Student> students;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Faculty(string name)
    {
        this.name = name;
        students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        students.Remove(student);
    }

    public List<Student> GetStudents()
    {
        return students;
    }
}

public class Teacher
{
    private string name;
    private Faculty faculty;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Teacher(string name)
    {
        this.name = name;
    }

    public List<Student> GetStudents(Faculty faculty)
    {
        return faculty.GetStudents();
    }

    public void AssignGrade(Student student, string subject, int grade)
    {
        student.TakeExam(subject, grade);
    }

    public void ExpelStudent(Student student)
    {
        student.Enroll(null);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        University university = new University();

        Faculty faculty = new Faculty("Computer Science");
        university.AddFaculty(faculty);

        Student student1 = new Student("John Doe");
        student1.Enroll(faculty);
        university.AddStudent(student1);

        Student student2 = new Student("Jane Smith");
        student2.Enroll(faculty);
        university.AddStudent(student2);

        Teacher teacher = new Teacher("Professor Johnson");

        List<Student> studentsOnFaculty = teacher.GetStudents(faculty);
        Console.WriteLine("Students on faculty: ");
        foreach (Student student in studentsOnFaculty)
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