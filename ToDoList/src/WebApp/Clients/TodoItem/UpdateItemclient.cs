namespace WebApp.Clients.TodoItem;

public class UpdateItemClient
{
    private readonly HttpClient _httpClient;
    private const string Url = "http://localhost:5102/api/todo-items";

    public UpdateItemClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task UpdateItemAsync(Guid id, ItemUpdateRequest request)
        => await _httpClient.PutAsJsonAsync($"{Url}/{id}", request);
}
