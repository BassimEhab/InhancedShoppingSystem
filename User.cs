using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InhancedShoppingSystem
{
    internal class User:ShopItems
    {
        //public Dictionary<stringListdouble>=new Dictionary<string,double>();
        public List<string> MyCart=new List<string>();
        public string LastItem { get; set; }
        public string UserName { get; set; }
        public int UserPhone { get; set; }
        public string UserAddress { get; set; }
        public void AddToCart(string Name)
        {
            MyCart.Add(Name);
        }
        public void ViewCart()
        {
            foreach (var item in MyCart)
            {
                if (Items.ContainsKey(item))
                {
                    Console.WriteLine($"{item} : {Items[item]}$");
                }
            }
        }
        public void RemoveFromCart(string Name)
        {
            MyCart.Remove(Name);
        }
        public void UndoLastAction(int Choice)
        {
            if (Choice == 1)
            {
                MyCart.Remove(LastItem);
                Console.WriteLine("done!");
            }
            else if (Choice == 3)
            {
                MyCart.Add(LastItem);
                Console.WriteLine("done!");
            }
            else
            {
                Console.WriteLine("Cann't undo this action");
            }
        }
        public double Total()
        {
            double total = 0;
            foreach (var item in MyCart)
            {
                total += Items[item];
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
