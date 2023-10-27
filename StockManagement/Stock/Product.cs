using StockManagement.Stock.Data_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Stock
{
    public class Product
    {
        //Details
        protected int id;
        protected string name = string.Empty;
        protected string? description;
        protected UnitType unitType;

        //Stock
        protected int maxStock = 0;
        protected int currentStock;
        protected bool isBelowStockThreshold = false;

        //Get and Set
        public int Id { get { return id; } set { id = value; } } 
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int MaxStock { get {  return maxStock; } set {  maxStock = value; } }
        public int CurrentStock { get { return currentStock; } set {  currentStock = value; } }

        public Product() 
        {
            
        }

        //Methods
        public void UseProduct(int items)
        {
            if(items <= currentStock)
            {
                //use the items
                currentStock -= items;
                UpdateLowStock();
                Log($"Amount in stock updated. Now {CurrentStock} {Name} in stock");
            }
            else
            {
                Log($"Not enough items in stock for {CreateSimpleProductRepresentation()}. " +
                    $"{CurrentStock} available but {items} requested.");
            }
        }

        private string CreateSimpleProductRepresentation()
        {
            return $"Product {Id} ({Name})";
        }

        private string CreateFullProductRepresentation()
        {
            StringBuilder sb = new StringBuilder();
            //Todo: add price here too
            sb.Append($"{Id} {Name} \n{Description}\n{CurrentStock} item(s) in stock.");

            if( isBelowStockThreshold )
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();
        }

        private void Log(string message)
        {
            //Will be written to file
            Console.WriteLine(message);
        }

        private void UpdateLowStock()
        {
            if(currentStock < 10)//For now a fixed value
            {
                isBelowStockThreshold = true;
            }
        }

        public void IncreaseStock()
        {
            CurrentStock++;
        }

        public void DecreaseStock(int items, string details)
        {
            CurrentStock--;
        }
    }
}
