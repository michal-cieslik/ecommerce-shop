namespace ecommerce_shop.Models
{
    public class Order : BasicModel
    {
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual User User { get; set; }
    }
}
