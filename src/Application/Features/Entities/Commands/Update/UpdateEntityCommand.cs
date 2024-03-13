using Core.Application.Pipelines;

namespace Application.Features.Entities.Commands.Update;

public class UpdateEntityCommand : ICommandRequest<UpdateEntityResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public UpdateEntityCommand(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
