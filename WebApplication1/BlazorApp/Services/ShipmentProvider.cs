using System.Net.Http.Json;
using Newtonsoft.Json;
using BlazorApp.Data.Models;



namespace BlazorApp.Services;

public class ShipmentProvider : IShipmentProvider
{
    private HttpClient _httpClient;
    public ShipmentProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Shipment>> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<List<Shipment>>("/api/Shipment");
    }

    public async Task<Shipment> GetOne(int id)
    {
        return await _httpClient.GetFromJsonAsync<Shipment>($"/api/Shipment/{id}");
    }

    public async Task<bool> Add(Shipment item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _httpClient.PostAsync($"/api/Shipment", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Shipment> Edit(Shipment item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _httpClient.PutAsync($"/api/Shipment", httpContent);
        Shipment shipment = JsonConvert.DeserializeObject<Shipment>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(shipment);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _httpClient.DeleteAsync($"/api/Shipment/${id}");
        return await Task.FromResult(delete.IsSuccessStatusCode);
    }
}