namespace WebApp.Clients.TodoLists;

public class GetAllClient
{
    private readonly HttpClient _httpClient;
    private const string Url = "http://localhost:5102/api/todo-lists";

    public GetAllClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<IEnumerable<GetAllResponse>> GetAllAsync()
    =>  await _httpClient.GetFromJsonAsync<IEnumerable<GetAllResponse>>(Url);
    
}