using ecommerce_shop.Models;

namespace ecommerce_shop.Interfaces
{
    public interface IAddressService
    {
        Task<Address> RegisterAddressAsync(Address newAddress);
        Task<List<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task<Address> UpdateAddressAsync(int id, Address updatedAddress);
        Task<Address> DeleteAddressAsync(int id);
    }

}