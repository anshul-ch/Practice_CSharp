namespace CSharp.Practice.Q4_NumberGrade
{
    /// <summary>
    /// Calculates the grades based on GPA,
    /// uses the Implement of Linq and Collections(List)
    /// </summary>
    class CalculateGrades
    {
        // GIVEN in question template
        public static List<int> NumberList = new List<int>();

        static void Main(string[] args)
        {
            // ----------- INPUT SECTION -----------
            Console.WriteLine("Enter marks separated by comma:");
            string input = Console.ReadLine();

            // Split input by comma
            string[] values = input.Split(',');

            // Convert and add to NumberList
            foreach (string val in values)
            {
                int number = int.Parse(val.Trim());
                AddNumbers(number);
            }

            // ----------- GPA CALCULATION -----------
            double gpa = GetGPAScored();

            if (gpa == -1)
            {
                Console.WriteLine("No Numbers Available");
                return;
            }

            // ----------- GRADE CALCULATION -----------
            char grade = GetGradeScored(gpa);

            if (grade == '\0')
            {
                Console.WriteLine("Invalid GPA");
            }
            else
            {
                Console.WriteLine("GPA: " + gpa);
                Console.WriteLine("Grade: " + grade);
            }
        }

        // -----------------------------------------
        // Adds one number to NumberList
        // -----------------------------------------
        public static void AddNumbers(int Numbers)
        {
            NumberList.Add(Numbers);
        }

        // -----------------------------------------
        // GPA = (sum of (mark * 3)) / (count * 3)
        // -----------------------------------------
        public static double GetGPAScored()
        {
            if (NumberList.Count == 0)
            {
                return -1;
            }

            int sum = 0;
            foreach (int num in NumberList)
            {
                sum += num;
            }

            return (double)sum / (NumberList.Count * 100) * 10;
        }

        // -----------------------------------------
        // Grade calculation
        // -----------------------------------------
        public static char GetGradeScored(double gpa)
        {
            if (gpa < 5 || gpa > 10)
                return '\0';

            if (gpa == 10)
                return 'S';
            else if (gpa >= 9)
                return 'A';
            else if (gpa >= 8)
                return 'B';
            else if (gpa >= 7)
                return 'C';
            else if (gpa >= 6)
                return 'D';
            else
                return 'E';
        }
    }
}
