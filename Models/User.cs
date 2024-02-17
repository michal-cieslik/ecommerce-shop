using Microsoft.AspNetCore.Identity;

namespace ecommerce_shop.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
