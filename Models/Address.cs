namespace ecommerce_shop.Models
{
    public class Address : BasicModel
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
