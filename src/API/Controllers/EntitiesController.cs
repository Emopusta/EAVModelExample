using Application.Features.Entities.Commands.Create;
using Application.Features.Entities.Queries.GetAll;
using Core.Application.Responses;
using Core.Utils.Results;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : BaseController
    {
        [HttpPost]
        public async Task<IDataResult<CreatedEntityResponse>> Create([FromBody] string name, CancellationToken cancellationToken)
        {
            var command = new CreateEntityCommand() { Name = name };
            var response = await Mediator.Send(command, cancellationToken);
            return Success(response);
        }

        [HttpGet]
        public async Task<IDataResult<ListResponse<GetAllEntityListItemDto>>> GetAll(CancellationToken cancellationToken)
        {
            var command = new GetAllEntityQuery();
            var response = await Mediator.Send(command, cancellationToken);
            return Success(response);
        }
    }
}
