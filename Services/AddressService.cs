using ecommerce_shop.Models;
using ecommerce_shop.Data;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Services
{
    public class AddressService(DataContext context)
    {
        private readonly DataContext _dataContext = context;

        public async Task<Address> CreateAddress(Address address)
        {
            _dataContext.Addresses.Add(address);
            await _dataContext.SaveChangesAsync();
            return address;
        }

        public async Task<List<Address>> GetAddresses()
        {
            return await _dataContext.Addresses.ToListAsync();
        }

        public async Task<Address> GetAddressById(int id)
        {
            return await _dataContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            _dataContext.Addresses.Update(address);
            await _dataContext.SaveChangesAsync();
            return address;
        }

        public async Task<bool> DeleteAddress(int id)
        {
            Address address = await _dataContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null) return false;
            _dataContext.Addresses.Remove(address);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
