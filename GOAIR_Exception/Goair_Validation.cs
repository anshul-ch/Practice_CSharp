using System;

namespace CSharp.Practice.GOAIR_Exception
{
    class InvalidEntryValidationException : Exception
    {
        public InvalidEntryValidationException(string message)
            : base(message)
        {
        }
    }
    class EntryUtility
    {
        public static void ValidateEmployeeID(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 10 || !id.StartsWith("GOAIR/"))
            {
                throw new InvalidEntryValidationException("Invalid entry details");
            }

            string digits = id.Substring(6);
            foreach (char c in digits)
            {
                if (!char.IsDigit(c))
                {
                    throw new InvalidEntryValidationException("Invalid entry details");
                }
            }
        }

        public static void ValidateDuration(int hours)
        {
            if (hours < 1 || hours >= 6)
            {
                throw new InvalidEntryValidationException("Invalid entry details");
            }
        }
    }

    public class Goair_Validation
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of entries");
            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                try
                {
                    Console.WriteLine($"Enter entry {i} details");
                    string input = Console.ReadLine();

                    string[] parts = input.Split(':');
                    string empId = parts[0];
                    int duration = int.Parse(parts[2]);

                    EntryUtility.ValidateEmployeeID(empId);
                    EntryUtility.ValidateDuration(duration);
                    Console.WriteLine("Valid entry details");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
