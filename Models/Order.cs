namespace ecommerce_shop.Models
{
    public class Order : BasicModel
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }

        public User User { get; set; }
    }
}
