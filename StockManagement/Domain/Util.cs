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

        public static void WelcomeText()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome to Stock Management");
            Console.WriteLine($"Press enter key to start logging in!");
            Console.ReadLine();
            Console.ResetColor();
        }

        public static void ActionMenu()
        {
            bool exitApp = false;
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("********************");
            Console.WriteLine("* Select an option *");
            Console.WriteLine("********************");
            Console.ResetColor();

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?:");
                Console.ForegroundColor = ConsoleColor.Cyan;
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
                        ShowInventoryManagementMenu();
                        break;
                    case "2":
                        ShowOrderManagementMenu();
                        break;
                    case "3":
                        ShowSettingsMenu();
                        break;
                    case "4":
                        SaveAllData();
                        break;
                    case "0":
                        exitApp = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            } while (!exitApp);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Thank you for using StockManagement TM");

        }

        private static void SaveAllData()
        {
            throw new NotImplementedException();
        }

        private static void ShowSettingsMenu()
        {
            throw new NotImplementedException();
        }

        private static void ShowOrderManagementMenu()
        {
            string? userSelection = string.Empty;

            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("********************");
                Console.WriteLine("* Select an action *");
                Console.WriteLine("********************");

                Console.WriteLine("\n1: Open order overview");
                Console.WriteLine("\n2: Add new order");
                Console.WriteLine("\n0: Back to main menu");

                Console.Write("Your selection");
                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        ShowOpenOrderOverview();
                        break;
                    case "2":
                        ShowAddNewOrder();
                        break;
                    default: 
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input! Please try again.");
                        break;
                }

            } while (userSelection != "0");
        }

        private static void ShowAddNewOrder()
        {
            throw new NotImplementedException();
        }

        private static void ShowInventoryManagementMenu()
        {
            string? userInput;
            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("************************");
                Console.WriteLine("* Inventory management *");
                Console.WriteLine("************************");

                ShowAllProductsOverview();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?");
                Console.ResetColor();

                Console.WriteLine("1: View details of a product");
                Console.WriteLine("2: Add new product");
                Console.WriteLine("3: Clone product");
                Console.WriteLine("4: View products with low stock");
                Console.WriteLine("0: Back to main menu");

                Console.Write("Your selection: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowDetailsAndUseProduct();
                        break;
                    case "2":
                        //ShowCreateNewProduct
                        break;
                    case "3":
                        //ShowCloneExistingProduct();
                        break;
                    case "4":
                        ShowProductsLowOnStock();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;

                }

            } while (userInput != "0");
            Console.Clear();
        }

        private static void ShowProductsLowOnStock()
        {
            List<Product> lowStockProducts = inventory.Where(p => p.IsBelowStockThreshold).ToList();

            if(lowStockProducts.Count > 0)
            {
                Console.WriteLine("The following items are low on stock. Order more soon!\n");

                foreach (var product in lowStockProducts) 
                {
                    Console.WriteLine(product.CreateSimpleProductRepresentation());
                    Console.WriteLine();
                }
            }
            else { Console.WriteLine("No items are currently low on stock."); }

            Console.ReadLine();
        }

        private static void ShowDetailsAndUseProduct()
        {
            string? userInput = string.Empty;
            
            Console.Write("Enter the ID of product: ");
            string? selectedProductId = Console.ReadLine();

            if (selectedProductId != null)
            {
                Product? selectedProduct = inventory.Where(p => p.Id == 
                int.Parse(selectedProductId)).FirstOrDefault();

                if(selectedProduct != null)
                {
                    Console.WriteLine(selectedProduct.DisplayDetailsFull());

                    Console.WriteLine("\nWhat do you want to do?");
                    Console.WriteLine("1: Use product");
                    Console.WriteLine("0: Back to inventory overview");

                    Console.Write("Your selection: ");
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("How many products do you want to use?");
                            int amount = int.Parse(userInput);
                            selectedProduct.UseProduct(amount);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{amount} {selectedProduct.UnitType} " +
                                $"{selectedProduct.Name} spent");
                            Console.ResetColor();
                            break; 
                        case "2":
                            break;
                        default: Console.WriteLine("Invalid selection. Please try again."); break;
                    }
                }
                else
                {
                    Console.WriteLine("Non-existing product selected. Please try again.");
                }
            }
        }

        private static void ShowAllProductsOverview()
        {
            foreach (var product in inventory)
            {
                Console.WriteLine(product.CreateSimpleProductRepresentation());
                Console.WriteLine();
            }
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
            Console.WriteLine("Checking fulfilled orders.");
            foreach (var order in orders)
            {
                if(!order.Fulfilled && order.OrderFulfilmentDate < DateTime.Now)
                //Fulfil the order
                {
                    foreach (var orderItem in order.OrderItems)
                    {
                        Product? selectedProduct = inventory.Where(p => p.Id == orderItem.Id).FirstOrDefault();
                        if (selectedProduct != null)
                        {
                            selectedProduct.IncreaseStock(orderItem.AmountOrdered);
                        }
                    }
                    order.Fulfilled = true;
                }
            }

            orders.RemoveAll(o => o.Fulfilled);

            Console.WriteLine("Fulfilled orders checked");
        }
    }
}
