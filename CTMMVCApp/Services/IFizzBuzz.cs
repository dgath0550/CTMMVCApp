using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTMMVCApp.Services
{
    public interface IFizzBuzz
    {
        public IEnumerable<string> fizzBuzz(int n);

        public Task<IEnumerable<string>> fizzBuzzAsync(int n);

    }
}
