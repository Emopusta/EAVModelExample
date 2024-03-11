using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Entities.Queries.GetDetailsByName;

public class GetDetailsByNameEntityQueryHandler : IQueryRequestHandler<GetDetailsByNameEntityQuery, GetDetailsByNameEntityResponse>
{
    private readonly IGenericRepository<Entity> _entityRepository;

    public GetDetailsByNameEntityQueryHandler(IGenericRepository<Entity> entityRepository)
    {
        _entityRepository = entityRepository;
    }

    public async Task<GetDetailsByNameEntityResponse> Handle(GetDetailsByNameEntityQuery request, CancellationToken cancellationToken)
    {
        var entity = await _entityRepository.GetAsync(predicate: e => e.Name == request.Name,
            include: i => i
            .Include(p => p.Attributes).ThenInclude(p => p.Value),
            cancellationToken: cancellationToken);

        var response = new GetDetailsByNameEntityResponse();

        response.Name = entity.Name;

        foreach (var attribute in entity.Attributes)
        {
            response.ValueAttributePairs.Add(attribute.Name, attribute.Value.Name);
        }

        return response;
    }
}
