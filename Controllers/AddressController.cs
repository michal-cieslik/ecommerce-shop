using ecommerce_shop.Models;
using ecommerce_shop.Services;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController(AddressService addressService) : ControllerBase
    {
        private readonly AddressService _addressService = addressService;

        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAddressesAsync()
        {
            return await _addressService.GetAddressesAsync();
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
