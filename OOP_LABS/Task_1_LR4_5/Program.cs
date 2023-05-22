using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class Faculty
{
    [Key]
    public int FacultyId { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Student> Students { get; set; }
}

public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    public string Name { get; set; }

    [ForeignKey("Faculty")]
    public int FacultyId { get; set; }

    public Faculty Faculty { get; set; }

    public ICollection<Grade> Grades { get; set; }
}

public class Grade
{
    [Key]
    public int GradeId { get; set; }

    [Required]
    [Range(0, 100)]
    public int Value { get; set; }

    [ForeignKey("Student")]
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
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversityDB;Integrated Security=True;");
    }
}