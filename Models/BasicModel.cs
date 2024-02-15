namespace ecommerce_shop.Models
{
    public class BasicModel
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; } = DateTime.Now;

        public BasicModel()
        { 
        
        }
    }
}