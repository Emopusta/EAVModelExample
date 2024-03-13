using API.Dtos;
using Application.Features.Entities.Commands.Create;
using Application.Features.Entities.Commands.Delete;
using Application.Features.Entities.Commands.Update;
using Application.Features.Entities.Queries.GetAll;
using Application.Features.Entities.Queries.GetDetailsByName;
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

        [HttpDelete("{id:int}")]
        public async Task<IDataResult<DeleteEntityResponse>> Delete([FromRoute] int id,CancellationToken cancellationToken)
        {
            var command = new DeleteEntityCommand() { Id = id };
            var response = await Mediator.Send(command, cancellationToken);
            return Success(response);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateEntityResponse>> Update([FromBody] EntityUpdateDto entityUpdateDto, CancellationToken cancellationToken)
        {
            var command = new UpdateEntityCommand(entityUpdateDto.Id, entityUpdateDto.Name);
            var response = await Mediator.Send(command, cancellationToken);
            return Success(response);
        }

        [HttpGet]
        public async Task<IDataResult<ListResponse<GetAllEntityListItemDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllEntityQuery();
            var response = await Mediator.Send(query, cancellationToken);
            return Success(response);
        }

        [HttpGet("{name}")]
        public async Task<IDataResult<GetDetailsByNameEntityResponse>> GetDetails(string name, CancellationToken cancellationToken)
        {
            var query = new GetDetailsByNameEntityQuery() { Name = name };
            var response = await Mediator.Send(query, cancellationToken);
            return Success(response);
        }
    }
}
