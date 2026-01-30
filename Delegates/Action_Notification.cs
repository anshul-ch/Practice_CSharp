using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_CSharp.Delegates
{
    public class NotificationPush
    {
        public void ProcessTask<T>(T item, Action<T> action)
        {
            Console.WriteLine("Process started");
            action(item);
            Console.WriteLine("Process complete");
        }
    }

    public class PredicateList
    {
        public static List<T> FilterList<T>(List<T> items, Predicate<T> condition) 
        {
            List<T> listItems = new List<T>();
            foreach(T item in items)
            {
                if (condition(item))
                {
                    listItems.Add(item);
                }
            }
            // short using LINQ
            // result = items.Where(item => condition(item)).ToList();
            return listItems;
        }
    }
    public class Action_Notification
    {
        public static void Main(String[] args)
        {
            NotificationPush notificationPush = new NotificationPush();
            notificationPush.ProcessTask("Order123", msg => Console.WriteLine("Print the order id: "+msg));
           
            List<int> productList = new List<int>() { 1200,1500,900,10000,100,1800};
            //PredicateList.FilterList(productList, item => item > 1500);
            List<int> listItems = PredicateList.FilterList(productList, item => item > 1500);
            foreach (int product in listItems)
            {
                Console.WriteLine("Filtered Product Price: "+product);
            }
            
        }
    }
}
