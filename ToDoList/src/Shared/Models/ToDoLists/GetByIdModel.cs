namespace Shared.Models.ToDoLists;

public record GetByIdRequest(Guid Id);
public record GetByIdResponse(Guid Id, string Text, bool IsDone, List<ItemForListResponse> ListItems);

public record ItemForListResponse(Guid Id, string Text, bool IsDone, string CreatedBy, DateTimeOffset CreatedIn);
