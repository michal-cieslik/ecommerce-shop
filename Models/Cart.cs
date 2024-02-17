namespace ecommerce_shop.Models
{
    public class Cart : BasicModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}