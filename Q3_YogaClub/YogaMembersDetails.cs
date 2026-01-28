using System.Collections;

namespace CSharp.Practice.Q3_YogaClub
{
    /// <summary>
    ///   COntains the properties to be assigned to a user.
    /// </summary>
    public class YogaMembers
    {
        public int MemeberId { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMI { get; set; }
    }

    public class YogaMembersDetails
    {
        public static ArrayList memberList = new ArrayList();

        public static void Main(String[] args)
        {
            // add members to arraylist
            AddMember("101,25,55,1.6");
            AddMember("102,30,80,1.7");

            // calculate BMI

            foreach (Object obj in memberList)
            {
                YogaMembers yogaMembers = (YogaMembers)obj;

                double bmi = CalculateBMI(yogaMembers.Height, yogaMembers.Weight);
                double fee = CalculateFee(yogaMembers.BMI, yogaMembers.Age);
                yogaMembers.BMI = bmi;
                Console.WriteLine($"{yogaMembers.MemeberId} |  BMI : {bmi:F2} | Fee: {fee}");
            }
        }
        // Add members to the Array list
        public static void AddMember(string details)
        {
            string[] data = details.Split(",");
            YogaMembers members = new YogaMembers();
            members.MemeberId = int.Parse(data[0]);
            members.Age = int.Parse(data[1]);
            members.Weight = double.Parse(data[2]);
            members.Height = double.Parse(data[3]);

            memberList.Add(members);
        }
        // function for BMI calculation
        public static double CalculateBMI(double height, double weight)
        {
            return weight / (height * weight);
        }
        /// <summary>
        /// Calculates the fee
        /// </summary>
        /// <param name="bmi"></param>
        /// <param name="age"></param>
        /// <returns></returns>

        public static int CalculateFee(double bmi, int age)
        {
            int fee = 0;

            if (age < 30)
            {
                if (bmi < 18.5)
                    fee = 1500;
                else if (bmi <= 24.9)
                    fee = 1200;
                else
                    fee = 1000;
            }
            else
            {
                if (bmi < 18.5)
                    fee = 2000;
                else if (bmi <= 24.9)
                    fee = 1500;
                else
                    fee = 1300;
            }

            return fee;
        }
    }
}
