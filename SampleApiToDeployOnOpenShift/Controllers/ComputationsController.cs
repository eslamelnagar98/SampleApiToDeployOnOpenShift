using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApiToDeployOnOpenShift.Controllers
{
    [ApiController]
    [Route("api/computations")]
    public class ComputationsController : ControllerBase
    {

        [HttpGet("{firstNumber:int}/{secondNumber:int}")]
        public ActionResult<int> AddTwoNumbers(int firstNumber, int secondNumber)
            => firstNumber + secondNumber;
        
    }
}
