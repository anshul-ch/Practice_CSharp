namespace CSharp.Practice.Apartment;

class ApartmentDetails
{
    /// <summary>
    /// Takes the user input for apartment details and stores them in a dictionary.
    /// </summary>
    private string apartmentName { get; set; }
    private double apartmentRent { get; set; }
    private Dictionary<string, double> apartmentMap = new Dictionary<string, double>();
    public void addDepartmentDetails(string apartmentID, double rentAmount)
    {
       apartmentName = apartmentID;
       apartmentRent = rentAmount;
        apartmentMap[apartmentName] = apartmentRent;
    }
    /// <summary>
    /// Gets all the apartments whose rent amount is between the given range.
    /// </summary>
    /// <param name="minREnt"></param>
    /// <param name="maxRent"></param>
    /// <returns>total sum of rents</returns>
    public double TotalAmountRentBetweenRange(double minREnt, double maxRent)
    {
        double sum = 0;
        foreach (var apartment in apartmentMap)
        {
            if (apartment.Value >= minREnt && apartment.Value <= maxRent)
            {
                sum += apartment.Value;
            }
        }

        return sum;
    }
}

public class Apartment_Invent
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the number of apartments to be added:");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the details as ApartName:RentAmount");
        ApartmentDetails apartment = new ApartmentDetails();
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(':');
            string apartname = parts[0];
            double rentamount = double.Parse(parts[1]);
            apartment.addDepartmentDetails(apartname, rentamount);
        }
        Console.WriteLine("Enter the minimum and maximum rent amount to filter:");
        double minrent = double.Parse(Console.ReadLine());
        double maxrent = double.Parse(Console.ReadLine());
        double totalRent = apartment.TotalAmountRentBetweenRange(minrent, maxrent);
        if (totalRent > 0)
        {
            Console.WriteLine("Total rent amount between the given range: " + totalRent);
        }
        else
        {
            Console.WriteLine("No apartments found in the given range.");
        }
    }
}