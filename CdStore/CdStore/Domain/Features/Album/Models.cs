namespace Domain.Features.Album;
internal sealed class Request
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Artist { get; set; }
    public string Sku { get; set; }
    public Guid StoreId { get; set; }
}

internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(album => album.);
    }
}

internal sealed class Response
{
    public string Message => "This endpoint hasn't been implemented yet!";
}
