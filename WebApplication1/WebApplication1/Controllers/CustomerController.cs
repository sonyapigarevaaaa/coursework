using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;



namespace WebApplication1.Contollers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _context;

        public CustomerController(CustomerService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            return await _context.GetCustomers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customer = await _context.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDTO>> PutCustomer(int id, [FromBody] CustomerDTO customerDTO)
        {
            var result = await _context.UpdateCustomer(id, customerDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> PostCustomer([FromBody] CustomerDTO customerDTO)
        {
            var result = await _context.AddCustomer(customerDTO);
            if (result == null)
            {
                BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.DeleteCustomer(id);
            if (customer)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}