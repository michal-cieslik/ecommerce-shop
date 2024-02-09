using ecommerce_shop.Data;
using ecommerce_shop.Interfaces;
using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Repositories
{
    public class AddressRepository(DataContext context) : IAddressRepository
    {

        private readonly DataContext _context = context;

        public async Task<Address> CreateAddressAsync(Address newAddress)
        {
            _context.Addresses.Add(newAddress);
            await _context.SaveChangesAsync();
            return newAddress;
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Address> UpdateAddressAsync(int id, Address updatedAddress)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            if (address != null)
            {
                address.Street = updatedAddress.Street;
                address.City = updatedAddress.City;
                address.ZipCode = updatedAddress.ZipCode;
                address.Country = updatedAddress.Country;
                address.Phone = updatedAddress.Phone;
                address.DateUpdated = DateTime.Now;
                await _context.SaveChangesAsync();

            }
            return address;
        }

        public async Task DeleteAddressAsync(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}
