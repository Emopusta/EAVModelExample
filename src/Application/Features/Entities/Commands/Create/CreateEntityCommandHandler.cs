using Core.Application.Pipelines;

namespace Application.Features.Entities.Commands.Create
{
    public class CreateEntityCommandHandler : ICommandRequestHandler<CreateEntityCommand, CreatedEntityResponse>
    {
        public Task<CreatedEntityResponse> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
