using BlazorApp.Data.Models;

namespace BlazorApp.Services;

public interface IShipmentProvider
{
    Task<List<Shipment>> GetAll();
    Task<Shipment> GetOne(int id);
    Task<bool> Add(Shipment item);
    Task<Shipment> Edit(Shipment item);
    Task<bool> Remove(int id);
}
