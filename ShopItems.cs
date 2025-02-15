using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhancedShoppingSystem
{
    internal class ShopItems
    {
        public Dictionary<string,double> Items { get; set; } = new Dictionary<string, double>();
        
        public ShopItems()
        {
            Items.Add("laptop",2500);
            Items.Add("phone",1200);
            Items.Add("milk",5.5);
            Items.Add("coffee",12);
            Items.Add("water",0.75);
            Items.Add("t-shirt",35);

        }              
    }
}
