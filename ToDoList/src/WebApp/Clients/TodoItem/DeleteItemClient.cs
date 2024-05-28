namespace WebApp.Clients.TodoItem;

public class DeleteItemClient
{
    private readonly HttpClient _httpClient;
    private const string Url = "http://localhost:5102/api/todo-items";

    public DeleteItemClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task DeleteItemAsync(Guid Id) 
        => await _httpClient.DeleteAsync($"{Url}/{Id}");
}
