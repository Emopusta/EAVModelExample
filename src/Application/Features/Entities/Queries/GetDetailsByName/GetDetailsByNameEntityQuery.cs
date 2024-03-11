using Core.Application.Pipelines;

namespace Application.Features.Entities.Queries.GetDetailsByName;

public class GetDetailsByNameEntityQuery : IQueryRequest<GetDetailsByNameEntityResponse>
{
    public string Name { get; set; }
}
