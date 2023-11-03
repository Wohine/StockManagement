using StockManagement.Domain.General.Data_types;
using StockManagement.Domain.ProductManagement;
using StockManagement.Stock.Data_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Domain
{
    public class ProductRepository
    {
        private static string directory = @"C:\Users\marti\source\repos\StockManagement\StockManagement\Domain\Data\";
        private static string productsFileName = "products.txt";

        private void CheckForExistingProductFile()
        {
            string path = $"{directory}{productsFileName}";

            bool existingFileFound = File.Exists(path);
            if(!existingFileFound)
            {
                //Create the directory
                if(!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                //Create the empty file
                using FileStream fs = File.Create(path);
            }
        }

        public List<Product> LoadProductsFromFile()
        {
            List<Product> products = new List<Product>();

            string path = $"{directory}{productsFileName}";

            try
            {
                CheckForExistingProductFile();

                string[] productsAsString = File.ReadAllLines(path);
                for (int i = 0; i < productsAsString.Length; i++)
                {
                    string[] productSplits = productsAsString[i].Split(';');

                    bool success = int.TryParse(productSplits[0], out int productId);
                    if(!success)
                    {
                        productId = 0;
                    }

                    string name = productSplits[1];
                    string description = productSplits[2];

                    success = int.TryParse(productSplits[3], out int maxItemsInStock);
                    if (!success)
                    {
                        maxItemsInStock = 100;
                    }

                    success = int.TryParse(productSplits[4], out int itemPrice);
                    if (!success)
                    {
                        itemPrice = 0;
                    }

                    success = Enum.TryParse(productSplits[5], out Currency currency);
                    if (!success)
                    {
                        currency = Currency.Dollar;
                    }

                    success = Enum.TryParse(productSplits[6], out UnitType unitType);
                    if (!success)
                    {
                        unitType = UnitType.PerItem;
                    }

                    Product product = new Product(productId, name, description, 
                        new Price() { ItemPrice = itemPrice, Currency = currency }, unitType, maxItemsInStock);

                    products.Add(product);
                }
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong parsing the file, please check the data!");
                Console.WriteLine(iex.Message);
            }
            catch (FileNotFoundException fnfex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file couldent be found!");
                Console.WriteLine(fnfex.Message);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong while loading the file!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ResetColor();
            }

            return products;
        }
    }
}
