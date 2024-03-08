using Application.Features.Entities.Commands.Create;
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
    }
}
