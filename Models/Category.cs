namespace ecommerce_shop.Models
{
    public class Category : BasicModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
