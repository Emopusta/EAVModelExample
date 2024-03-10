using Core.Application.Pipelines;
using Core.Application.Responses;

namespace Application.Features.Entities.Queries.GetAll;

public class GetAllEntityQuery : IQueryRequest<ListResponse<GetAllEntityListItemDto>>
{
}
