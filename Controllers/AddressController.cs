using ecommerce_shop.Models;
using Microsoft.AspNetCore.Mvc;
using ecommerce_shop.Services;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController(AddressService addressService) : ControllerBase
    {
        private readonly AddressService _addressService = addressService;

        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAddresses()
        {
            return await _addressService.GetAddresses();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddressById(int id)
        {
            return await _addressService.GetAddressById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress(Address address)
        {
            return await _addressService.CreateAddress(address);
        }

        [HttpPut]
        public async Task<ActionResult<Address>> UpdateAddress(Address address)
        {
            return await _addressService.UpdateAddress(address);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAddress(int id)
        {
            return await _addressService.DeleteAddress(id);
        }
    }
}
