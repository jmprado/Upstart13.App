using System.Collections.Generic;
using System.Threading.Tasks;
using Upstart13.BeerApp.Entities;

namespace Upstart13.BeerApp.Dal
{
    public interface IBeerDal
    {
        Task<Beer> GetAsync(int id);
        Task<IEnumerable<Beer>> ListAsync();
        Task<Beer> AddAsync(Beer beer);
        Task<Beer> UpdateAsync(Beer beer);
        Task DeleteAsync(int id);
        Task ImportAsync(IEnumerable<Beer> beerList);
    }
}
