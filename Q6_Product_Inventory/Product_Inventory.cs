namespace CSharp.Practice.Q6_Product_Inventory;

public interface IProduct
{
    string Name { get; set; }
    string Category { get; set; }
    int Stock { get; set; }
    int Price { get; set; }
}

interface IInventory
{
    void Addproduct(IProduct product);
    void RemoveProduct(IProduct product);
    int CalculateTotalValue();
    List<string> GetProductByCategory(string category);
    List<(string, int)> GetProductsByCategoryWithCount();
    List<string> GetProductsByName(string name);
    List<(string, List<string> Products)> GetAllProductsByCategory();
}

public class Product : IProduct
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
}

public class Inventory : IInventory
{
    private List<IProduct> _products;
    public Inventory()
    {
        _products = new List<IProduct>();
    }
    public void Addproduct(IProduct product)
    {
        _products.Add(product);
    }

    public void RemoveProduct(IProduct product)
    {
        _products.Remove(product);
    }

    public int CalculateTotalValue()
    {
        int total = 0;

        foreach (var product in _products)
        {
            total += product.Price * product.Stock;
        }

        return total;
    }

    public List<(string, int)> GetProductsByCategoryWithCount()
    {
        return _products.GroupBy(p => p.Category)
            .Select(g =>(g.Key, g.Count())).ToList();
    }

    public List<string> GetProductByCategory(string category)
    {
        return _products.Where(p => p.Category == category).Select(p => p.Name).ToList();
    }

    public List<string> GetProductsByName(string name)
    {
        return _products.Where(p => p.Name == name).Select(p => p.Name).ToList();
    }

    public List<(string, List<string>Products)> GetAllProductsByCategory()
    {
        return _products.GroupBy(p => p.Category)
            .Select(g => (g.Key, g.Select(p => p.Name).ToList())).ToList();
    }
}

public class Product_Inventory
{
    public static void Main(String[] args)
    {
        IInventory invnetory = new Inventory();
        IProduct product1 = new Product()
        {
            Category = "Samsung",
            Name = "Samsung",
            Stock = 5,
            Price = 15
        };
        IProduct product2 = new Product()
        {
            Category = "Samsung",
            Name = "Hello",
            Stock = 5,
            Price = 15
        };
        IProduct product3 = new Product()
        {
            Category = "Apple",
            Name = "Apple",
            Stock = 50,
            Price = 150
        };
        invnetory.Addproduct(product1);
        invnetory.Addproduct(product2);
        invnetory.Addproduct(product3);
        
        // View Product by Category
        var categoryProduct = invnetory.GetProductByCategory("Samsung");
        foreach (var products in categoryProduct)
        {
            Console.WriteLine(products);
        }
        
    }
}