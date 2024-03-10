using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;

namespace Application.Features.Entities.Commands.Create
{
    public class CreateEntityCommandHandler : ICommandRequestHandler<CreateEntityCommand, CreatedEntityResponse>
    {
        private readonly IGenericRepository<Entity> _entityRepository;

        public CreateEntityCommandHandler(IGenericRepository<Entity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<CreatedEntityResponse> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
        {
            var entityToAdd = new Entity() { Name = request.Name };

            var addedEntity = await _entityRepository.AddAsync(entityToAdd);

            return new CreatedEntityResponse() { Name = addedEntity.Name };
        }
    }
}
