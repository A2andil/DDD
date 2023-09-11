using Backend.Application.Dispatchers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
