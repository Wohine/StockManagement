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

        //Stock
        protected int maxStock = 0;

        //Get and Set
        public int Id { get { return id; } set { id = value; } } 
        public string Name { get { return name; } 
            set 
            {
                name = value.Length > 50 ? value[..50] : value;
            } 
        }
        public string? Description { get { return description; } 
            set 
            { 
                if(value == null)
                {
                    description = string.Empty;
                }
                else
                {
                    description = value.Length > 250 ? value[..250] : value;
                }
            } 
        }
        public int CurrentStock { get; private set; }
        public bool IsBelowStockThreshold { get; private set; }
        public UnitType UnitType { get; set;}

        public Product(int id, string name) 
        {
            Id = id;
            Name = name;
        }

        //Methods
        public void UseProduct(int items)
        {
            if(items <= CurrentStock)
            {
                //use the items
                CurrentStock -= items;
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

            if( IsBelowStockThreshold )
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
            if(CurrentStock < 10)//For now a fixed value
            {
                IsBelowStockThreshold = true;
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
