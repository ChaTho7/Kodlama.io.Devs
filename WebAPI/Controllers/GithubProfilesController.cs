using Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using Application.Features.GithubProfiles.Commands.DeleteGithubProfile;
using Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using Application.Features.GithubProfiles.Dtos;
using Application.Features.GithubProfiles.Models;
using Application.Features.GithubProfiles.Queries.GetByUserIdGithubProfile;
using Application.Features.GithubProfiles.Queries.GetListGithubProfile;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubProfilesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateGithubProfileCommand createGithubProfileCommand)
        {
            CreatedGithubProfileDto result = await Mediator.Send(createGithubProfileCommand);

            return Created("", result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGithubProfileQuery getListGithubProfileQuery = new() { PageRequest = pageRequest };
            GithubProfileListModel result = await Mediator.Send(getListGithubProfileQuery);

            return Ok(result);
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId([FromQuery] GetByUserIdGithubProfileQuery getByUserIdGithubProfileQuery)
        {
            GithubProfileGetByUserIdDto githubProfileGetByUserIdDto = await Mediator.Send(getByUserIdGithubProfileQuery);

            return Ok(githubProfileGetByUserIdDto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateGithubProfileCommand updateGithubProfileCommand)
        {
            UpdatedGithubProfileDto result = await Mediator.Send(updateGithubProfileCommand);

            return Created("", result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteGithubProfileCommand deleteGithubProfileCommand)
        {
            DeletedGithubProfileDto result = await Mediator.Send(deleteGithubProfileCommand);

            return Created("", result);
        }
    }
}
