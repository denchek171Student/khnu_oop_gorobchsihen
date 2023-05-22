using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int FacultyId { get; set; }
}

class Faculty
{
    public int FacultyId { get; set; }
    public string Name { get; set; }
}

class Grade
{
    public int StudentId { get; set; }
    public int ExamId { get; set; }
    public int Score { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var students = new List<Student>
        {
            new Student { StudentId = 1, Name = "John", FacultyId = 1 },
            new Student { StudentId = 2, Name = "Jane", FacultyId = 2 },
            new Student { StudentId = 3, Name = "Mike", FacultyId = 1 },
            new Student { StudentId = 4, Name = "Emily", FacultyId = 3 }
        };

        var faculties = new List<Faculty>
        {
            new Faculty { FacultyId = 1, Name = "Engineering" },
            new Faculty { FacultyId = 2, Name = "Science" },
            new Faculty { FacultyId = 3, Name = "Arts" }
        };

        var grades = new List<Grade>
        {
            new Grade { StudentId = 1, ExamId = 1, Score = 4 },
            new Grade { StudentId = 1, ExamId = 2, Score = 3 },
            new Grade { StudentId = 2, ExamId = 1, Score = 5 },
            new Grade { StudentId = 2, ExamId = 2, Score = 4 },
            new Grade { StudentId = 3, ExamId = 1, Score = 3 },
            new Grade { StudentId = 3, ExamId = 2, Score = 2 },
            new Grade { StudentId = 4, ExamId = 1, Score = 4 },
            new Grade { StudentId = 4, ExamId = 2, Score = 5 }
        };

        var studentsWithLowGrades = students.Where(s => grades.Any(g => g.StudentId == s.StudentId && g.Score < 3));
        Console.WriteLine("Students with low grades:");
        foreach (var student in studentsWithLowGrades)
        {
            Console.WriteLine(student.Name);
        }
        Console.WriteLine();

        var groupedStudentsByFaculty = students.GroupBy(s => s.FacultyId);
        Console.WriteLine("Students grouped by faculty:");
        foreach (var group in groupedStudentsByFaculty)
        {
            var facultyName = faculties.FirstOrDefault(f => f.FacultyId == group.Key)?.Name;
            Console.WriteLine($"Faculty: {facultyName}");
            foreach (var student in group)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine();
        }

        var joinedData = students.Join(faculties, s => s.FacultyId, f => f.FacultyId, (s, f) => new { Student = s, Faculty = f });
        Console.WriteLine("Joined data:");
        foreach (var data in joinedData)
        {
            Console.WriteLine($"Student: {data.Student.Name}, Faculty: {data.Faculty.Name}");
        }
        Console.WriteLine();

        var studentWithMaxGrade = students.OrderByDescending(s => grades.Where(g => g.StudentId == s.StudentId).Max(g => g.Score)).FirstOrDefault();
        var studentWithMinGrade = students.OrderByDescending(s => grades.Where(g => g.StudentId == s.StudentId).Min(g => g.Score)).FirstOrDefault();
        Console.WriteLine($"Student with maximum grade: {studentWithMaxGrade.Name}");
        Console.WriteLine($"Student with minimum grade: {studentWithMinGrade.Name}");

        Console.ReadLine();
    }
}