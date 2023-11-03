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
        //Details
        protected int id;
        protected string name = string.Empty;
        protected string? description;

        //Stock
        protected int maxStock = 0;

        //Get and Set
        public int Id { get { return id; } set { id = value; } }
        public string Name
        {
            get { return name; }
            set
            {
                name = value.Length > 50 ? value[..50] : value;
            }
        }
        public string? Description
        {
            get { return description; }
            set
            {
                if (value == null)
                {
                    description = string.Empty;
                }
                else
                {
                    description = value.Length > 250 ? value[..250] : value;
                }
            }
        }
        public int MaxStock
        {
            get; set;
        }
        public int CurrentStock { get; private set; }
        public bool IsBelowStockThreshold { get; private set; }
        public UnitType UnitType { get; set; }

        public Price? Price { get; set; }

        public Product(int id) : this(id, string.Empty)
        {
        }

        public Product(int Id, string name)
        {
            this.Id = Id;
            Name = name;
        }

        public Product(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            UnitType = unitType;
            
            maxStock = maxAmountInStock;

            UpdateLowStock();
        }

        //Methods
        public void UseProduct(int items)
        {
            if (items <= CurrentStock)
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

        public string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();
            //Todo: add price here too
            sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{CurrentStock} item(s) in stock.");

            if (IsBelowStockThreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();
        }

        public string DisplayDetailsFull(string extraDetails)
        {
            StringBuilder sb = new StringBuilder();
            //Todo: add price here too
            sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{CurrentStock} item(s) in stock.");

            sb.Append(extraDetails);

            if (IsBelowStockThreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();
        }

        public void IncreaseStock()
        {
            CurrentStock++;
        }

        public void IncreaseStock(int amount)
        {
            int newStock = CurrentStock + amount;

            if (newStock <= maxStock)
            {
                CurrentStock += amount;
            }
            else
            {
                CurrentStock = maxStock; //Only fill up to maxStock and ditch the rest.
                Log($"{DisplayDetailsFull()} stock overflow. {newStock - CurrentStock}" +
                    $" item(s) ordered that could not be stored.");
            }

            if (CurrentStock > StockThreshold)
            {
                IsBelowStockThreshold = false;
            }
        }

        public void DecreaseStock(int items, string details)
        {
            CurrentStock--;
        }
    }
}
