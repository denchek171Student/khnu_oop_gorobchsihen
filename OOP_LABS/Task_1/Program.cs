    struct Student
    {
        public string Name;
        public int Age;
        public string Department;
        public string Email;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter student information:");

            Student student;
            Console.Write("Name: ");
            student.Name = Console.ReadLine() ?? string.Empty;

            Console.Write("Age: ");
            student.Age = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Department: ");
            student.Department = Console.ReadLine() ?? string.Empty;

            Console.Write("Email: ");
            student.Email = Console.ReadLine() ?? string.Empty;

            WriteStudentInformationAsText(student);

            WriteStudentInformationAsStructure(student);

            Console.WriteLine("Student information has been successfully written to the file.");
            Console.ReadLine();
        }

        static void WriteStudentInformationAsText(Student student)
        {
            var filePath = "student_info.txt";

            using StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine("Name: " + student.Name);
            writer.WriteLine("Age: " + student.Age);
            writer.WriteLine("Department: " + student.Department);
            writer.WriteLine("Email: " + student.Email);
        }

        static void WriteStudentInformationAsStructure(Student student)
        {
            var filePath = "student_info.bin";

            using var writer = new BinaryWriter(File.Open(filePath, FileMode.Create));
            writer.Write(student.Name);
            writer.Write(student.Age);
            writer.Write(student.Department);
            writer.Write(student.Email);
        }
    }
