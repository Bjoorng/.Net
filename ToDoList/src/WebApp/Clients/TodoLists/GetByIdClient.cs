namespace WebApp.Clients.TodoLists;

public class GetByIdClient
{
    private readonly HttpClient _httpClient;
    private const string Url = "http://localhost:5102/api/todo-lists";

    public GetByIdClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<GetByIdResponse> GetByIdAsync(Guid id)
        =>  await _httpClient.GetFromJsonAsync<GetByIdResponse>($"{Url}/{id}");
}