using Shared.Models.ToDoLists;
using System.Net.Http.Json;

namespace WebApp.Services.TodoList;

public class GetAllService
{
    private readonly HttpClient _httpClient;

    public GetAllService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<GetAllResponse>> GetAllAsync(string url)
    {
        var getAllResponse = await _httpClient.GetFromJsonAsync<IEnumerable<GetAllResponse>>(url);
        return getAllResponse;
    }
}