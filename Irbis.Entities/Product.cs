namespace Irbis.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ProductType Type { get; set; }
    }
}