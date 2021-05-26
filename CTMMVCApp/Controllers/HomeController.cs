using CTMMVCApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTMMVCApp.Controllers
{
    public class HomeController : Controller
    {
        #region WebAPI

        private readonly IFizzBuzz _IFizzBuzz; 

        public HomeController(IFizzBuzz IFizzBuzz)
        {
            _IFizzBuzz = IFizzBuzz;
        }

        /// <summary>
        /// For each multiple of 3, print "Fizz" instead of the number.
        /// For each multiple of 5, print "Buzz" instead of the number.
        /// For numbers which are multiples of both 3 and 5, print "FizzBuzz" instead of the number.
        /// </summary>
        /// <param name="n">Number between 1 and 0</param>
        /// <returns>A list of strings</returns>
        public async Task<ActionResult<List<string>>> FizzBuzz(int n) {

            if(n <= 0)
            {
                return BadRequest("n must be greater than 0");
            }
            if (n > 100)
            {
                return BadRequest("n must be greater than 0");
            }
            var result = await _IFizzBuzz.fizzBuzzAsync(n);
            return Ok(result);
        }

        #endregion

    }
}
