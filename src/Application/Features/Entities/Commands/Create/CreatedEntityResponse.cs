using Core.Application.Responses;

namespace Application.Features.Entities.Commands.Create
{
    public class CreatedEntityResponse : IResponse
    {
        public string Name { get; set; }
    }
}