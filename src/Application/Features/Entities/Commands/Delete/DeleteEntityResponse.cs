using Core.Application.Responses;

namespace Application.Features.Entities.Commands.Delete
{
    public class DeleteEntityResponse : IResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}