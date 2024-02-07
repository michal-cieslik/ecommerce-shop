using Npgsql;

namespace ecommerce_shop.Models
{
    public class BasicModel
    {
        public int Id { get; set; }
        public DateTime dateAdded { get; set; }
        public DateTime dateUpdated { get; set; } = DateTime.Now;

        public BasicModel()
        { 
        
        }
    }
}
