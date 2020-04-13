using Shop.Data;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    public class PastryController
    {
        private ShopContext context;
        public List<Pastry> GetAllPastries()
        {
            using (context = new ShopContext())
            {
                return context.Pastries.ToList();
            }
        }

        public Pastry GetPastryByName(string name)
        {
            using (context = new ShopContext())
            {
                return context.Pastries.Find(name);
            }
        }

        public void Add(Pastry pastry)
        {
            using (context = new ShopContext())
            {
                context.Add(pastry);
                context.SaveChanges();
            }
        }

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

        public void Delete(Pastry pastry)
        {
            using (context = new ShopContext())
            {
                var item = context.Pastries.Find(pastry.Id);
                if (item != null)
                {
                    context.Pastries.Remove(item);
                    context.SaveChanges();
                }
            }
        }
    }
}

