using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Core.Application.Responses;
using Domain.Models;

namespace Application.Features.Entities.Queries.GetAll;

public class GetAllEntityQueryHandler : IQueryRequestHandler<GetAllEntityQuery, ListResponse<GetAllEntityListItemDto>>
{
    private readonly IGenericRepository<Entity> _entityRepository;

    public GetAllEntityQueryHandler(IGenericRepository<Entity> entityRepository)
    {
        _entityRepository = entityRepository;
    }

    public async Task<ListResponse<GetAllEntityListItemDto>> Handle(GetAllEntityQuery request, CancellationToken cancellationToken)
    {
        var entities = await _entityRepository.GetListAsync(cancellationToken: cancellationToken);
        
        var response = new ListResponse<GetAllEntityListItemDto>();

        // You can use AutoMapper, Mapster... instead
        
        foreach (var entity in entities.Items) 
        {
            var mappedListItemDto = new GetAllEntityListItemDto()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            response.Items.Add(mappedListItemDto);
        }

        return response;
    }
}
