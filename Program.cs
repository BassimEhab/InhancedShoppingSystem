using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection.Emit;
using System.Xml;

namespace InhancedShoppingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShopItems items = new ShopItems();
            User user = new User();
            Employee employee = new Employee();
            user.Items=items.Items;
            employee.Items=items.Items;

            // employee
            int EmployeeId;
            string NewProduct;
            double NewProductPrice;
            // general
            int UserOption;
            int input;
            int LastOp = 0;
            bool Finish;
            string ItemChoosen;
            while (true)
            {

                Console.Write("Choose:\n[1] user\n[2] employee\n[3] Exit\n=> ");
                if (int.TryParse(Console.ReadLine(), out UserOption))
                {
                    #region User

                    if (UserOption == 1)
                    {
                        Finish = false;
                        while (!Finish)
                        {
                            Console.Write("\nChoose\n[1] Add item to cart\n[2] view your cart\n[3] Remove from Cart\n[4] checkout\n[5] Undo last action(add | remove)\n[6] View Total\n[7] Exit \n=> ");
                            if (int.TryParse(Console.ReadLine(), out input))
                            {
                                switch (input)
                                {
                                    #region AddToCart
                                    case 1:
                                        Console.WriteLine("choose item from our list: ");
                                        foreach (var item in items.Items)
                                        {
                                            Console.WriteLine($"{item.Key} : {item.Value}$");
                                        }
                                        Console.Write("=> ");
                                        ItemChoosen = Console.ReadLine().ToLower();
                                        if (items.Items.ContainsKey(ItemChoosen))
                                        {
                                            user.AddToCart(ItemChoosen);
                                            user.LastItem = ItemChoosen;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("sorry this item is not in our store! ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        break;
                                    #endregion

                                    #region ViewCart
                                    case 2:
                                        Console.WriteLine("\nThis is your cart items:\n ");
                                        user.ViewCart();
                                        break;
                                    #endregion

                                    #region RemoveFromCart
                                    case 3:
                                        Console.Write("Enter the item you want to remove form your cart: ");
                                        ItemChoosen = Console.ReadLine().ToLower();
                                        if (user.MyCart.Contains(ItemChoosen))
                                        {
                                            user.LastItem = ItemChoosen;
                                            user.RemoveFromCart(ItemChoosen);
                                        }
                                        else { Console.WriteLine("This item is not in your cart! "); }
                                        break;
                                    #endregion

                                    #region Checkout
                                    case 4:
                                        Console.Write("Enter your name : ");
                                        user.UserName = Console.ReadLine();
                                        Console.Write("Enter your Phone number : ");
                                        user.UserPhone = int.Parse(Console.ReadLine());
                                        Console.Write("Enter your Address : ");
                                        user.UserAddress = Console.ReadLine();
                                        Console.WriteLine("-----------------------------------------------");
                                        user.Checkout();
                                        break;
                                    #endregion

                                    #region UndoLastChanges
                                    case 5:
                                        user.UndoLastAction(LastOp);
                                        break;
                                    #endregion

                                    #region ViewTotal
                                    case 6:
                                        Console.WriteLine($"Total: {user.Total()}$");
                                        break;
                                    #endregion

                                    #region Exit
                                    case 7:
                                        Console.WriteLine("Safe Exit! ");
                                        Finish = true;
                                        break;
                                    #endregion
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("we dont have this option!");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        break;
                                }
                                //for undo
                                LastOp = input;
                            }
                            else 
                            { 
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("choose number of the option! "); 
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                    #endregion

                    #region Employee(Additon to task)
                    else if (UserOption == 2)
                    {
                        Finish = false;
                        Console.Write("Enter your ID: ");
                        EmployeeId = int.Parse(Console.ReadLine());
                        if (employee.EmployeeID.ContainsKey(EmployeeId))
                        {
                            Console.WriteLine($"Welcome {employee.EmployeeID[EmployeeId]}");
                            while (!Finish)
                            {
                                Console.Write("choose\n[1] Add Product\n[2] Exit\n=> ");
                                if (int.TryParse(Console.ReadLine(), out input))
                                {
                                    switch (input)
                                    {
                                        #region EmpAddProduct
                                        case 1:
                                            Console.Write("enter proudct name: ");
                                            NewProduct = Console.ReadLine().ToLower();
                                            Console.Write("enter proudct price: ");
                                            NewProductPrice = Double.Parse(Console.ReadLine());
                                            try
                                            {
                                                employee.AddToShopItems(NewProduct, NewProductPrice);
                                            }
                                            catch (ArgumentException ex)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("This item is allready in the shop");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                            break;
                                        #endregion

                                        #region EmpExit
                                        case 2:
                                            Finish = true;
                                            break;
                                        #endregion

                                        default:
                                            Console.WriteLine("we dont have this option!");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Enter number of the option!");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id! ");
                        }
                    }
                    #endregion

                    #region ExitHoleProgram
                    else if (UserOption == 3)
                    {
                        break;
                    }
                    #endregion

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("we dont have this option!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                // for string UserOption
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("choose number of the option! ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
    }
}
