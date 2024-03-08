using Core.Application.Pipelines;

namespace Application.Features.Entities.Commands.Create
{
    public class CreateEntityCommand : ICommandRequest<CreatedEntityResponse>
    {
        public string Name { get; set; }
    }
}
