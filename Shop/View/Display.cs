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
        private const int CLOSE_OPERATION_ID = 6;
        private const int RETURN_OPERATION_ID = 6;
        private DrinkController drinkController;
        private NutController nutController;
        private FruitAndVegetableController fruitAndVegetableController;
        private PastryController pastryController;
        private AnimalProductController animalProductController;

        /// <summary>
        /// Initialize controllers. 
        /// </summary>
        public Display()
        {
            drinkController = new DrinkController(new ShopContext());
            nutController = new NutController(new ShopContext());
            fruitAndVegetableController = new FruitAndVegetableController(new ShopContext());
            pastryController = new PastryController(new ShopContext());
            animalProductController = new AnimalProductController(new ShopContext());
            HandleInput();
        }

        private void ShowMainMenu()
        {
            Console.WriteLine(new string('*',40));
            Console.Write(new string(' ',15));
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" MAIN MENU ");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Go to pastries");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("2. Go to fruits and vegetables");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("3. Go to nuts");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("4. Go to drinks");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("5. Go to animal products");// we need to add color
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("6. Exit");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
        }

        public enum Colour
        {
            Blue = 0x00000001,
            Green = 0x00000002,
            Red = 0x00000004,
            Intensity = 0x00000008
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
                    case 5:
                        AnimalProductsInput();
                        break;
                    default:
                        break;
                }
                
            } while (operation != CLOSE_OPERATION_ID);
        }

        private void AnimalProductsInput()
        {
            Console.Clear();
            var operation = -1;
            do
            {
                ShowAnimalsProductsMenu();
                Console.Write("Enter number: ");
                operation = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (operation)
                {
                    case 1:
                        ListAllAnimalProducts();
                        Close();
                        break;
                    case 2:
                        FindAnimalProductById();
                        Close();
                        break;
                    case 3:
                        AddAnimalProduct();
                        Close();
                        break;
                    case 4:
                        RemoveAnimalProduct();
                        Close();
                        break;
                    case 5:
                        UpdateAnimalProduct();
                        Close();
                        break;
                    default:
                        break;
                }

            } while (operation != RETURN_OPERATION_ID);
        }

        private void UpdateAnimalProduct()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var animalProduct = animalProductController.GetAnimalProductById(id);
            if (animalProduct != null)
            {
                Console.WriteLine($"{animalProduct.Id} {animalProduct.Category} {animalProduct.Name} {animalProduct.Price}lv/kg {animalProduct.Quantity}kg.");
                var elements = ReadElements();
                animalProduct.Category = elements[0];
                animalProduct.Name = elements[1];
                animalProduct.Price = decimal.Parse(elements[2]);
                animalProduct.Quantity = int.Parse(elements[3]);
                animalProductController.Update(animalProduct);
                Console.WriteLine("The product was updated successfully!");
            }
            else
            {
                Console.WriteLine("The product was not found");
            }
        }

        private void RemoveAnimalProduct()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var animalProduct = animalProductController.GetAnimalProductById(id);
            if (animalProduct != null)
            {
                animalProductController.Delete(animalProduct.Id);
                Console.WriteLine("Тhe product was deleted successfully!");
            }
            else
            {
                Console.WriteLine("The product was not found!");
            }
        }

        private void AddAnimalProduct()
        {
            var elements = ReadElements();
            AnimalProduct animalProduct = new AnimalProduct(elements[0], elements[1], decimal.Parse(elements[2]), int.Parse(elements[3]));
            animalProductController.Add(animalProduct);
            Console.WriteLine("The product was successfully added!");
        }

        private void FindAnimalProductById()
        {
            Console.Write("Enter ID: ");
            var id = int.Parse(Console.ReadLine());
            var animalProduct = animalProductController.GetAnimalProductById(id);
            if (animalProduct != null)
            {
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("ID: " + animalProduct.Id);
                Console.WriteLine("Category: " + animalProduct.Category);
                Console.WriteLine("Name: " + animalProduct.Name);
                Console.WriteLine("Price: " + animalProduct.Price + "lv/kg");
                Console.WriteLine("Quantity: " + animalProduct.Quantity + "kg.");
                Console.WriteLine(new string('*', 40));
            }
            else
            {
                Console.WriteLine("The product was not found!");
            }
        }

        private void ListAllAnimalProducts()
        {
            Console.WriteLine(new string('*', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(" ANIMAL PRODUCTS ");
            Console.WriteLine(new string('*', 40));
            var animalProducts = animalProductController.GetAllAnimalProducts();
            foreach (var item in animalProducts)
            {
                Console.Write($"{item.Id}");
                Console.WriteLine($" {item.Category} {item.Name} {item.Price}lv/kg {item.Quantity}kg.");
            }
            Console.WriteLine(new string('*', 40));
        }

        private void ShowAnimalsProductsMenu()
        {
            Console.WriteLine(new string('*', 40));
            Console.Write(new string(' ', 10));
            Console.WriteLine(" ANIMAL PRODUCTS MENU ");
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("1. List all animal products");
            Console.WriteLine("2. Found animal product by ID");
            Console.WriteLine("3. Add animal product");
            Console.WriteLine("4. Remove animal product");
            Console.WriteLine("5. Update animal product");
            Console.WriteLine("6. Return to main menu");
            Console.WriteLine(new string('*', 40));
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
            Console.Write(new string(' ', 16));
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" PASTRY ");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
            var pastries = pastryController.GetAllPastries();
            foreach (var item in pastries)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{item.Id}");
                Console.ResetColor();
                Console.WriteLine($" {item.Category} {item.Name} {item.Price}lv/pcs {item.Quantity}pcs.");
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
            var elements = ReadElements();
            Pastry pastry = new Pastry(elements[0],elements[1],decimal.Parse(elements[2]),int.Parse(elements[3]));
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
            Console.Write(new string(' ', 10));
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" FRUITS AND VEGETABLES ");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
            var fruitsAndVegetables = fruitAndVegetableController.GetAllFruitsAndVegetables();
            foreach (var item in fruitsAndVegetables)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{item.Id}");
                Console.ResetColor();
                Console.WriteLine($" {item.Category} {item.Name} {item.Price}lv/kg {item.Quantity}kg.");
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
            var elements = ReadElements();
            FruitAndVegetable fruitOrVegetable = new FruitAndVegetable(elements[0], elements[1], decimal.Parse(elements[2]), int.Parse(elements[3]));
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
            Console.Write(new string(' ', 18));
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(" NUTS ");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
            var nuts = nutController.GetAllNuts();
            foreach (var item in nuts)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{item.Id}");
                Console.ResetColor();
                Console.WriteLine($" {item.Category} {item.Name} {item.Price}lv/kg {item.Quantity}kg.");
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
            var elements = ReadElements();
            Nut nut = new Nut(elements[0], elements[1], decimal.Parse(elements[2]), int.Parse(elements[3]));
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
            Console.Write(new string(' ', 18));
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" DRINKS ");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
            var drinks = drinkController.GetAllDrinks();
            foreach (var item in drinks)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write($"{item.Id}");
                Console.ResetColor();
                Console.WriteLine($" {item.Category} {item.Name} {item.Price}lv/pcs {item.Quantity}pcs.");
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
            var elements = ReadElements();
            Drink drink = new Drink(elements[0], elements[1], decimal.Parse(elements[2]), int.Parse(elements[3]));
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
            Console.Write(new string(' ', 13));
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" PASTRY MENU ");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("1. List all pastries");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("2. Found pastry by ID");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("3. Add pastry");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("4. Remove pastry");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("5. Update pastry");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("6. Return to main menu");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
        }

        private void ShowFruitsAndVegetablesMenu()
        {
            Console.WriteLine(new string('*', 40));
            Console.Write(new string(' ', 6));
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" FRUITS AND VEGETABLES MENU ");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("1. List all fruts and vegetables");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("2. Found fruit or vegetable by ID");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("3. Add fruit or vegetable");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("4. Remove fruit or vegetable");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("5. Update fruit or vegetable");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("6. Return to main menu");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
        }

        private void ShowNutsMenu()
        {
            Console.WriteLine(new string('*', 40));
            Console.Write(new string(' ', 16));
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(" NUTS MENU ");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("1. List all nuts");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("2. Found nut by ID");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("3. Add nut");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("4. Remove nut");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("5. Update nut");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("6. Return to main menu");
            Console.ResetColor();
            Console.WriteLine(new string('*', 40));
        }

        private void ShowDrinksMenu()
        {
                Console.WriteLine(new string('*', 40));
                Console.Write(new string(' ', 15));
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(" DRINKS MENU ");
                Console.ResetColor();
                Console.WriteLine(new string('*', 40));
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("1. List all drinks");
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("2. Found drink by ID");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("3. Add drink");
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("4. Remove drink");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("5. Update drink");
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("6. Return to main menu");
                Console.ResetColor();
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
