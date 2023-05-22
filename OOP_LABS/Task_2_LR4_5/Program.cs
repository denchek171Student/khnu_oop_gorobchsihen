using Microsoft.EntityFrameworkCore;

namespace UniversitySystem
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }

    public class Grade
    {
        public int GradeId { get; set; }
        public int Value { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }

    public class UniversityContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Your_Connection_String");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UniversityContext())
            {
                var faculty = new Faculty { Name = "Faculty of Science" };
                context.Faculties.Add(faculty);
                context.SaveChanges();

                var student = new Student { Name = "John Doe", FacultyId = faculty.FacultyId };
                context.Students.Add(student);
                context.SaveChanges();

                var grade = new Grade { Value = 4, StudentId = student.StudentId };
                context.Grades.Add(grade);
                context.SaveChanges();

                Console.WriteLine("Дані успішно додано до бази даних.");
            }

            Console.ReadLine();
        }
    }
}