using StockManagement.Stock.Data_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Domain.ProductManagement
{
    public partial class Product
    {
        public static int StockThreshold = 5;

        public static void ChangeStockThreshold(int newStockThreshhold)
        {
            //We will only allow this to go through if the value is > 0
            if (newStockThreshhold > 0)
            {
                StockThreshold = newStockThreshhold;
            }
        }

        private void Log(string message)
        {
            //Will be written to file
            Console.WriteLine(message);
        }

        public void UpdateLowStock()
        {
            if (CurrentStock < StockThreshold)//For now a fixed value
            {
                IsBelowStockThreshold = true;
            }
        }

        public string CreateSimpleProductRepresentation()
        {
            return $"Product {Id} ({Name})";
        }
    }
}
