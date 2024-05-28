namespace WebApp.Clients.TodoLists;

public class UpdateListClient
{
    private readonly HttpClient _httpClient;
    private const string Url = "http://localhost:5102/api/todo-lists";

    public UpdateListClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task UpdateListAsync(Guid id, UpdateRequest request)
        => await _httpClient.PutAsJsonAsync($"{Url}/{id}", request);
}
