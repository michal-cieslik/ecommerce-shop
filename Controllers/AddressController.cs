using ecommerce_shop.Models;
using Microsoft.AspNetCore.Mvc;
using ecommerce_shop.Services;
using ecommerce_shop.Data;
using ecommerce_shop.Repositories;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public AddressController(DataContext context) : base()
        {
            var _addressRepository = new AddressRepository(context);
            _addressService = new AddressService(_addressRepository);
        }
        private readonly AddressService _addressService;

        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAllAddressesAsync()
        {
            return await _addressService.GetAllAddressesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddressByIdAsync(int id)
        {
            return await _addressService.GetAddressByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddressAsync(Address address)
        {
            return await _addressService.CreateAddressAsync(address);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Address>> UpdateAddressAsync(int id, [FromBody] Address address)
        {
            return await _addressService.UpdateAddressAsync(id, address);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddressAsync(int id)
        {
            return await _addressService.DeleteAddressAsync(id);
        }
    }
}
