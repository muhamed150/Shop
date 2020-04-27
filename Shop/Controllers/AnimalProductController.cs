using Shop.Data;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Controllers
{
    /// <summary>
    /// Providers the link between the database and UI.
    /// </summary>
    public class AnimalProductController
    {
        private ShopContext context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shopContext"></param>
        public AnimalProductController(ShopContext shopContext)
        {
            context = shopContext;
        }
        /// <summary>
        /// 
        /// </summary>
        public AnimalProductController()
        {
            context = new ShopContext();
        }
        /// <summary>
        /// Gives all animal products in the database.
        /// </summary>
        /// <returns>all animal products from the database</returns>
        public List<AnimalProduct> GetAllAnimalProducts()
        {
            return context.AnimalProducts.ToList();
        }

        /// <summary>
        /// Gives an animal product with wanted id. 
        /// </summary>
        /// <param name="id">id of the wanted animal product</param>
        /// <returns>a animal product with wanted id</returns>
        public AnimalProduct GetAnimalProductById(int id)
        {
            return context.AnimalProducts.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Adds an animal product in database.
        /// </summary>
        /// <param name="animalProduct">the animal product that will be added</param>
        public void Add(AnimalProduct animalProduct)
        {
                context.AnimalProducts.Add(animalProduct);
                context.SaveChanges();
        }

        /// <summary>
        /// Updates an animal product.
        /// </summary>
        /// <param name="animalProduct">the animal product that will be updated</param>
        public void Update(AnimalProduct animalProduct)
        {
                var item = context.AnimalProducts.Find(animalProduct.Id);
                if (item != null)
                {
                    context.Entry(item).CurrentValues.SetValues(animalProduct);
                    context.SaveChanges();
                }
        }
        /// <summary>
        /// Deletes a animal product with wanted id.
        /// </summary>
        /// <param name="id">id of the wanted animal product</param>
        public void Delete(int id)
        {
                var item = context.AnimalProducts.FirstOrDefault(m => m.Id == id);
                if (item != null)
                {
                    context.AnimalProducts.Remove(item);
                    context.SaveChanges();
                }
        }
    }
}