using CorrectionLabo.Application.Abstractions.Services;
using CorrectionLabo.DTO.MemberDTOS;
using CorrectionLabo.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorrectionLabo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController(IMemberService memberService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterMemberFormDTO dto)
        {
            try
            {
                await memberService.AddMember(dto.ToEntity(), dto.ELO);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpHead]
        public async Task<IActionResult> Exist([FromQuery] string? username, [FromQuery] string? email)
        {
            try
            {
                if (await memberService.Exist(username, email))
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
