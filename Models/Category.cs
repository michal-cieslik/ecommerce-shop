namespace ecommerce_shop.Models
{
    public class Category : BasicModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
