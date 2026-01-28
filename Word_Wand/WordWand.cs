namespace CSharp.Practice.Word_Wand;

public class WordWand
{
    /// <summary>
    /// takes user input and gets output based on even or odd number of words.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the word to get it's output constraints:");
        string input = Console.ReadLine();
        if (input.All(c => char.IsLetter(c) || c == ' '))
        {
            WordReverse(input);
        }
        else
        {
            Console.WriteLine("Invalid Sentence");
        }
    }

    /// <summary>
    /// Displays the reversed sentence if even number of words,
    /// else reverses each word at the same position.
    /// </summary>
    /// <param name="str"></param>
    public static void WordReverse(string str)
    {
        string[] inputArray = str.Split(' ');
        if (inputArray.Length % 2 == 0)
        {
            ReverseArray(inputArray);
        }
        else
        {
            ReverseAtSamePosition(inputArray);
        }
    }
    /// <summary>
    /// Reverses the entire array of words.
    /// </summary>
    /// <param name="arr"></param>
    public static void ReverseArray(string[] arr)
    {
        Array.Reverse(arr);
        Console.WriteLine("Reversed Sentence: " + string.Join(" ", arr));
    }

    /// <summary>
    /// Reverses each word at the same position.
    /// </summary>
    /// <param name="arr"></param>
    public static void ReverseAtSamePosition(string[] arr)
    {
        string result = "";
        foreach (string str in arr)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            result += new string(charArray) + " ";
        }
        Console.WriteLine("Reversed Words at Same Position: " + result.Trim());
    }
}