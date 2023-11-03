using StockManagement.Domain.General.Data_types;
using StockManagement.Domain.OrderManagement;
using StockManagement.Domain.ProductManagement;
using StockManagement.Stock.Data_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Domain
{
    internal class Util
    {
        private static string directory = @"C:\Users\marti\source\repos\StockManagement\StockManagement\Domain\Data\";
        private static string productsFile = "products.txt";

        public static List<Order> orders = new List<Order>();
        public static List<Product> inventory = new List<Product>();
        
        internal static void InitializeStock() //Mock implementation
        {
            Product p1 = new(1, "Sugar", "Lorem ipsum", new Price() 
            { 
                ItemPrice = 
                  10, 
                Currency = Currency.Euro
            }, UnitType.PerKg, 100);
            
            Product p2 = new(2, "Cake Decorations", "Lorem ipsum", new Price()
            {
                ItemPrice =
                  8,
                Currency = Currency.Euro
            }, UnitType.PerItem, 20);
            
            Product p3 = new(3, "Strawberry", "Lorem ipsum", new Price()
            {
                ItemPrice =
                  3,
                Currency = Currency.Euro
            }, UnitType.PerBox, 10);

            inventory.Add(p1);
            inventory.Add(p2);
            inventory.Add(p3);

            /*
            try
            {
                string path = $"{directory}{productsFile}";
                if(File.Exists(path))
                {
                    inventory.Clear();

                    string[] stockAsString = File.ReadAllLines(path);
                    for (int i = 0; i < stockAsString.Length; i++)
                    {
                        string[] stockSplits = stockAsString[i].Split(';');
                        string id = stockSplits[0].Substring(stockSplits[0].IndexOf(':') + 1);
                        string name = stockSplits[1].Substring(stockSplits[1].IndexOf(':') + 1);
                        string description = stockSplits[2].Substring(stockSplits[2].IndexOf(':') + 1);
                        string price = stockSplits[3].Substring(stockSplits[3].IndexOf(':') + 1);
                        string unitType = stockSplits[4].Substring(stockSplits[4].IndexOf(':') + 1);
                        string maxStock = stockSplits[5].Substring(stockSplits[5].IndexOf(':') + 1);

                        Product product = null;

                        
                    }

                }
                */
        
        }

        public static void ActionMenu()
        {
            bool exitApp = false;
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("********************");
            Console.WriteLine("* Select an option *");
            Console.WriteLine("********************");
            Console.ResetColor();

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?:");
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n1: Inventory management");
                Console.WriteLine($"\n2: Order management");
                Console.WriteLine($"\n3: Settings");
                Console.WriteLine($"\n4: Save all data");
                Console.WriteLine($"\n0: Close application");
                Console.ResetColor();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "0":
                        exitApp = true;
                        break;
                }
            } while (!exitApp);



        }
        private static void ShowOpenOrderOverview()
        {
            //Check to handle fulfilled orders
            ShowFullFilledOrders();

            if(orders.Count > 0)
            {
                Console.WriteLine("Open orders:");

                foreach (var order in orders)
                {
                    Console.WriteLine(order.ShowOrderDetails());
                    Console.WriteLine();
                }
            }
            else { Console.WriteLine("There are no open orders"); }

            Console.ReadLine();
        }

        private static void ShowChangeStockThreshold()
        {
            Console.WriteLine($"Enter the new stock threshold (current value: {Product.StockThreshold})." +
                $"This applies to all products!");
            Console.Write("New value: ");
            int newValue = int.Parse( Console.ReadLine() ?? "0" );
            Product.StockThreshold = newValue;
            Console.WriteLine($"New stock threshold set to {Product.StockThreshold}");

            foreach (var product in inventory) 
            {
                product.UpdateLowStock();
            }

            Console.ReadLine();
        }

        private static void ShowFullFilledOrders()
        {
            throw new NotImplementedException();
        }
    }
}
