namespace ecommerce_shop.Models
{
    public class Product : BasicModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Category> Categories { get; set; }
    }
}
