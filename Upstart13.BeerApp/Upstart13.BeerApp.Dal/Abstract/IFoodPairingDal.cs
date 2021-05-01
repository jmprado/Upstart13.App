using System.Collections.Generic;
using System.Threading.Tasks;
using Upstart13.BeerApp.Entities;

namespace Upstart13.BeerApp.Dal
{
    public interface IFoodPairingDal
    {
        Task<FoodPairing> GetAsync(int id);
        Task<IEnumerable<FoodPairing>> ListAsync(int beerId);
        Task<FoodPairing> AddAsync(FoodPairing foodPairing);
        Task<FoodPairing> UpdateAsync(FoodPairing foodPairing);
        Task DeleteAsync(int id);
    }
}
