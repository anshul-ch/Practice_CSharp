namespace CSharp.Practice.Password_Generator
{
    /// <summary>
    /// Takes the userinput username and generates a password if the username is valid
    /// </summary>
    public class Generator_password
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter a username: ");
            string username = Console.ReadLine();

            if (!ValidUserName(username))
            {
                Console.WriteLine(username + " is an Invalid username.");
                return;
            }
            GeneratePasscode(username);
        }
        /// <summary>
        /// Checks if the username is valid based on specified criteria
        /// </summary>
        /// <param name="username"></param>
        /// <returns>whether the username is valid (true or false)</returns>
        public static bool ValidUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 8)
                return false;

            char[] userArray = username.ToCharArray();

            // First 4 characters must be uppercase letters
            for (int i = 0; i < 4; i++)
            {
                if (!char.IsUpper(userArray[i]))
                    return false;
            }

            // 5th character must be '@'
            if (userArray[4] != '@')
                return false;

            // Remaining characters must be digits
            string numberPart = username.Substring(5);

            if (!int.TryParse(numberPart, out int number))
                return false;

            // Number range check
            if (number < 101 || number > 115)
                return false;

            return true;
        }

        public static void GeneratePasscode(string username)
        {
            string password = "TECH_";
            char[] userArray = username.ToCharArray();

            // ASCII sum of first 4 characters
            int sum = 0;
            char[] lowerCase = new char[4];
            for (int i = 0; i < 4; i++)
            {
                lowerCase[i] += char.ToLower(userArray[i]);
                sum += (int)lowerCase[i];
            }
            password += sum;

            // Get last 2 digits of numeric part
            string numberPart = username.Substring(5);
            string lastTwoDigits = numberPart.Substring(numberPart.Length - 2);

            password += lastTwoDigits;

            Console.WriteLine("Generated Password: " + password);
        }
    }
}
