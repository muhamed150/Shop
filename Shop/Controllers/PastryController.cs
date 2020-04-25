using Shop.Data;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    /// <summary>
    /// Provides the link between the database and the UI. 
    /// </summary>
    public class PastryController
    {
        /// <summary>
        /// Database link.
        /// </summary>
        private ShopContext context;
        public PastryController(ShopContext shopContext)
        {
            context = shopContext;
        }
        public List<Pastry> GetAllPastries()
        {
            using (context = new ShopContext())
            {
                return context.Pastries.ToList();
            }
        }

        /// <summary>
        /// Gives a Pastry with the wanted Id.
        /// </summary>
        /// <param name="id">Id of the wanted pastry</param>
        /// <returns>a pastry with that id</returns>
        public Pastry GetPastryById(int id)
        {
            using (context = new ShopContext())
            {
                return context.Pastries.FirstOrDefault(m => m.Id == id);
            }
        }

        /// <summary>
        /// Adds a Pastry.
        /// </summary>
        /// <param name="pastry">the pastry that will be added</param>
        public void Add(Pastry pastry)
        {
            using (context = new ShopContext())
            {
                context.Pastries.Add(pastry);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a Pastry.
        /// </summary>
        /// <param name="pastry">the pastry that will be updated</param>
        public void Update(Pastry pastry)
        {
            using (context = new ShopContext())
            {
                var item = context.Pastries.Find(pastry.Id);
                if (item != null)
                {
                    context.Entry(item).CurrentValues.SetValues(pastry);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deletes a Pastry with the wanted Id.
        /// </summary>
        /// <param name="id">Id of the wanted pastry</param>
        public void Delete(int id)
        {
            using (context = new ShopContext())
            {
                var item = context.Pastries.FirstOrDefault(m => m.Id == id);
                if (item != null)
                {
                    context.Pastries.Remove(item);
                    context.SaveChanges();
                }
            }
        }
    }
}