using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public string Faculty { get; set; }
}

public class Grade
{
    public string StudentName { get; set; }
    public int Score { get; set; }
}

public class UniversitySystem
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "John", Faculty = "Engineering" },
            new Student { Name = "Jane", Faculty = "Business" },
            new Student { Name = "Mark", Faculty = "Engineering" },
            new Student { Name = "Alice", Faculty = "Science" }
        };

        List<Grade> grades = new List<Grade>
        {
            new Grade { StudentName = "John", Score = 4 },
            new Grade { StudentName = "Jane", Score = 3 },
            new Grade { StudentName = "Mark", Score = 5 },
            new Grade { StudentName = "Alice", Score = 2 }
        };

        var engineeringStudents = students.Where(s => s.Faculty == "Engineering");
        Console.WriteLine("Engineering Students:");
        foreach (var student in engineeringStudents)
        {
            Console.WriteLine(student.Name);
        }
        Console.WriteLine();

        var studentsByFaculty = students.GroupBy(s => s.Faculty);
        Console.WriteLine("Students by Faculty:");
        foreach (var group in studentsByFaculty)
        {
            Console.WriteLine($"Faculty: {group.Key}");
            foreach (var student in group)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine();
        }

        var studentGrades = from student in students
                            join grade in grades on student.Name equals grade.StudentName
                            select new { student.Name, grade.Score };

        Console.WriteLine("Student Grades:");
        foreach (var sg in studentGrades)
        {
            Console.WriteLine($"Name: {sg.Name}, Score: {sg.Score}");
        }
    }
}