using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhancedShoppingSystem
{
    internal class Employee
    {
        private ShopItems _shop;
        public Employee(ShopItems shop)
        {
            _shop = shop;
            EmployeeID.Add(101,"ahmed medhat");
            EmployeeID.Add(102,"bassim ehab ");
            EmployeeID.Add(205,"yasser alsaayed");
        }
        public Dictionary<int,string> EmployeeID = new Dictionary<int,string>();
        public void AddToShopItems(string NewItem,double ItemPrice)
        {
            _shop.Items.Add(NewItem,ItemPrice);
        }

    }
}
