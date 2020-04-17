﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<FruitAndVegetable> FruitsAndVegetables { get; set; }
        public DbSet<Nut> Nuts { get; set; }
        public DbSet<Pastry> Pastries { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .\\SQLEXPRESS; Database = Shop; Integrated Security = true ");
        }


    }
}

