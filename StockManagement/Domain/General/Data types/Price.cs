using StockManagement.Domain.General.Data_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Stock.Data_types
{
    public class Price
    {
        public double ItemPrice { get; set; }
        public Currency Currency { get; set; }

        public override string ToString()
        {
            return $"{ItemPrice} {Currency}";
        }

    }
}
