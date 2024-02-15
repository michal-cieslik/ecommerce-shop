using ecommerce_shop.Models;

namespace ecommerce_shop.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddressAsync(Address newAddress);
        Task<List<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task<Address> UpdateAddressAsync(int id, Address updatedAddress);
        Task DeleteAddressAsync(int id);
    }

}
