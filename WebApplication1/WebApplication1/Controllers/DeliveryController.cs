using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;



namespace WebApplication1.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly DeliveryService _context;

        public DeliveryController(DeliveryService context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<DeliveryDTO>>> GetDeliveries()
        {
            return await _context.GetDeliveries();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDTO>> GetDelivery(int id)
        {
            var delivery = await _context.GetDelivery(id);
            if (delivery == null)
            {
                return NotFound();
            }
            return delivery;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryDTO>> PutAuthor(int id, [FromBody] DeliveryDTO deliveryDTO)
        {
            var result = await _context.UpdateDelivery(id, deliveryDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Delivery>> PostDelivery([FromBody] DeliveryDTO deliveryDTO)
        {
            var result = await _context.AddDelivery(deliveryDTO);
            if (result == null)
            {
                BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var delivery = await _context.DeleteDelivery(id);
            if (delivery)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}