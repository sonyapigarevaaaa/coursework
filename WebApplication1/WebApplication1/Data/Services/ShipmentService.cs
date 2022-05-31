using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services
{
    public class ShipmentService
    {
        private EducationContext _context;
        public ShipmentService(EducationContext context)
        {
            _context = context;
        }


        public async Task<ShipmentDTO?> AddShipment(ShipmentDTO shipmentDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.ProductId == shipmentDTO.ProductId);
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.CustomerId == shipmentDTO.CustomerId);
            if (customer == null)
                return null;
            if (product == null)
                return null;
            Shipment shipment = new Shipment
            {
                Date = shipmentDTO.Date,
                Time = shipmentDTO.Time,
                Customer = customer,
                Product = product,

            };
            var result = _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();
            shipmentDTO.ShipmentId = result.Entity.ShipmentId;
            return await Task.FromResult(shipmentDTO);
        }

        public async Task<ShipmentDTO> GetShipment(int id)
        {
            var shipment = await _context.Shipments.Include(shipment => shipment.Product).Include(shipment => shipment.Customer).FirstOrDefaultAsync(shipment => shipment.ShipmentId == id);
            if (shipment == null)
                return null;
     
            var shipmentDTO = new ShipmentDTO
            {
                ShipmentId = shipment.ShipmentId,
                Date = shipment.Date,
                Time = shipment.Time,
                CustomerId = shipment.Customer.CustomerId,
                ProductId = shipment.Product.ProductId,

            };
            var result = _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();
            shipmentDTO.ShipmentId = result.Entity.ShipmentId;
            return await Task.FromResult(shipmentDTO);
        }
        public async Task<List<ShipmentDTO>> GetShipments()
        {
            return await _context.Shipments.Include(shipment => shipment.Product).Include(shipment => shipment.Customer).Select(shipment => new ShipmentDTO
            {
                ShipmentId = shipment.ShipmentId,
                Date = shipment.Date,
                Time = shipment.Time,
                ProductId = shipment.Product.ProductId,
                CustomerId = shipment.Customer.CustomerId

            }).ToListAsync();
        }

        public async Task<ShipmentDTO?> UpdateShipment(int id, ShipmentDTO shipmentDTO)
        {
            var shipment = await _context.Shipments.Include(shipment => shipment.Product).Include(shipment => shipment.Customer).FirstOrDefaultAsync(shipment => shipment.ShipmentId == id);
            if (shipment == null)
                return null;
            shipment.Date = shipmentDTO.Date;
            shipment.Time = shipmentDTO.Time;

            _context.Shipments.Update(shipment);
            _context.Entry(shipment).State = EntityState.Modified;
            return await Task.FromResult(shipmentDTO);
        }

        public async Task<bool> DeleteShipment(int id)
        {
            var shipment = await _context.Shipments.FirstOrDefaultAsync(au => au.ShipmentId == id);
            if (shipment != null)
            {
                _context.Shipments.Remove(shipment);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
