using Application.Features.Frameworks.Commands.CreateFramework;
using Application.Features.Frameworks.Commands.DeleteFramework;
using Application.Features.Frameworks.Commands.UpdateFramework;
using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Models;
using Application.Features.Frameworks.Queries.GetByIdFramework;
using Application.Features.Frameworks.Queries.GetListFramework;
using Application.Features.Frameworks.Queries.GetListFrameworkByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworksController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFrameworkCommand createFrameworkCommand)
        {
            CreatedFrameworkDto result = await Mediator.Send(createFrameworkCommand);

            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListFrameworkQuery getListFrameworkQuery = new() { PageRequest = pageRequest };
            FrameworkListModel result = await Mediator.Send(getListFrameworkQuery);

            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListFrameworkByDynamicQuery getListByDynamicModelQuery = new GetListFrameworkByDynamicQuery
            {
                PageRequest = pageRequest,
                Dynamic = dynamic
            };
            FrameworkListModel result = await Mediator.Send(getListByDynamicModelQuery);

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdFrameworkQuery getByIdFrameworkQuery)
        {
            FrameworkGetByIdDto frameworkGetByIdDto = await Mediator.Send(getByIdFrameworkQuery);

            return Ok(frameworkGetByIdDto);
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] UpdateFrameworkCommand updateFrameworkCommand)
        {
            UpdatedFrameworkDto result = await Mediator.Send(updateFrameworkCommand);

            return Created("", result);
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete([FromBody] DeleteFrameworkCommand deleteFrameworkCommand)
        {
            DeletedFrameworkDto result = await Mediator.Send(deleteFrameworkCommand);

            return Created("", result);
        }
    }
}
