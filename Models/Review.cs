namespace ecommerce_shop.Models
{
    public class Review : BasicModel
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
