using System;
using System.Collections.Generic;
using Shop.Controllers;
using System.Text;

namespace Shop.View
{
    public class Display
    {

        private DrinkController drinkController;
        private NutController nutController;
        private FruitAndVegetableController fruitAndVegetableController;
        private PastryController pastryController;

        public Display(ShopContext context)
        {
            drinkController = new DrinkController();
            nutController = new NutController();
            fruitAndVegetableController = new FruitAndVegetableController();
            pastryController = new PastryController();
            HandleInput();
        }

        private void ShowCommands()
        {
            Console.WriteLine(new string('_',40));
            Console.WriteLine("List of the general commands:");
            Console.WriteLine("1.List all products.");
            Console.WriteLine("2.Get product by name.");
            Console.WriteLine("3.Add product.");
            Console.WriteLine("4.Remove product.");
            Console.WriteLine("5.Update product.");
            Console.WriteLine("6.Buy product.");
            Console.WriteLine("7.Exit.");
            Console.WriteLine(new string('_', 40));
        }

        private void HandleInput()
        {
            string input;
            do
            {
                ShowCommands();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ListAllProducts();
                        break;
                    case "2":
                        GetProductByName();
                        break;
                    case "3":
                        AddProduct();
                        break;
                    case "4":
                        RemoveProduct();
                        break;
                    case "5":
                        UpdateProduct();
                        break;
                    case "6":
                        BuyProduct();
                    default:
                        break;
                }
            } while (input!=7);


        }
    }
}
