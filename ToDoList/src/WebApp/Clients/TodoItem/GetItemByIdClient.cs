namespace WebApp.Clients.TodoItem;

public class GetItemByIdClient
{
    private readonly HttpClient _httpClient;
    private const string Url = "http://localhost:5102/api/todo-items";

    public GetItemByIdClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<ItemByIdResponse> GetByIdAsync(Guid id)
        => await _httpClient.GetFromJsonAsync<ItemByIdResponse>($"{Url}/{id}");
}
