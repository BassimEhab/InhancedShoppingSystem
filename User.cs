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
        public Dictionary<string,(int Quntity,double Price)> MyCart=new Dictionary<string,(int Quntity,double Price)>();
        public string LastItem { get; set; }
        public string UserName { get; set; }
        public int UserPhone { get; set; }
        public string UserAddress { get; set; }
        public void AddToCart(string Name)
        {
            if (MyCart.ContainsKey(Name))
            {
                MyCart[Name] = (MyCart[Name].Quntity + 1, MyCart[Name].Price + _shop.Items[Name]);
            }
            else
            {
                MyCart.Add(Name, (1, _shop.Items[Name]));
            }
        }
        public void ViewCart()
        {
            Console.WriteLine("Product   Quantity   Price\n");
            foreach (var item in MyCart)
            {
                Console.WriteLine($"{item.Key}     X {item.Value.Quntity}  :  {item.Value.Price}$");
            }
        }

        public void RemoveFromCart(string Name)
        {
            if (MyCart[Name].Quntity > 1)
            {
                MyCart[Name] = (MyCart[Name].Quntity - 1, MyCart[Name].Price - _shop.Items[Name]);
            }
            else
            {
            MyCart.Remove(Name);
            }
        }
        public void UndoLastAction(int Choice)
        {
            if (MyCart.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("your cart is empty! ");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            switch (Choice)
            {
                case 1:
                    if (MyCart[LastItem].Quntity > 1)
                    {
                        MyCart[LastItem] = (MyCart[LastItem].Quntity - 1, MyCart[LastItem].Price - _shop.Items[LastItem]);
                    }
                    else
                    {
                        MyCart.Remove(LastItem);
                    }
                    Console.WriteLine("undo Item Add !");
                    break;
                case 3:
                    if (MyCart[LastItem].Quntity >= 1)
                    {
                        MyCart[LastItem] = (MyCart[(LastItem)].Quntity + 1, MyCart[LastItem].Price + _shop.Items[LastItem]);
                    }
                    else
                    {

                        MyCart.Add(LastItem, (1, _shop.Items[LastItem]));
                    }
                    Console.WriteLine("undo item remove !");
                    break;
                default:
                    Console.WriteLine("Cann't undo this action");
                    break;
            }
        }
        public double Total()
        {
            double total = 0;
            foreach (var item in MyCart)
            {
                total += item.Value.Price;
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
