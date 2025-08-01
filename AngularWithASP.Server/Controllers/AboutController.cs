using AngularWithASP.Server.DTOs;
using AngularWithASP.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace AngularWithASP.Server.Controllers
{
    [ApiController]
    [Route("api/test/[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly ICalculationsService _calculationsService;
        public AboutController(ICalculationsService calculationsService) {
            _calculationsService = calculationsService;
        }
        [HttpGet("GetInfo")]
        public IActionResult GetInfo()
        {
            var info = new
            {
                Company = "Your Company Name",
                Mission = "Deliver high-quality software solutions",
                Founded = 2020
            };

            return Ok(info);
        }
        [HttpGet("GetStatus")]
        public IActionResult GetStatus()
        {
            return Ok(new { Message = "About endpoint is working!" });
        }
        [HttpGet("GetSumOfCountByThrees")]
        public IActionResult GetSumOfCountByThrees([FromQuery] int number)
        {
            int result= _calculationsService.GetSumOfCountByThrees(number);
            return Ok(result);
        }
        [HttpGet("calculateMNSum")]
        public IActionResult calculateMNSum([FromQuery] string stringNum)
        {
            List<int> nums = stringNum.Split(',').Select(s => int.Parse(s.Trim())).ToList();
            int result = _calculationsService.calculateMNSum(nums[0], nums[1]);
            return Ok(result);
        }
        [HttpGet("calculateMNProduct")]
        public IActionResult calculateMNProduct([FromQuery] string stringNum)
        {
            List<int> nums = stringNum.Split(',').Select(s => int.Parse(s.Trim())).ToList();
            int result = _calculationsService.calculateMNProduct(nums[0], nums[1]);
            return Ok(result);
        }
        [HttpGet("calculateMult3or5")]
        public IActionResult calculateMult3or5([FromQuery] int number)
        {           
            bool result = _calculationsService.calculateMult3or5(number);
            return Ok(result);
        }
        [HttpGet("calculateSumOfNotMult3or5")]
        public IActionResult calculateSumOfNotMult3or5([FromQuery] int number)
        {
            int result = _calculationsService.calculateSumOfNotMult3or5(number);
            return Ok(result);
        }
        [HttpGet("calculateSumOfEndsWith3or5")]
        public IActionResult calculateSumOfEndsWith3or5([FromQuery] int number)
        {
            int result = _calculationsService.calculateSumOfEndsWith3or5(number);
            return Ok(result);
        }
        [HttpGet("calculateIsBouncy")]
        public IActionResult calculateIsBouncy([FromQuery] int number)
        {
            bool result = _calculationsService.calculateIsBouncy(number);
            return Ok(result);
        }
        [HttpGet("calculateSumOfBouncy")]
        public IActionResult calculateSumOfBouncy([FromQuery] string stringNum)
        {
            List<int> nums = stringNum.Split(',').Select(s => int.Parse(s.Trim())).ToList();
            BouncyObjects result = _calculationsService.calculateSumOfBouncy(nums[0], nums[1]);
            return Ok(result);
        }
    }

}
