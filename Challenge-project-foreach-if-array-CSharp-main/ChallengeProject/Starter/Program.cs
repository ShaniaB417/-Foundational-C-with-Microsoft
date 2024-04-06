/* 
This C# console application is designed to:
- Use arrays to store student names and assignment scores.
- Use a `foreach` statement to iterate through the student names as an outer program loop.
- Use an `if` statement within the outer loop to identify the current student name and access that student's assignment scores.
- Use a `foreach` statement within the outer loop to iterate though the assignment scores array and sum the values.
- Use an algorithm within the outer loop to calculate the average exam score for each student.
- Use an `if-elseif-else` construct within the outer loop to evaluate the average exam score and assign a letter grade automatically.
- Integrate extra credit scores when calculating the student's final score and letter grade as follows:
    - detects extra credit assignments based on the number of elements in the student's scores array.
    - divides the values of extra credit assignments by 10 before adding extra credit scores to the sum of exam scores.
- use the following report format to report student grades: 

    Student         Grade

    Sophia:         92.2    A-
    Andrew:         89.6    B+
    Emma:           85.6    B
    Logan:          91.2    A-
*/
using System;

class Program
{
    static void Main()
    {
        int examAssignments = 5;

        string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

        int[][] studentScores = new int[][]
        {
            new int[] { 90, 86, 87, 98, 100, 94, 90 },
            new int[] { 92, 89, 81, 96, 90, 89 },
            new int[] { 90, 85, 87, 98, 68, 89, 89, 89 },
            new int[] { 90, 95, 87, 88, 96, 96 }
        };

        Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit\n");

        for (int i = 0; i < studentNames.Length; i++)
        {
            string currentStudent = studentNames[i];
            int[] currentStudentScores = studentScores[i];

            int sumExamScores = 0;
            int sumExtraCreditScores = 0;
            int gradedAssignments = 0;

            foreach (int score in currentStudentScores)
            {
                gradedAssignments += 1;

                if (gradedAssignments <= examAssignments)
                    sumExamScores += score;
                else
                    sumExtraCreditScores += score;
            }

            // Calculate average for exam scores and extra credit scores
            decimal averageExamScore = (decimal)sumExamScores / examAssignments;

            // Calculate final numeric score
            decimal finalNumericScore = (sumExamScores + (sumExtraCreditScores / 10)) / examAssignments;

            // Calculate extra credit points earned
            decimal extraCreditPointsEarned = sumExtraCreditScores / 10;

            // Calculate overall grade
            char overallGrade = GetOverallGrade(finalNumericScore);

            // Output formatting
            Console.WriteLine($"{currentStudent,-10}{averageExamScore,8:F1}\t{finalNumericScore,8:F2}\t{overallGrade}\t{sumExtraCreditScores} ({extraCreditPointsEarned:F2} pts)");
        }

        // Required for running in VS Code (keeps the Output windows open to view results)
        Console.WriteLine("\nPress Enter to continue");
        Console.ReadLine();
    }

    // Function to get the overall grade based on the final numeric score
    static char GetOverallGrade(decimal finalNumericScore)
    {
        if (finalNumericScore >= 97)
            return 'A';
        else if (finalNumericScore >= 93)
            return 'A';
        else if (finalNumericScore >= 90)
            return 'A';
        else if (finalNumericScore >= 87)
            return 'B';
        else if (finalNumericScore >= 83)
            return 'B';
        else if (finalNumericScore >= 80)
            return 'B';
        else if (finalNumericScore >= 77)
            return 'C';
        else if (finalNumericScore >= 73)
            return 'C';
        else if (finalNumericScore >= 70)
            return 'C';
        else if (finalNumericScore >= 67)
            return 'D';
        else if (finalNumericScore >= 63)
            return 'D';
        else if (finalNumericScore >= 60)
            return 'D';
        else
            return 'F';
    }
}
