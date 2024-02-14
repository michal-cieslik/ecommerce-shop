namespace ecommerce_shop.Models
{
    public class Cart : BasicModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
