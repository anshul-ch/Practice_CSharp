namespace CSharp.Practice.Bake_Cake
{
    /// <summary>
    /// Takes Order info and stores in Dictionary and
    /// perform sorting based on pricing and returns the order details.
    /// </summary>
    class CakeOrder
    {
        private Dictionary<string, double> orderMap = new Dictionary<string, double>();
        public void AddOrderDetails(string orderID, double cakeCost)
        {
            orderMap[orderID] = cakeCost;
        }
        /// <summary>
        /// To get the order details based on pricing
        /// </summary>
        /// <param name="cakeCost"></param>
        /// <returns>a dictionary containing the filtered orders</returns>
        public Dictionary<string, double> FindOrdersAboveSpecificCost(double cakeCost)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            foreach (var order in orderMap)
            {
                if (order.Value > cakeCost)
                {
                    result[order.Key] = order.Value;
                }
            }
            return result;
        }
    }

    public class Bake_Inventory
    {
        public static void Main(string[] args)
        {
            int number = 3;
            CakeOrder cakeOrder = new CakeOrder();
            Console.WriteLine("Enter the cake details (OrderID:CakeCost):");
            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                string[] inputArr = input.Split(':');

                if (inputArr.Length != 2 || 
                    !double.TryParse(inputArr[1], out double cost))
                {
                    Console.WriteLine("Invalid input format. Use OrderID:CakeCost");
                    i--;
                    continue;
                }

                cakeOrder.AddOrderDetails(inputArr[0], cost);
            }
            Console.WriteLine("Enter the cake cost to filter the orders:");
            double filterCost = double.Parse(Console.ReadLine());

            Dictionary<string, double> filteredOrders =
                cakeOrder.FindOrdersAboveSpecificCost(filterCost);

            if (filteredOrders.Count == 0)
            {
                Console.WriteLine("No orders found");
            }
            else
            {
                Console.WriteLine("Orders above the specified cost:");
                foreach (var order in filteredOrders)
                {
                    Console.WriteLine(order.Key + " : " + order.Value);
                }
            }
        }
    }
}
