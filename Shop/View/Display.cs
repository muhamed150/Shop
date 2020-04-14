using System;
using Shop.Controllers;
using Shop.Data;
using Shop.Data.Models;

namespace Shop.View
{
    public class Display
    {

        private const int CLOSE_OPERATION_ID = 5;
        private const int RETURN_OPERATION_ID = 6;
        private DrinkController drinkController;
        private NutController nutController;
        private FruitAndVegetableController fruitAndVegetableController;
        private PastryController pastryController;
        public Display()
        {
            drinkController = new DrinkController();
            nutController = new NutController();
            fruitAndVegetableController = new FruitAndVegetableController();
            pastryController = new PastryController();
            HandleInput();
        }

        private void ShowMainMenu()
        {
            Console.WriteLine(new string('*',40));
            Console.WriteLine(new string(' ',16) + "MAIN MENU");
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("1. Go to pastries");
            Console.WriteLine("2. Go to fruits and vegetables");
            Console.WriteLine("3. Go to nuts");
            Console.WriteLine("4. Go to drinks");   
            Console.WriteLine("5. Exit");   
            Console.WriteLine(new string('*', 40)); //Ако е грозно махаме
        }

        private void HandleInput()
        {
            var operation = -1;
            do
            {
                ShowMainMenu();
                Console.Write("Enter number: ");
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        PastriesInput();
                        break;
                    case 2:
                        FruitsAndVegetablesInput();
                        break;
                    case 3:
                        NutsInput();
                        break;
                    case 4:
                        DrinksInput();
                        break;
                    default:
                        break;
                }
                
            } while (operation!=CLOSE_OPERATION_ID);  
        }

        private void PastriesInput()
        {
            throw new NotImplementedException();
        }

        private void FruitsAndVegetablesInput()
        {
            throw new NotImplementedException();
        }

        private void NutsInput()
        {
            throw new NotImplementedException();
        }

        private void DrinksInput()
        {
            Console.Clear();
            var operation = -1;
            do
            {
                ShowDrinksMenu();
                Console.Write("Enter number: ");
                operation = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (operation)
                {
                    case 1:
                        ListAllDrinks();
                        break;
                    case 2:
                        GetDrinkById();
                        break;
                    case 3:
                        AddDrink();
                        break;
                    case 4:
                        RemoveDrink();
                        break;
                    case 5:
                        UpdateDrink();
                        break;
                    case 6:
                        HandleInput();
                        break;
                    default:
                        break;
                }

                Console.Write("Press any key to continue... ");
                Console.ReadKey();
                Console.Clear();
            } while (true);

        }


        private void ListAllDrinks()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string(' ', 18) + "DRINKS");
            Console.WriteLine(new string('*', 40));
            var drinks = drinkController.GetAllDrinks();
            foreach (var item in drinks)
            {
                Console.WriteLine($"{item.Id} {item.Category} {item.Name} {item.Price}lv. {item.Quantity}pcs.");
            }
            Console.WriteLine(new string('*', 40));
        }

        private void GetDrinkById()
        {
            Console.Write("Enter ID: ");
            var id = int.Parse(Console.ReadLine());
            Drink drink = drinkController.GetDrinkById(id);
            if (drink!=null)
            {
                Console.WriteLine(new string ('*',40));
                Console.WriteLine("ID: " + drink.Id);
                Console.WriteLine("Category: " + drink.Category);
                Console.WriteLine("Name: " + drink.Name);
                Console.WriteLine("Price: " + drink.Price + "lv.");
                Console.WriteLine("Quantity: " + drink.Quantity + "pcs.");
                Console.WriteLine(new string('*', 40));
            }
            else
            {
                Console.WriteLine("The drink was not found!");
            }
        }

        private void AddDrink()
        {
            Drink drink = new Drink();
            Console.Write("Enter drink's category: ");
            var category = Console.ReadLine();
            Console.Write("Enter drink's name: ");
            var name = Console.ReadLine();
            Console.Write("Enter drink's price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter drink's quantity: ");
            var quantity = int.Parse(Console.ReadLine());
            drink.Category = category;
            drink.Name = name;
            drink.Price = price;
            drink.Quantity = quantity;
            drinkController.Add(drink);
            Console.WriteLine("The drink was successfully added!");
        }

        private void RemoveDrink()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Drink drink = drinkController.GetDrinkById(id);
            drinkController.Delete(drink.Id);
            Console.WriteLine("Тhe drink was deleted successfully!");
        }

        private void UpdateDrink()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Drink drink = drinkController.GetDrinkById(id);
            if (drink!=null)
            {
                Console.WriteLine($"{drink.Id} {drink.Category} {drink.Name} {drink.Price}lv. {drink.Quantity}pcs.");
                Console.Write("Enter category: ");
                var category = Console.ReadLine();
                Console.Write("Enter name: ");
                var name = Console.ReadLine();
                Console.Write("Enter price: ");
                var price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter quantity: ");
                var quantity = int.Parse(Console.ReadLine());
                drink.Category = category;
                drink.Name = name;
                drink.Price = price;
                drink.Quantity = quantity;
                drinkController.Update(drink);
                Console.WriteLine("The drink was updated successfully!");
            }
        }

        private void ShowPaistriesMenu()
        {
            throw new NotImplementedException();
        }

        private void ShowFruitsAndVegetablesMenu()
        {
            throw new NotImplementedException();
        }

        private void ShowNutsMenu()
        {
            throw new NotImplementedException();
        }

        private void ShowDrinksMenu()
        {
                Console.WriteLine(new string('*', 40));
                Console.WriteLine(new string(' ', 15) + "DRINKS MENU");
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("1. List all drinks.");
                Console.WriteLine("2. Found drink by ID.");
                Console.WriteLine("3. Add drink.");
                Console.WriteLine("4. Remove drink.");
                Console.WriteLine("5. Update drink.");
                Console.WriteLine("6. Return to main menu");
                Console.WriteLine(new string('*', 40));
        }

    }
}
