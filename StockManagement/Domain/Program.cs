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
            Util.InitializeStock();
            Util.WelcomeText();
            Util.ActionMenu();

        }
    }
}