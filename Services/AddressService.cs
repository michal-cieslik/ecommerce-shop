using ecommerce_shop.Interfaces;
using ecommerce_shop.Models;

namespace ecommerce_shop.Services
{
    public class AddressService : IAddressService
    {
        public AddressService(IAddressRepository addressRepository) 
        {
            _addressRepository = addressRepository;
        }
        private readonly IAddressRepository _addressRepository;

        public async Task<Address> CreateAddressAsync(Address address)
        {
            return await _addressRepository.CreateAddressAsync(address);
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _addressRepository.GetAllAddressesAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _addressRepository.GetAddressByIdAsync(id);
        }

        public async Task<Address> UpdateAddressAsync(int id, Address updatedAddress)
        {
            var existingAddress = await _addressRepository.GetAddressByIdAsync(id);
            if (existingAddress == null)
            {
                return null;
            }

            existingAddress.Street = updatedAddress.Street;
            existingAddress.City = updatedAddress.City;
            existingAddress.ZipCode = updatedAddress.ZipCode;
            existingAddress.Country = updatedAddress.Country;
            existingAddress.Phone = updatedAddress.Phone;
            existingAddress.DateUpdated = DateTime.Now;

            return await _addressRepository.UpdateAddressAsync(id, existingAddress);
        }

        public async Task<Address> DeleteAddressAsync(int id)
        {
            var addressToDelete = await _addressRepository.GetAddressByIdAsync(id);
            if (addressToDelete == null)
            {
                return null;
            }

            await _addressRepository.DeleteAddressAsync(id);
            return addressToDelete;
        }
    }
}
