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
        private void Log(string message)
        {
            //Will be written to file
            Console.WriteLine(message);
        }

        private void UpdateLowStock()
        {
            if (CurrentStock < 10)//For now a fixed value
            {
                IsBelowStockThreshold = true;
            }
        }

        private string CreateSimpleProductRepresentation()
        {
            return $"Product {Id} ({Name})";
        }
    }
}
