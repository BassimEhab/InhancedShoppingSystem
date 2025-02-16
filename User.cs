using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InhancedShoppingSystem
{
    internal class User
    {
        private ShopItems _shop;
        public User(ShopItems shop) 
        {   
            _shop = shop;
        }
        //public Dictionary<stringListdouble>=new Dictionary<string,double>();
        public Dictionary<string,double> MyCart=new Dictionary<string,double>();
        private Dictionary<string, int> ItemCounter =new Dictionary<string, int>(); 
        public string LastItem { get; set; }
        public string UserName { get; set; }
        public int UserPhone { get; set; }
        public string UserAddress { get; set; }
        public void AddToCart(string Name)
        {
            if (MyCart.ContainsKey(Name))
            {
                ItemCounter[Name]++;
                MyCart[Name] += _shop.Items[Name];
            }
            else
            {
                MyCart.Add(Name, _shop.Items[Name]);
                ItemCounter.Add(Name, 1);
            }
        }
        public void ViewCart()
        {
            Console.WriteLine("product  quantity   Price\n");
            foreach (var item in MyCart)
            {
                Console.WriteLine($"{item.Key}     X {ItemCounter[item.Key]}  :  {item.Value}$");
            }
        }
        public void RemoveFromCart(string Name)
        {
            if (ItemCounter[Name] > 1)
            {
                ItemCounter[Name]--;
                MyCart[Name] -= _shop.Items[Name];
            }
            else
            {
            MyCart.Remove(Name);
            ItemCounter.Remove(Name);
            }
        }
        public void UndoLastAction(int Choice)
        {
            switch (Choice)
            {
                case 1:
                    if (ItemCounter[LastItem] > 1)
                    {
                        ItemCounter[LastItem]--;
                        MyCart[LastItem] -= _shop.Items[LastItem];
                    }
                    else
                    {
                        MyCart.Remove(LastItem);
                        ItemCounter.Remove(LastItem);
                    }
                    Console.WriteLine("done!");
                    break;
                case 3:
                    if (ItemCounter[LastItem] > 1)
                    {
                        ItemCounter[LastItem]++;
                        MyCart[LastItem] += _shop.Items[LastItem];
                    }
                    MyCart.Add(LastItem, _shop.Items[LastItem]);
                    Console.WriteLine("done!");
                    break;
                default:
                    Console.WriteLine("Cann't undo this action");
                    break;


            }
            if (Choice == 1)
            {
                
            }
            else if (Choice == 3)
            {
            }
            else
            {
            }
        }
        public double Total()
        {
            double total = 0;
            foreach (var item in MyCart)
            {
                total += item.Value;
            }
            return total;
        }
        public void Checkout()
        {
            Console.WriteLine("\t\t\tyour Info ");
            Console.WriteLine($"Name: {UserName}");
            Console.WriteLine($"Phone: {UserPhone}");
            Console.WriteLine($"Address: {UserAddress}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("\t\t\tyour order");
            ViewCart();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Total: {Total()}$");
            MyCart.Clear();
        }
    }
}
