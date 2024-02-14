namespace ecommerce_shop.Models
{
    public class User : BasicModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; } = "User";

        public List<Order> Orders { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Review> Reviews { get; set; }
        public Cart Cart { get; set; }
    }
}
