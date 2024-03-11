using Core.Application.Responses;

namespace Application.Features.Entities.Queries.GetDetailsByName;

public class GetDetailsByNameEntityResponse : IResponse
{
    public string Name { get; set; }
    public Dictionary<string, string> ValueAttributePairs { get; set; } = new();
}