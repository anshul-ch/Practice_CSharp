namespace CSharp.Practice.Warranty_Check;

public class InvalidGadgetException : Exception
{
    public InvalidGadgetException(string message) : base(message)
    {
        
    }
}

public class GadgetUtility
{
    public static bool validGadgetID(string gadgetID)
    {
        if (string.IsNullOrEmpty(gadgetID) || gadgetID.Length != 4 ||
            !char.IsUpper(gadgetID[0])
            || !char.IsDigit(gadgetID[1])
            || !char.IsDigit(gadgetID[2])
            || !char.IsDigit(gadgetID[3]))
        {
            throw new InvalidGadgetException("Invalid gadget ID");
        }

        return true;
    }

    public static bool validGadgetWarranty(int months)
    {
        if (months < 6 || months >= 37)
        {
            throw new InvalidGadgetException("Invalid Warranty Period");
        }

        return true;
    }
}


public class Gadget_Inventory
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the number of gadgets");
        int number = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            try
            {
                Console.WriteLine("Enter gadget details:");
                string input = Console.ReadLine();
                string[] parts = input.Split(':');
                string gadgetID = parts[0];
                int warrantyPeriod = Convert.ToInt32(parts[2]);
                GadgetUtility.validGadgetID(gadgetID);
                GadgetUtility.validGadgetWarranty(warrantyPeriod);
                Console.WriteLine("Gadget details are valid");
            }
            catch (InvalidGadgetException ex)
            {
                Console.WriteLine(ex.Message);
                //i--;
            }
        }
    }
}