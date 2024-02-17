namespace ecommerce_shop.Models
{
    public class Product : BasicModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
