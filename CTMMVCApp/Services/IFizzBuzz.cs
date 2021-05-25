using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTMMVCApp.Services
{
    public interface IFizzBuzz
    {
        public IEnumerable<string> MyFizzBuzz(int n);

        public Task<IEnumerable<string>> FizzBuzzAsync(int n);
    }
}
