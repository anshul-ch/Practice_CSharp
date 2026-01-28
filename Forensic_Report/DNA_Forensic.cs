namespace CSharp.Practice.Forensic_Report;

class ForensicReport
{
    private string reportingOfficerName{get; set; }
    private DateOnly reportingDate { get; set; }
    private Dictionary<string, DateOnly> reportMap = new Dictionary<string, DateOnly>();

    public void AddReportDetails(string name, DateOnly date)
    {
        reportingOfficerName = name;
        reportingDate = date;
        reportMap.Add(reportingOfficerName, reportingDate);
    }

    public List<string> getReportDetails(DateOnly reportDate)
    {
        List<string> result = new List<string>();
        foreach (var date in reportMap)
        {
            if (date.Value == reportDate)
            {
                result.Add(date.Key);
            }
        }
        return result;
    }
}

public class DNA_Forensic
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the number of reports to be added:");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the details as OfericerName:DateofReport(in yyyy-mm-dd)");
        ForensicReport report = new ForensicReport();
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(':');
            string officername = parts[0];
            DateOnly date = DateOnly.Parse(parts[1]);
            report.AddReportDetails(officername, date);
        }
        Console.WriteLine("Enter the date to search reports(in yyyy-mm-dd):");
        DateOnly reportingdate = DateOnly.Parse(Console.ReadLine());
        List<string> reportDetails = report.getReportDetails(reportingdate);
        if (reportDetails.Count > 0)
        {
            Console.WriteLine("Reports found for the given date:");
            foreach (string name in reportDetails)
            {
                Console.WriteLine(name);
            }
        }
        else
        {
            Console.WriteLine("No reports found for the given date.");
        }
    }
}