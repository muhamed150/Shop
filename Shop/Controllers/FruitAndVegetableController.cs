using Shop.Data;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    /// <summary>
    /// Providers the link between the database and UI.
    /// </summary>
    public class FruitAndVegetableController
    {
        /// <summary>
        /// Database link.
        /// </summary>
        private ShopContext context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shopcontext"></param>
        public FruitAndVegetableController(ShopContext shopcontext)
        {
            context = shopcontext;
        }
        /// <summary>
        /// 
        /// </summary>
        public FruitAndVegetableController()
        {
            context = new ShopContext();
        }
        /// <summary>
        /// Gives all fruits and vegetables in the database.
        /// </summary>
        /// <returns>all fruits and vegetables from the database</returns>
        public List<FruitAndVegetable> GetAllFruitsAndVegetables()
        {
                return context.FruitsAndVegetables.ToList();
        }

        /// <summary>
        /// Gives a fruit or vegetable with the wanted Id.
        /// </summary>
        /// <param name="id">Id of the wanted fruit or vegetable</param>
        /// <returns>a fruit or vegetable with that id</returns>
        public FruitAndVegetable GetFruitOrVegetableById(int id)
        {
                return context.FruitsAndVegetables.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Adds a fruit or vegetable.
        /// </summary>
        /// <param name="fruitORvegetable">the fruit or vegetable that will be added.</param>
        public void Add(FruitAndVegetable fruitORvegetable)
        {
                context.FruitsAndVegetables.Add(fruitORvegetable);
                context.SaveChanges();
        }

        /// <summary>
        /// Updates a fruit or vegetable.
        /// </summary>
        /// <param name="fruitORvegetable">the fruit or vegetable that will be updated.</param>
        public void Update(FruitAndVegetable fruitORvegetable)
        {
                var item = context.FruitsAndVegetables.Find(fruitORvegetable.Id);
                if (item != null)
                {
                    context.Entry(item).CurrentValues.SetValues(fruitORvegetable);
                    context.SaveChanges();
                }
        }

        /// <summary>
        /// Deletes a fruit or vegetable with the wanted Id.
        /// </summary>
        /// <param name="id">Id of the wanted fruit or vegetable.</param>
        public void Delete(int id)
        {
                var item = context.FruitsAndVegetables.FirstOrDefault(m => m.Id == id);
                if (item != null)
                {
                    context.FruitsAndVegetables.Remove(item);
                    context.SaveChanges();
                }
        }
    }
}
