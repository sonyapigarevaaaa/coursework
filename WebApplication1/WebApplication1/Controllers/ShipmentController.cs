using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.Services;
using WebApplication1.Data.DTOs;

namespace WebApplication1.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly ShipmentService _context;

        public ShipmentController(ShipmentService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipmentDTO>>> GetShipments()
        {
            return await _context.GetShipments();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentDTO>> GetShipment(int id)
        {
            var shipment = await _context.GetShipment(id);
            if (shipment == null)
            {
                return NotFound();
            }
            return shipment;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Shipment>> PutShipment(int id, [FromBody] ShipmentDTO shipmentDTO)
        {
            var result = await _context.UpdateShipment(id, shipmentDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ShipmentDTO>> PostShipment([FromBody] ShipmentDTO shipmentDTO)
        {
            var result = await _context.AddShipment(shipmentDTO);
            if (result == null)
            {
                BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(int id)
        {
            var shipment = await _context.DeleteShipment(id);
            if (shipment)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}