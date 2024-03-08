using Core.Utils.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator =>
        _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("IMediator cannot be retrieved from request services.");

        private IMediator? _mediator;


        protected SuccessDataResult<T> Success<T>(T result)
        {
            return new SuccessDataResult<T>(result);
        }
    }
}
