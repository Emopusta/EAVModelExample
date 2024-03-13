using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.Entities.Commands.Update;

public class UpdateEntityCommandHandler : IRequestHandler<UpdateEntityCommand, UpdateEntityResponse>
{
    private readonly IGenericRepository<Entity> _entityRepository;

    public UpdateEntityCommandHandler(IGenericRepository<Entity> entityRepository)
    {
        _entityRepository = entityRepository;
    }

    public async Task<UpdateEntityResponse> Handle(UpdateEntityCommand request, CancellationToken cancellationToken)
    {
        var entityToUpdate = await _entityRepository.GetAsync(p => p.Id == request.Id, cancellationToken: cancellationToken) 
            ?? throw new Exception("Entity not found.");

        entityToUpdate.Name = request.Name;

        var updatedEntity = await _entityRepository.UpdateAsync(entityToUpdate);

        UpdateEntityResponse result = new()
        {
            Id = updatedEntity.Id,
            Name = updatedEntity.Name
        };

        return result;
    }
}
