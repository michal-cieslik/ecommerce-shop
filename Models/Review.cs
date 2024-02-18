namespace ecommerce_shop.Models
{
    public class Review : BasicModel
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }

        internal virtual Product Product { get; set; }
        internal virtual User User { get; set; }
    }
}
