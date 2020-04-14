using Shop.Controllers;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.View
{
   public class Display
    {
        private int closeOperationId = 6;
        DrinkController drinkController = new DrinkController();

        public Display()
        {
            input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all drinks");
            Console.WriteLine("2. Add new drink");
            Console.WriteLine("3. Update drink");//направи sell метод
            Console.WriteLine("4. Fetch entry by name");// ако се счупи трябва да се помисли за id
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit entry");

        }
        private void input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAllDrinks();
                        break;
                    case 2:
                        AddDrink();
                        break;
                    case 3:
                        SellDrink();
                        break;
                    case 4:
                        GetInformationAboutDrink();
                        break;
                    case 5:
                        DeleteDrink();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (operation!=closeOperationId);
        }

        private void DeleteDrink()
        {
            throw new NotImplementedException();
        }

        private void GetInformationAboutDrink()
        {
            throw new NotImplementedException();
        }

        private void SellDrink()
        {
            throw new NotImplementedException();
        }

        private void AddDrink()
        {
            Drink drink = new Drink();
            Console.Write("Insert drink's category: ");
            var category = Console.ReadLine();
            Console.Write("Insert drink's name: ");
            var name = Console.ReadLine();
            Console.Write("Insert drink's price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.Write("Insert drink's quantity: ");
            var quantity = int.Parse(Console.ReadLine());
            drink.Category = category;
            drink.Name = name;
            drink.Price = price;
            drink.Quantity = quantity;
            drinkController.Add(drink);
            Console.WriteLine("Sucesfully added!");
        }

        private void ListAllDrinks()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "DRINKS");
            Console.WriteLine(new string('-', 40));
            var drinks = drinkController.GetAllDrinks();
            foreach (var item in drinks)
            {
                Console.WriteLine($"{item.Id} {item.Category} {item.Name} {item.Price} {item.Quantity}");
            }
        }
    }
}
