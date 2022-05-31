using BlazorApp.Data.Models;

namespace BlazorApp.Services;

public interface IDeliveryProvider
{
    Task<List<Delivery>> GetAll();
    Task<Delivery> GetOne(int id);
    Task<bool> Add(Delivery item);
    Task<Delivery> Edit(Delivery item);
    Task<bool> Remove(int id);
}
