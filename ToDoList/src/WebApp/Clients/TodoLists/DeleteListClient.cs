namespace WebApp.Clients.TodoLists;

public class DeleteListClient
{
    private readonly HttpClient _httpClient;
    private const string Url = "http://localhost:5102/api/todo-lists";

    public DeleteListClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task DeleteListAsync(Guid Id) 
        => await _httpClient.DeleteAsync($"{Url}/{Id}");
}
