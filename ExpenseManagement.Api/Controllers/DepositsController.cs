using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Services;
using ExpenseManagement.Shared.Models;
using ExpenseManagement.Shared.Models.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class DepositsController : ControllerBase
    {
        public readonly IDepositsService _DepositsService;

        public DepositsController(IDepositsService depositService)
        {
            _DepositsService = depositService;
        }


        [HttpGet("GetAllDeposits")]
        public async Task<IActionResult> GetAllDepositsAsync()
        {
            return Ok(await _DepositsService.GetAllDepositsAsync());
        }


        [HttpGet("GetDepositsById/{DepositId}")]
        public async Task<IActionResult> GetDepositsByIdAsync(long depositId)
        {
            return Ok(await _DepositsService.GetDepositsByIdAsync(depositId));
        }



        [HttpPost("CreateDeposit")]
        public async Task<IActionResult> CreateDepositsAsync([FromBody] DepositDto depositDto)
        {
            if (depositDto == null)
                return BadRequest();

            return Ok(await _DepositsService.AddDepositsAsync(depositDto));
        }


        [HttpPut("UpdateDeposit")]
        public async Task<IActionResult> UpdateDepositsAsync([FromBody] DepositDto DepositDto)
        {
            if (DepositDto == null)
                return BadRequest();

            return Ok(await _DepositsService.UpdateDepositsAsync(DepositDto));
        }

        [HttpPut("InActiveDeposit")]
        public async Task<IActionResult> InActiveDepositAsync([FromBody] DepositDto DepositDto)
        {
            if (DepositDto.DepositId <= 0)
                return BadRequest();

            return Ok(await _DepositsService.DepositInActiveAsync(DepositDto));
        }

      
        [HttpDelete("DeleteDeposits/{DepositId}")]
        public async Task<IActionResult> DeleteDepositsAsync(long DepositId)
        {
            if (DepositId == 0)
                return BadRequest();

            return Ok(await _DepositsService.DeleteDepositsAsync(DepositId));
        }
    }
}