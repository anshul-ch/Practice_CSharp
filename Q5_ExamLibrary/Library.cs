namespace CSharp.Practice.Q5_ExamLibrary;

public interface IBook
{
    int Id { get; set; }
    string Title { get; set; }
    string Author { get; set; }
    string Category { get; set; }
    int Price { get; set; }
}

public interface ILibrarySystem
{
    void AddBook(IBook book, int quantity);
    int CalculateTotal();
    List<(string, int, int)> BooksInfo();
}

public class Book : IBook
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public int Price { get; set; }
}


public class LibrarySystem : ILibrarySystem
{
    // Stores Book → Quantity
    private Dictionary<IBook, int> books;

    public LibrarySystem()
    {
        books = new Dictionary<IBook, int>();
    }

    public void AddBook(IBook book, int quantity)
    {
        // Check if book already exists (by Id)
        IBook existingBook = books.Keys.FirstOrDefault(b => b.Id == book.Id);

        if (existingBook != null)
        {
            // Book already exists → increase quantity
            books[existingBook] += quantity;
        }
        else
        {
            // New book → add to dictionary
            books.Add(book, quantity);
        }
    }

    public int CalculateTotal()
    {
        int totalPrice = 0;

        foreach (var item in books)
        {
            totalPrice += item.Key.Price * item.Value;
        }

        return totalPrice;
    }

    public List<(string, int, int)> BooksInfo()
    {
        return books.Select(b =>
            (b.Key.Title, b.Value, b.Key.Price * b.Value)
        ).ToList();
    }
}

class Library
{
    static void Main()
    {
        ILibrarySystem librarySystem = new LibrarySystem();

        Console.WriteLine("Enter number of books:");
        int numberOfBooks = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter book details:");
        Console.WriteLine("Format: Id Title Author Category Price Quantity");

        for (int i = 0; i < numberOfBooks; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            IBook book = new Book()
            {
                Id = int.Parse(input[0]),
                Title = input[1],
                Author = input[2],
                Category = input[3],
                Price = int.Parse(input[4])
            };

            int quantity = int.Parse(input[5]);

            librarySystem.AddBook(book, quantity);
        }

        Console.WriteLine("\nBook Info:");
        var bookInfoList = librarySystem.BooksInfo();

        foreach (var info in bookInfoList)
        {
            Console.WriteLine(
                $"Book Name: {info.Item1}, Quantity: {info.Item2}, Price: {info.Item3}");
        }

        Console.WriteLine("\nTotal Price of all books:");
        Console.WriteLine(librarySystem.CalculateTotal());
    }
}
