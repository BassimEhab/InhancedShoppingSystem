using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhancedShoppingSystem
{
    internal class Employee:ShopItems
    {
        public Dictionary<int,string> EmployeeID = new Dictionary<int,string>();
        public Employee()
        {
            EmployeeID.Add(101,"ahmed medhat");
            EmployeeID.Add(102,"bassim ehab ");
            EmployeeID.Add(205,"yasser alsaayed");
        }
        public void AddToShopItems(string NewItem,double ItemPrice)
        {
            Items.Add(NewItem,ItemPrice);
        }

    }
}
