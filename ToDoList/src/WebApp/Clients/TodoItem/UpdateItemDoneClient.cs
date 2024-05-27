namespace WebApp.Clients.TodoItem;

public class UpdateItemDoneClient
{
    private readonly HttpClient _httpClient;
    private const string Url = "http://localhost:5102/api/todo-items/done";

    public UpdateItemDoneClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task UpdateItemDoneAsync(Guid id, ItemUpdateDoneRequest request)
        => await _httpClient.PutAsJsonAsync($"{Url}/{id}", request);
}
