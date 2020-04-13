using Shop.Data;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
   public class NutController
    {
        private ShopContext context;

        public List<Nut> GetAllNuts()
        {
            using (context = new ShopContext())
            {
                return context.Nuts.ToList();
            }
        }

        public Nut GetNutByName(string name) //ако се счупи промени на id
        {
            using (context = new ShopContext())
            {
                return context.Nuts.Find(name);
            }
        }

        public void Add(Nut nut)
        {
            using (context = new ShopContext())
            {
                context.Add(nut);
                context.SaveChanges();
            }
        }

        public void Update(Nut nut)
        {
            using (context = new ShopContext())
            {
                var item = context.Drinks.Find(nut.Id);
                if (item != null)
                {
                    context.Entry(item).CurrentValues.SetValues(nut);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(Nut nut)
        {
            using (context = new ShopContext())
            {
                var item = context.Drinks.Find(nut.Id);
                if (item != null)
                {
                    context.Drinks.Remove(item);
                    context.SaveChanges();
                }

            }
        }

    }
}
