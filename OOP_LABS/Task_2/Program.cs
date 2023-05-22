class Program
{
    static void Main()
    {
        CreateDonorsFile();

        PrintFemaleDonorsWithBloodTypeIV();
    }

    static void CreateDonorsFile()
    {
        string filePath = "donors.txt";

        string[] donorsData = {
            "Ivanov, M, 1980, AB",
            "Petrova, F, 1995, IV",
            "Smith, M, 1985, O",
            "Johnson, F, 1990, IV",
            "Gonzalez, M, 1992, A",
            "Hernandez, F, 1978, IV"
        };

        File.WriteAllLines(filePath, donorsData);

        Console.WriteLine("Donors file created.");
    }

    static void PrintFemaleDonorsWithBloodTypeIV()
    {
        string filePath = "donors.txt";

        var donorsData = File.ReadAllLines(filePath);

        Console.WriteLine("Surnames of female donors with blood type IV:");

        foreach (string donorData in donorsData)
        {
            var donorInfo = donorData.Split(',');

            string surname = donorInfo[0].Trim();
            string gender = donorInfo[1].Trim();
            string bloodType = donorInfo[3].Trim();

            if (gender == "F" && bloodType == "IV")
            {
                Console.WriteLine(surname);
            }
        }
    }
}