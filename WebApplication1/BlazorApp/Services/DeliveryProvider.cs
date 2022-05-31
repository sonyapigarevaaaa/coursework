using System.Net.Http.Json;
using Newtonsoft.Json;
using BlazorApp.Data.Models;



namespace BlazorApp.Services;

public class DeliveryProvider : IDeliveryProvider
{
    private HttpClient _httpClient;
    public DeliveryProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Delivery>> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<List<Delivery>>("/api/Delivery");
    }

    public async Task<Delivery> GetOne(int id)
    {
        return await _httpClient.GetFromJsonAsync<Delivery>($"/api/Delivery/{id}");
    }

    public async Task<bool> Add(Delivery item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _httpClient.PostAsync($"/api/Delivery", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Delivery> Edit(Delivery item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _httpClient.PutAsync($"/api/Delivery", httpContent);
        Delivery delivery = JsonConvert.DeserializeObject<Delivery>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(delivery);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _httpClient.DeleteAsync($"/api/Delivery/${id}");
        return await Task.FromResult(delete.IsSuccessStatusCode);
    }
}