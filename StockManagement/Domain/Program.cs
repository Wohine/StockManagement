using StockManagement.Domain.General.Data_types;
using StockManagement.Domain.ProductManagement;
using StockManagement.Stock.Data_types;
using System.Runtime.CompilerServices;
using System.Text;

namespace StockManagement.Domain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WelcomeText();


        }

        private static void WelcomeText()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome to Stock Management");
            Console.WriteLine($"Press enter key to start logging in!");
            Console.ReadLine();
            Console.ResetColor();
        }
    }
}