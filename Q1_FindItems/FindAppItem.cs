namespace CSharp.Practice.Q1_FindItems
{
    class FindAppItem
    {
        public static SortedDictionary<string, long> itemDetails =
            new SortedDictionary<string, long>();

        static void Main(string[] args)
        {
            // Sample input (in exam, read from Console)
            itemDetails.Add("Pen", 50);
            itemDetails.Add("Pencil", 20);
            itemDetails.Add("Eraser", 10);
            itemDetails.Add("Notebook", 100);

            // 1. Find item by sold count
            long soldCount = 20;
            var foundItems = FindItemDetails(soldCount);

            if (foundItems.Count == 0)
            {
                Console.WriteLine("Invalid sold count");
            }
            else
            {
                foreach (var item in foundItems)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
            }

            // 2. Find min and max sold items
            var minMax = FindMinandMaxSoldItems();
            Console.WriteLine("Minimum Sold Item: " + minMax[0]);
            Console.WriteLine("Maximum Sold Item: " + minMax[1]);

            // 3. Sort by count
            var sorted = SortByCount();
            foreach (var item in sorted)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        public static SortedDictionary<string, long> FindItemDetails(long soldCount)
        {
            SortedDictionary<string, long> result = new SortedDictionary<string, long>();

            foreach (var item in itemDetails)
            {
                if (item.Value == soldCount)
                {
                    result.Add(item.Key, item.Value);
                }
            }
            return result;
        }

        public static List<string> FindMinandMaxSoldItems()
        {
            List<string> result = new List<string>();

            long min = long.MaxValue;
            long max = long.MinValue;

            string minItem = "";
            string maxItem = "";

            foreach (var item in itemDetails)
            {
                if (item.Value < min)
                {
                    min = item.Value;
                    minItem = item.Key;
                }
                if (item.Value > max)
                {
                    max = item.Value;
                    maxItem = item.Key;
                }
            }

            result.Add(minItem);
            result.Add(maxItem);
            return result;
        }

        public static Dictionary<string, long> SortByCount()
        {
            Dictionary<string, long> result = new Dictionary<string, long>();

            var sorted = itemDetails.OrderBy(i => i.Value);

            foreach (var item in sorted)
            {
                result.Add(item.Key, item.Value);
            }

            return result;
        }
    }
}
