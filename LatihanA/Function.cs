namespace LatihanA;

public class Function
{
    const double cumlaude = 3.51;
    const double sangatMemuaskan = 3.01;
    const double memuaskan = 2.76;

    public static char Grading(int scores)
    {
        if (scores >= 85)
        {
            return 'A';
        }
        else if (scores >= 70)
        {
            return 'B';
        }
        else if (scores >= 55)
        {
            return 'C';
        }
        else if (scores >= 40)
        {
            return 'D';
        }
        else
        {
            return 'E';
        }
    }

    public static int Weight(char grade)
    {
        switch (grade)
        {
            case 'A':
                return 4;
            case 'B':
                return 3;
            case 'C':
                return 2;
            case 'D':
                return 1;
            case 'E':
                return 0;
            default:
                return -1;
        }
    }

    public static double TotalGpa(int totalGradeWeight, int totalCredit)
    {
        return (double)totalGradeWeight / totalCredit;
    }

    public static void Predikat(double gpa, bool isHasE)
    {
        
        if (gpa >= cumlaude && !isHasE)
        {
            Console.WriteLine("Cumlaude");
        }
        else if (gpa >= sangatMemuaskan)
        {
            Console.WriteLine("Sangat Memuaskan");
        }
        else if (gpa >= memuaskan)
        {
            Console.WriteLine("Memuaskan");
        }
        else
        {
            Console.WriteLine("Cukup");
        }
    }

    public static void PrintTranscript(CourseData data)
    {
        Console.WriteLine("\n==============================================");
        Console.WriteLine("              Score Transcript");
        Console.WriteLine("================================================");

        for (int i = 0; i < data.TotalCourse; i++)
        {
            Console.WriteLine($"{i + 1}. {data.CourseNames[i]} | {data.CourseCredits[i]} SKS | {data.Scores[i]} - {data.Grades[i]} - {data.Weights[i]}");
        }

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"Total SKS : {data.TotalCredit}");
        Console.WriteLine($"IPK       : {data.GPA:F2}");
        Console.WriteLine();
    }

    public static void FindFailedCourse(CourseData data)
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("              Failed Courses");
        Console.WriteLine("==============================================");

        int number = 1;

        for (int i = 0; i < data.TotalCourse; i++)
        {
            if (data.Grades[i] == 'E')
            {
                Console.WriteLine(
                    $"{number}. {data.CourseNames[i]} - Score: {data.Scores[i]}"
                );

                number++;
            }
        }

        if (number == 1)
        {
            Console.WriteLine("No failed courses found.");
        }

        Console.WriteLine();
    }

    public static void FindLowHighScore(CourseData data)
    {
        int highestIndex = 0;
        int lowestIndex = 0;

        for (int i = 1; i < data.TotalCourse; i++)
        {
            if (data.Scores[i] > data.Scores[highestIndex])
            {
                highestIndex = i;
            }

            if (data.Scores[i] < data.Scores[lowestIndex])
            {
                lowestIndex = i;
            }
        }

        Console.WriteLine("==============================================");
        Console.WriteLine("           Highest & Lowest Score");
        Console.WriteLine("==============================================");

        Console.WriteLine(
            $"Highest Score: {data.CourseNames[highestIndex]} - {data.Scores[highestIndex]}"
        );

        Console.WriteLine(
            $"Lowest Score : {data.CourseNames[lowestIndex]} - {data.Scores[lowestIndex]}"
        );

        Console.WriteLine();
    }

}
