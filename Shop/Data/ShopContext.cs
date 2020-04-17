using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
    /// <summary>
    /// Context to connect to the database.
    /// </summary>
    public class ShopContext : DbContext
    {
        public ShopContext() : base()
        {

        }

        public virtual DbSet<FruitAndVegetable> FruitsAndVegetables { get; set; }
        public virtual DbSet<Nut> Nuts { get; set; }
        public virtual DbSet<Pastry> Pastries { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .\\SQLEXPRESS; Database = Shop; Integrated Security = true ");
        }


    }
}

