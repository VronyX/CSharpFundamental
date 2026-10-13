namespace LatihanA;

public class Menu
{
    public static void InputCourse()
    {
        int totalCourse = 0;

        while (totalCourse < 1 || totalCourse > 8)
        {
            Console.Write("Please input total course (1-8): ");
            totalCourse = Convert.ToInt32(Console.ReadLine());
        }

        string[] courseNames = new string[8];
        int[] courseCredits = new int[8];
        int[] scores = new int[8];
        char[] grades = new char[8];
        int[] weights = new int[8];

        int totalCredit = 0;
        int totalGradeWeight = 0;
        bool isHasE = false;

        for (int i = 0; i < totalCourse; i++)
        {
            Console.Write($"#{i + 1} Course name: ");
            courseNames[i] = Console.ReadLine();

            while (courseCredits[i] < 1 || courseCredits[i] > 4)
            {
                Console.Write("Credit hours (1-4): ");
                courseCredits[i] = Convert.ToInt32(Console.ReadLine());
            }

            totalCredit += courseCredits[i];

            do
            {
                Console.Write("Course score (0-100): ");
                scores[i] = Convert.ToInt32(Console.ReadLine());
            }
            while (scores[i] < 0 || scores[i] > 100);

            // Mengubah angka menjadi grade huruf
            grades[i] = Function.Grading(scores[i]);

            if (grades[i] == 'E')
            {
                isHasE = true;
            }

            // Mengubah huruf menjadi bobot nilai gpa
            weights[i] = Function.Weight(grades[i]);

            // Hitung total bobot x SKS
            totalGradeWeight += courseCredits[i] * weights[i];
        }

        double GPA = Function.TotalGpa(totalGradeWeight, totalCredit);

        Console.WriteLine("==================");
        Console.WriteLine($"GPA: {GPA:F2}");
        Console.WriteLine();

        // print predikat
        Function.Predikat(GPA, isHasE);
        Console.WriteLine();

        string menuChoice = "";

        while (menuChoice != "Y" && menuChoice != "N")
        {
            Console.Write("Do you want to see other options? (Y/N): ");
            menuChoice = Console.ReadLine().Trim().ToUpper();
        }

        if (menuChoice == "Y")
        {
            Console.Clear();

            CourseData data = new CourseData
            {
                TotalCourse = totalCourse,
                CourseNames = courseNames,
                CourseCredits = courseCredits,
                Scores = scores,
                Grades = grades,
                Weights = weights,
                TotalCredit = totalCredit,
                GPA = GPA
            };

            Options(data);
        }
    }

    public static void Options(CourseData data)
    {
        string choice;
        string menuChoice = "Y";

        do
        {
            OptionMenu();
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();

                    Function.PrintTranscript(data);
                    break;

                case "2":
                    Console.Clear();

                    Function.FindFailedCourse(data);
                    break;
                case "3":
                    Console.Clear();

                    Function.FindLowHighScore(data);
                    break;

                case "4":
                    menuChoice = "N";
                    Console.WriteLine("Returning to main menu...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    continue;
            }

            if (choice is "1" or "2" or "3")
            {
                do
                {
                    Console.Write("Do you want to see other options? (Y/N): ");
                    menuChoice = Console.ReadLine().Trim().ToUpper();
                }
                while (menuChoice != "Y" && menuChoice != "N");

                Console.Clear();
            }

        } while (menuChoice == "Y");
    }

    static void OptionMenu()
    {
        Console.WriteLine("========================");
        Console.WriteLine("1. Print Transcript");
        Console.WriteLine("2. Check Failed Course");
        Console.WriteLine("3. Check Highest and Lowest Course");
        Console.WriteLine("4. Exit");
        Console.Write("Select: ");
    }
}
