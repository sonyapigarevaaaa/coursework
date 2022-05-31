using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.DTOs;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Services
{
    public class DeliveryService
    {
        private EducationContext _context;
        public DeliveryService(EducationContext context)
        {
            _context = context;
        }


        public async Task<DeliveryDTO?> AddDelivery(DeliveryDTO deliveryDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.ProductId == deliveryDTO.ProductId);
            
            if (product == null)
                return null;
            Delivery delivery = new Delivery
            {
                Date = deliveryDTO.Date,
                Time = deliveryDTO.Time,
                Product = product,

            };
            var result = _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();
            deliveryDTO.DeliveryId = result.Entity.DeliveryId;
            return await Task.FromResult(deliveryDTO);
        }

        public async Task<DeliveryDTO> GetDelivery(int id)
        {
            var delivery = await _context.Deliveries.Include(delivery => delivery.Product).FirstOrDefaultAsync(delivery => delivery.DeliveryId == id);
            if (delivery == null)
                return null;

            var deliveryDTO = new DeliveryDTO
            {
                DeliveryId = delivery.DeliveryId,
                Date = delivery.Date,
                Time = delivery.Time,
                ProductId = delivery.Product.ProductId,

            };
            var result = _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();
            deliveryDTO.DeliveryId = result.Entity.DeliveryId;
            return await Task.FromResult(deliveryDTO);
        }
        public async Task<List<DeliveryDTO>> GetDeliveries()
        {
            return await _context.Deliveries.Include(delivery => delivery.Product).Select(delivery => new DeliveryDTO
            {
                DeliveryId = delivery.DeliveryId,
                Date = delivery.Date,
                Time = delivery.Time,
                ProductId = delivery.Product.ProductId,

            }).ToListAsync();
        }

        public async Task<DeliveryDTO?> UpdateDelivery(int id, DeliveryDTO deliveryDTO)
        {
            var delivery = await _context.Deliveries.Include(delivery => delivery.Product).FirstOrDefaultAsync(delivery => delivery.DeliveryId == id);
            if (delivery == null)
                return null;
            delivery.Date = deliveryDTO.Date;
            delivery.Time = deliveryDTO.Time;

            _context.Deliveries.Update(delivery);
            _context.Entry(delivery).State = EntityState.Modified;
            return await Task.FromResult(deliveryDTO);
        }

        public async Task<bool> DeleteDelivery(int id)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(au => au.DeliveryId == id);
            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
