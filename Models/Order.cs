namespace ecommerce_shop.Models
{
    public class Order : BasicModel
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
