using Core.Application.Responses;

namespace Application.Features.Entities.Commands.Update
{
    public class UpdateEntityResponse : IResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}