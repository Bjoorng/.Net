namespace WebApp.Clients.TodoLists;

public class CreateItemClient
{
    private readonly HttpClient _httpClient;
    private const string Url = "http://localhost:5102/api/todo-lists";

    public CreateItemClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task CreateItemAsync(CreateItemRequest request, Guid Id)
    {
        await _httpClient.PostAsJsonAsync($"{Url}/{Id}/todo-item", request);
    }
}
