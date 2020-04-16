using System;
using System.Collections.Generic;
using Shop.Controllers;
using Shop.Data;
using Shop.Data.Models;

namespace Shop.View
{
    /// <summary>
    /// User interface.
    /// </summary>
    public class Display
    {
        private const int CLOSE_OPERATION_ID = 5;
        private const int RETURN_OPERATION_ID = 6;
        private DrinkController drinkController;
        private NutController nutController;
        private FruitAndVegetableController fruitAndVegetableController;
        private PastryController pastryController;

        /// <summary>
        /// Initialize controllers. 
        /// </summary>
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
                    default:
                        break;
                }

            } while (operation != RETURN_OPERATION_ID);

        }

        private void ListAllPastries()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string(' ', 16) + "PASTRY");
            Console.WriteLine(new string('*', 40));
            var pastries = pastryController.GetAllPastries();
            foreach (var item in pastries)
            {
                Console.WriteLine($"{item.Id} {item.Category} {item.Name} {item.Price}lv/pcs {item.Quantity}pcs.");
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
                Console.WriteLine("Price: " + pastry.Price + "lv/pcs");
                Console.WriteLine("Quantity: " + pastry.Quantity + "pcs.");
                Console.WriteLine(new string('*', 40));
            }
            else
            {
                Console.WriteLine("The product was not found!");
            }
        }

        private void AddPastry()
        {
            Pastry pastry = new Pastry();
            var elements = ReadElements();
            pastry.Category = elements[0];
            pastry.Name = elements[1];
            pastry.Price = decimal.Parse(elements[2]);
            pastry.Quantity = int.Parse(elements[3]);
            pastryController.Add(pastry);
            Console.WriteLine("The product was successfully added!");
        }

        private void RemovePastry()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var pastry = pastryController.GetPastryById(id);
            if (pastry != null)
            {
                pastryController.Delete(pastry.Id);
                Console.WriteLine("Тhe product was deleted successfully!");
            }
            else
            {
                Console.WriteLine("The product was not found!");
            }
        }

        private void UpdatePastry()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var pastry = pastryController.GetPastryById(id);
            if (pastry != null)
            {
                Console.WriteLine($"{pastry.Id} {pastry.Category} {pastry.Name} {pastry.Price}lv/pcs {pastry.Quantity}pcs.");
                var elements = ReadElements();
                pastry.Category = elements[0];
                pastry.Name = elements[1];
                pastry.Price = decimal.Parse(elements[2]);
                pastry.Quantity = int.Parse(elements[3]);
                pastryController.Update(pastry);
                Console.WriteLine("The product was updated successfully!");
            }
            else
            {
                Console.WriteLine("The product was not found");
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
                Console.WriteLine($"{item.Id} {item.Category} {item.Name} {item.Price}lv/kg {item.Quantity}kg.");
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
                Console.WriteLine("Price: " + fruitOrVegetable.Price + "lv/kg");
                Console.WriteLine("Quantity: " + fruitOrVegetable.Quantity + "kg.");
                Console.WriteLine(new string('*', 40));
            }
            else
            {
                Console.WriteLine("The product was not found!");
            }
        }

        private void AddFruitOrVegetable()
        {
            FruitAndVegetable fruitOrVegetable = new FruitAndVegetable();
            var elements = ReadElements();
            fruitOrVegetable.Category = elements[0];
            fruitOrVegetable.Name = elements[1];
            fruitOrVegetable.Price = decimal.Parse(elements[2]);
            fruitOrVegetable.Quantity = int.Parse(elements[3]);
            fruitAndVegetableController.Add(fruitOrVegetable);
            Console.WriteLine("The product was successfully added!");
        }

        private void RemoveFruitOrVegetable()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var fruitOrVegetable = fruitAndVegetableController.GetFruitOrVegetableById(id);
            if (fruitOrVegetable != null)
            {
                fruitAndVegetableController.Delete(fruitOrVegetable.Id);
                Console.WriteLine("Тhe product was deleted successfully!");
            }
            else
            {
                Console.WriteLine("The product was not found!");
            }
        }

        private void UpdateFruitOrVegetable()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var fruitOrVegetable = fruitAndVegetableController.GetFruitOrVegetableById(id);
            if (fruitOrVegetable != null)
            {
                Console.WriteLine($"{fruitOrVegetable.Id} {fruitOrVegetable.Category} {fruitOrVegetable.Name} {fruitOrVegetable.Price}lv/kg {fruitOrVegetable.Quantity}kg.");
                var elements = ReadElements();
                fruitOrVegetable.Category = elements[0];
                fruitOrVegetable.Name = elements[1];
                fruitOrVegetable.Price = decimal.Parse(elements[2]);
                fruitOrVegetable.Quantity = int.Parse(elements[3]);
                fruitAndVegetableController.Update(fruitOrVegetable);
                Console.WriteLine("The product was updated successfully!");
            }
            else
            {
                Console.WriteLine("The product was not found");
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
                Console.WriteLine($"{item.Id} {item.Category} {item.Name} {item.Price}lv/kg {item.Quantity}kg.");
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
                Console.WriteLine("Price: " + nut.Price + "lv/kg");
                Console.WriteLine("Quantity: " + nut.Quantity + "kg.");
                Console.WriteLine(new string('*', 40));
            }
            else
            {
                Console.WriteLine("The product was not found!");
            }
        }

        private void AddNut()
        {
            Nut nut = new Nut();
            var elements = ReadElements();
            nut.Category = elements[0];
            nut.Name = elements[1];
            nut.Price = decimal.Parse(elements[2]);
            nut.Quantity = int.Parse(elements[3]);
            nutController.Add(nut);
            Console.WriteLine("The product was successfully added!");
        }

        private void RemoveNut()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var nut = nutController.GetNutById(id);
            if (nut!=null)
            {
                nutController.Delete(nut.Id);
                Console.WriteLine("Тhe product was deleted successfully!");
            }
            else
            {
                Console.WriteLine("The product was not found!");
            }
           
        }

        private void UpdateNut()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var nut = nutController.GetNutById(id);
            if (nut != null)
            {
                Console.WriteLine($"{nut.Id} {nut.Category} {nut.Name} {nut.Price}lv/kg {nut.Quantity}kg.");
                var elements = ReadElements();
                nut.Category = elements[0];
                nut.Name = elements[1];
                nut.Price = decimal.Parse(elements[2]);
                nut.Quantity = int.Parse(elements[3]);
                nutController.Update(nut);
                Console.WriteLine("The product was updated successfully!");
            }
            else
            {
                Console.WriteLine("The product was not found");
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
                Console.WriteLine($"{item.Id} {item.Category} {item.Name} {item.Price}lv/pcs {item.Quantity}pcs.");
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
                Console.WriteLine("Price: " + drink.Price + "lv/pcs");
                Console.WriteLine("Quantity: " + drink.Quantity + "pcs.");
                Console.WriteLine(new string('*', 40));
            }
            else
            {
                Console.WriteLine("The product was not found!");
            }
        }

        private void AddDrink()
        {
            Drink drink = new Drink();
            var elements = ReadElements();
            drink.Category = elements[0];
            drink.Name = elements[1];
            drink.Price = decimal.Parse(elements[2]);
            drink.Quantity = int.Parse(elements[3]);
            drinkController.Add(drink);
            Console.WriteLine("The product was successfully added!");
        }

        private void RemoveDrink()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Drink drink = drinkController.GetDrinkById(id);
            if (drink!=null)
            {
                drinkController.Delete(drink.Id);
                Console.WriteLine("Тhe product was deleted successfully!");
            }
            else
            {
                Console.WriteLine("The product was not found!");
            }
            
        }

        private void UpdateDrink()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Drink drink = drinkController.GetDrinkById(id);
            if (drink!=null)
            {
                Console.WriteLine($"ID: {drink.Id} Category: {drink.Category} Name: {drink.Name} Price: {drink.Price}lv/pcs {drink.Quantity}pcs.");
                var elements = ReadElements();
                drink.Category = elements[0];
                drink.Name = elements[1];
                drink.Price = decimal.Parse(elements[2]);
                drink.Quantity = int.Parse(elements[3]);
                drinkController.Update(drink);
                Console.WriteLine("The drink was updated successfully!");
            }
            else
            {
                Console.WriteLine("The product was not found!");
            }
        }

        private void ShowPastriesMenu()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string(' ', 13) + "PASTRY MENU");
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
            Console.WriteLine("1. List all fruts and vegetables");
            Console.WriteLine("2. Found fruit or vegetable by ID");
            Console.WriteLine("3. Add fruit or vegetable");
            Console.WriteLine("4. Remove fruit or vegetable");
            Console.WriteLine("5. Update fruit or vegetable");
            Console.WriteLine("6. Return to main menu");
            Console.WriteLine(new string('*', 40));
        }

        private void ShowNutsMenu()
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string(' ', 15) + "NUTS MENU");
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("1. List all nuts");
            Console.WriteLine("2. Found nut by ID");
            Console.WriteLine("3. Add nut");
            Console.WriteLine("4. Remove nut");
            Console.WriteLine("5. Update nut");
            Console.WriteLine("6. Return to main menu");
            Console.WriteLine(new string('*', 40));
        }

        private void ShowDrinksMenu()
        {
                Console.WriteLine(new string('*', 40));
                Console.WriteLine(new string(' ', 15) + "DRINKS MENU");
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("1. List all drinks");
                Console.WriteLine("2. Found drink by ID");
                Console.WriteLine("3. Add drink");
                Console.WriteLine("4. Remove drink");
                Console.WriteLine("5. Update drink");
                Console.WriteLine("6. Return to main menu");
                Console.WriteLine(new string('*', 40));
        }

        private void Close()
        {
            Console.Write("Press any key to continue... ");
            Console.ReadKey();
            Console.Clear();
        }

        private List<string> ReadElements()
        {
            var list = new List<string>();
            Console.Write("Enter category: ");
            list.Add(Console.ReadLine());
            Console.Write("Enter name: ");
            list.Add(Console.ReadLine());
            Console.Write("Enter price: ");
            list.Add(Console.ReadLine());
            Console.Write("Enter quantity: ");
            list.Add(Console.ReadLine());
            return list;
        }
    }
}
