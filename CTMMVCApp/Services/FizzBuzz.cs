using System.Collections.Generic;
using System.Threading.Tasks;
namespace CTMMVCApp.Services
{
    /// <summary>
    /// FizzBuzz Service
    /// </summary>
    public class FizzBuzz : IFizzBuzz
    {
        public Task<IEnumerable<string>> fizzBuzzAsync(int n)
        {
            return Task.FromResult<IEnumerable<string>>(fizzBuzz(n));
        }

        public IEnumerable<string> fizzBuzz(int n)
        {
            var output = new List<string>();

            for(int i = 1; i <= n; i++)
            {
                if (((i % 3) == 0) && ((i % 5) == 0))
                {
                    output.Add("FizzBuzz");
                }
                else if ((i % 3) == 0)
                {
                    output.Add("Fizz");
                }
                else if ((i % 5) == 0)
                {
                    output.Add("Buzz");
                }
                else 
                {
                    output.Add(i.ToString());
                }
            }

            return output;
        }
    }
}
