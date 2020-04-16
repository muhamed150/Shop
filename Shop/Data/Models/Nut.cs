namespace Shop.Data.Models
{
    /// <summary>
    /// The structure of the Nut table in the database. 
    /// </summary>
    public class Nut
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
