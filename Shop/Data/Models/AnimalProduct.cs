namespace Shop.Data.Models
{
    /// <summary>
    /// The structure of animal product table in database.
    /// </summary>
    public class AnimalProduct
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public AnimalProduct(string category, string name, decimal price, int quantity)
        {
            Category = category;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public AnimalProduct()
        {

        }
    }
}
