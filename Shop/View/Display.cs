using System;
using Shop.Controllers;
using Shop.Data;

namespace Shop.View
{
    public class Display
    {

        private DrinkController drinkController;
        private NutController nutController;
        private FruitAndVegetableController fruitAndVegetableController;
        private PastryController pastryController;
        private const int closeOperationId = 5;
        private const int rertunOperationId = 7;
        public Display(ShopContext context)
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
            Console.WriteLine(new string(' ',18) + "MAIN MENU");
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

            } while (operation!=closeOperationId);  
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
            var operation = -1;
            do
            {
                ShowDrinksMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    default:
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while ();

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
                Console.WriteLine(new string(' ', 18) + "DRINKS MENU");
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("1. List all drinks.");
                Console.WriteLine("2. Get drink by name."); //ако има проблем id 
                Console.WriteLine("3. Add drink.");
                Console.WriteLine("4. Remove drink.");
                Console.WriteLine("5. Update drink.");
                Console.WriteLine("6. Sell drink.");
                Console.WriteLine("7. Return to main menu");
                Console.WriteLine(new string('*', 40));  

        }

    }
}
