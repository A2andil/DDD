using A5bark.Application.Dispatchers;
using Microsoft.AspNetCore.Mvc;

namespace A5bark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IDispatcher Dispatcher;

        protected BaseController(IDispatcher dispatcher)
            => Dispatcher = dispatcher;

        protected IActionResult Select<TData>(TData data)
            where TData : class
                => data is null ? NotFound()
                                : Ok(data) as IActionResult;
    }
}
