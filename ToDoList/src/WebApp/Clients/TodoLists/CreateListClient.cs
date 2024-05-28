namespace WebApp.Clients.TodoLists;

public class CreateListClient
{
    private readonly HttpClient _httpClient;
    private const string Url = "http://localhost:5102/api/todo-lists";

    public CreateListClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task CreateList(CreateRequest request)
        => await _httpClient.PostAsJsonAsync(Url, request);
}