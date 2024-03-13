using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;

namespace Application.Features.Entities.Commands.Delete;

public class DeleteEntityCommandHandler : ICommandRequestHandler<DeleteEntityCommand, DeleteEntityResponse>
{
    private readonly IGenericRepository<Entity> _entityRepository;

    public DeleteEntityCommandHandler(IGenericRepository<Entity> entityRepository)
    {
        _entityRepository = entityRepository;
    }

    public async Task<DeleteEntityResponse> Handle(DeleteEntityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _entityRepository.GetAsync(p => p.Id == request.Id, cancellationToken: cancellationToken) 
            ?? throw new Exception("Entity not found.");
        
        var deletedEntity = await _entityRepository.DeleteAsync(entity);

        return new DeleteEntityResponse
        {
            Id = deletedEntity.Id,
            Name = deletedEntity.Name
        };
    }
}
