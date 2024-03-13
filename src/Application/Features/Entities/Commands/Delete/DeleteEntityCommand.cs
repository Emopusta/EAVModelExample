using Core.Application.Pipelines;

namespace Application.Features.Entities.Commands.Delete;

public class DeleteEntityCommand : ICommandRequest<DeleteEntityResponse>
{
    public int Id { get; set; }

    public DeleteEntityCommand(int id)
    {
        Id = id;
    }
}
