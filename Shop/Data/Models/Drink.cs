﻿namespace Shop.Data.Models
{
    /// <summary>
    /// The structure of drink table in database.
    /// </summary>
    public class Drink
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}