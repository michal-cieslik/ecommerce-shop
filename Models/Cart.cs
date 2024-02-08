namespace ecommerce_shop.Models
{
    public class Cart : BasicModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}
