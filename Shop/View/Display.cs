using System;
using Shop.Controllers;
using Shop.Data;
using Shop.Data.Models;

namespace Shop.View
{
    public class Display
    {
        private const string close = "close";
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
            Console.WriteLine(new string('*', 40));
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
                
            } while (operation != CLOSE_OPERATION_ID);
        }

        private void PastriesInput()
        {
            Console.Clear();
            var operation = -1;
            do
            {
                ShowPastriesMenu();
                Console.Write("Enter number: ");
                operation = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (operation)
                {
                    case 1:
                        ListAllPastries();
                        Close();
                        break;
                    case 2:
                        FindPastryById();
                        Close();
                        break;
                    case 3:
                        AddPastry();
                        Close();
                        break;
                    case 4:
                        RemovePastry();
                        Close();
                        break;
                    case 5:
                        UpdatePastry();
                        Close();
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }

            } while (operation != RETURN_OPERATION_ID);

        }

        private void ListAllPastries()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string(' ', 16) + "PASTRIES");
            Console.WriteLine(new string('*', 40));
            var pastries = pastryController.GetAllPastries();
            foreach (var item in pastries)
            {
                Console.WriteLine($"{item.Id} {item.Category} {item.Name} {item.Price}lv. {item.Quantity}pcs.");
            }
            Console.WriteLine(new string('*', 40));
        }

        private void FindPastryById()
        {
            Console.Write("Enter ID: ");
            var id = int.Parse(Console.ReadLine());
            var pastry = pastryController.GetPastryById(id);
            if (pastry != null)
            {
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("ID: " + pastry.Id);
                Console.WriteLine("Category: " + pastry.Category);
                Console.WriteLine("Name: " + pastry.Name);
                Console.WriteLine("Price: " + pastry.Price + "lv.");
                Console.WriteLine("Quantity: " + pastry.Quantity + "pcs.");
                Console.WriteLine(new string('*', 40));
            }
            else
            {
                Console.WriteLine("The pastry was not found!");
            }
        }

        private void AddPastry()
        {
            Pastry pastry = new Pastry();
            Console.Write("Enter category: ");
            var category = Console.ReadLine();
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter quantity: ");
            var quantity = int.Parse(Console.ReadLine());
            pastry.Category = category;
            pastry.Name = name;
            pastry.Price = price;
            pastry.Quantity = quantity;
            pastryController.Add(pastry);
            Console.WriteLine("The pastry was successfully added!");
        }

        private void RemovePastry()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var pastry = pastryController.GetPastryById(id);
            pastryController.Delete(pastry.Id); 
            Console.WriteLine("Тhe pastry was deleted successfully!");
        }

        private void UpdatePastry()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var pastry = pastryController.GetPastryById(id);
            if (pastry != null)
            {
                Console.WriteLine($"{pastry.Id} {pastry.Category} {pastry.Name} {pastry.Price}lv. {pastry.Quantity}pcs.");
                Console.Write("Enter category: ");
                var category = Console.ReadLine();
                Console.Write("Enter name: ");
                var name = Console.ReadLine();
                Console.Write("Enter price: ");
                var price = decimal.Parse(Console.ReadLine());
                Console.Write("Enter quantity: ");
                var quantity = int.Parse(Console.ReadLine());
                pastry.Category = category;
                pastry.Name = name;
                pastry.Price = price;
                pastry.Quantity = quantity;
                pastryController.Update(pastry);
                Console.WriteLine("The pastry was updated successfully!");
            }
        }

        private void FruitsAndVegetablesInput()
        {
            Console.Clear();
            var operation = -1;
            do
            {
                ShowFruitsAndVegetablesMenu();
                Console.Write("Enter number: ");
                operation = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (operation)
                {
                    case 1:
                        ListAllFruitsAndVegetables();
                        Close();
                        break;
                    case 2:
                        FindFruitOrVegetableById();
                        Close();
                        break;
                    case 3:
                        AddFruitOrVegetable();
                        Close();
                        break;
                    case 4:
                        RemoveFruitOrVegetable();
                        Close();
                        break;
                    case 5:
                        UpdateFruitOrVegetable();
                        Close();
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }

            } while (operation != RETURN_OPERATION_ID);

        }

        private void ListAllFruitsAndVegetables()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string(' ', 10) + "FRUITS AND VEGETABLES");
            Console.WriteLine(new string('*', 40));
            var fruitsAndVegetables = fruitAndVegetableController.GetAllFruitsAndVegetables();
            foreach (var item in fruitsAndVegetables)
            {
                Console.WriteLine($"{item.Id} {item.Category} {item.Name} {item.Price}lv. {item.Quantity}kg.");
            }
            Console.WriteLine(new string('*', 40));
        }

        private void FindFruitOrVegetableById()
        {
            Console.Write("Enter ID: ");
            var id = int.Parse(Console.ReadLine());
            var fruitOrVegetable = fruitAndVegetableController.GetFruitOrVegetableById(id);
            if (fruitOrVegetable != null)
            {
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("ID: " + fruitOrVegetable.Id);
                Console.WriteLine("Category: " + fruitOrVegetable.Category);
                Console.WriteLine("Name: " + fruitOrVegetable.Name);
                Console.WriteLine("Price: " + fruitOrVegetable.Price + "lv.");
                Console.WriteLine("Quantity: " + fruitOrVegetable.Quantity + "pcs.");
                Console.WriteLine(new string('*', 40));
            }
            else
            {
                Console.WriteLine("The fruit or vegetable was not found!");
            }
        }

        private void AddFruitOrVegetable()
        {
            FruitAndVegetable fruitOrVegetable = new FruitAndVegetable();
            Console.Write("Enter category: ");
            var category = Console.ReadLine();
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter quantity: ");
            var quantity = int.Parse(Console.ReadLine());
            fruitOrVegetable.Category = category;
            fruitOrVegetable.Name = name;
            fruitOrVegetable.Price = price;
            fruitOrVegetable.Quantity = quantity;
            fruitAndVegetableController.Add(fruitOrVegetable);
            Console.WriteLine("The fruit or vegetable was successfully added!");
        }

        private void RemoveFruitOrVegetable()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var fruitOrVegetable = fruitAndVegetableController.GetFruitOrVegetableById(id);
            fruitAndVegetableController.Delete(fruitOrVegetable.Id);
            Console.WriteLine("Тhe fruit or vegetable was deleted successfully!");
        }

        private void UpdateFruitOrVegetable()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var fruitOrVegetable = fruitAndVegetableController.GetFruitOrVegetableById(id);
            if (fruitOrVegetable != null)
            {
                Console.WriteLine($"{fruitOrVegetable.Id} {fruitOrVegetable.Category} {fruitOrVegetable.Name} {fruitOrVegetable.Price}lv. {fruitOrVegetable.Quantity}pcs.");
                Console.Write("Enter category: ");
                var category = Console.ReadLine();
                Console.Write("Enter name: ");
                var name = Console.ReadLine();
                Console.Write("Enter price: ");
                var price = decimal.Parse(Console.ReadLine());
                Console.Write("Enter quantity: ");
                var quantity = int.Parse(Console.ReadLine());
                fruitOrVegetable.Category = category;
                fruitOrVegetable.Name = name;
                fruitOrVegetable.Price = price;
                fruitOrVegetable.Quantity = quantity;
                fruitAndVegetableController.Update(fruitOrVegetable);
                Console.WriteLine("The fruit or vegetable was updated successfully!");
            }
        }

        private void NutsInput()
        {
            Console.Clear();
            var operation = -1;
            do
            {
                ShowNutsMenu();
                Console.Write("Enter number: ");
                operation = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (operation)
                {
                    case 1:
                        ListAllNuts();
                        Close();
                        break;
                    case 2:
                        FindNutById();
                        Close();
                        break;
                    case 3:
                        AddNut();
                        Close();
                        break;
                    case 4:
                        RemoveNut();
                        Close();
                        break;
                    case 5:
                        UpdateNut();
                        Close();
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }

            } while (operation != RETURN_OPERATION_ID);

        }

        private void ListAllNuts()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string(' ', 18) + "NUTS");
            Console.WriteLine(new string('*', 40));
            var nuts = nutController.GetAllNuts();
            foreach (var item in nuts)
            {
                Console.WriteLine($"{item.Id} {item.Category} {item.Name} {item.Price}lv. {item.Quantity}pcs.");
            }
            Console.WriteLine(new string('*', 40));
        }

        private void FindNutById()
        {
            Console.Write("Enter ID: ");
            var id = int.Parse(Console.ReadLine());
            var nut = nutController.GetNutById(id);
            if (nut != null)
            {
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("ID: " + nut.Id);
                Console.WriteLine("Category: " + nut.Category);
                Console.WriteLine("Name: " + nut.Name);
                Console.WriteLine("Price: " + nut.Price + "lv.");
                Console.WriteLine("Quantity: " + nut.Quantity + "pcs.");
                Console.WriteLine(new string('*', 40));
            }
            else
            {
                Console.WriteLine("The nut was not found!");
            }
        }

        private void AddNut()
        {
            Nut nut = new Nut();
            Console.Write("Enter category: ");
            var category = Console.ReadLine();
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter quantity: ");
            var quantity = int.Parse(Console.ReadLine());
            nut.Category = category;
            nut.Name = name;
            nut.Price = price;
            nut.Quantity = quantity;
            nutController.Add(nut);
            Console.WriteLine("The nut was successfully added!");
        }

        private void RemoveNut()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var nut = nutController.GetNutById(id);
            nutController.Delete(nut.Id);
            Console.WriteLine("Тhe nut was deleted successfully!");
        }

        private void UpdateNut()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var nut = nutController.GetNutById(id);
            if (nut != null)
            {
                Console.WriteLine($"{nut.Id} {nut.Category} {nut.Name} {nut.Price}lv. {nut.Quantity}pcs.");
                Console.Write("Enter category: ");
                var category = Console.ReadLine();
                Console.Write("Enter name: ");
                var name = Console.ReadLine();
                Console.Write("Enter price: ");
                var price = decimal.Parse(Console.ReadLine());
                Console.Write("Enter quantity: ");
                var quantity = int.Parse(Console.ReadLine());
                nut.Category = category;
                nut.Name = name;
                nut.Price = price;
                nut.Quantity = quantity;
                nutController.Update(nut);
                Console.WriteLine("The nut was updated successfully!");
            }
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
                        Close();
                        break;
                    case 2:
                        FindDrinkById(); 
                        Close();
                        break;
                    case 3:
                        AddDrink(); 
                        Close();
                        break;
                    case 4:
                        RemoveDrink();
                        Close();
                        break;
                    case 5:
                        UpdateDrink(); 
                        Close();
                        break;
                    case 6: 
                        break;
                    default:
                        break;
                }

            } while (operation != RETURN_OPERATION_ID); 

        }


        private void ListAllDrinks()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string(' ', 17) + "DRINKS");
            Console.WriteLine(new string('*', 40));
            var drinks = drinkController.GetAllDrinks();
            foreach (var item in drinks)
            {
                Console.WriteLine($"{item.Id} {item.Category} {item.Name} {item.Price}lv. {item.Quantity}pcs.");
            }
            Console.WriteLine(new string('*', 40));
        }

        private void FindDrinkById()
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
            Console.Write("Enter category: ");
            var category = Console.ReadLine();
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter quantity: ");
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
                Console.Write("Enter quantity: ");
                var quantity = int.Parse(Console.ReadLine());
                drink.Category = category;
                drink.Name = name;
                drink.Price = price;
                drink.Quantity = quantity;
                drinkController.Update(drink);
                Console.WriteLine("The drink was updated successfully!");
            }
        }

        private void ShowPastriesMenu()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string(' ', 13) + "PASTRIES MENU");
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("1. List all pastries.");
            Console.WriteLine("2. Found pastry by ID.");
            Console.WriteLine("3. Add pastry.");
            Console.WriteLine("4. Remove pastry.");
            Console.WriteLine("5. Update pastry.");
            Console.WriteLine("6. Return to main menu");
            Console.WriteLine(new string('*', 40));
        }

        private void ShowFruitsAndVegetablesMenu()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string(' ', 7) + "FRUITS AND VEGETABLES MENU");
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("1. List all fruts and vegetables.");
            Console.WriteLine("2. Found fruit or vegetable by ID.");
            Console.WriteLine("3. Add fruit or vegetable.");
            Console.WriteLine("4. Remove fruit or vegetable.");
            Console.WriteLine("5. Update fruit or vegetable.");
            Console.WriteLine("6. Return to main menu");
            Console.WriteLine(new string('*', 40));
        }

        private void ShowNutsMenu()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string(' ', 15) + "NUTS MENU");
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("1. List all nuts.");
            Console.WriteLine("2. Found nut by ID.");
            Console.WriteLine("3. Add nut.");
            Console.WriteLine("4. Remove nut.");
            Console.WriteLine("5. Update nut.");
            Console.WriteLine("6. Return to main menu");
            Console.WriteLine(new string('*', 40));
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

        private void Close()
        {
            Console.Write("Press any key to continue... ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
