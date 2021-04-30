using System.Threading.Tasks;
using Upstart13.BeerApp.ViewModel;

namespace Upstart13.BeerApp.Domain
{
    public interface IBeerService
    {
        Task<BeerModel> Add(BeerModel beerModel);
        Task Delete(int id);
        Task<BeerModel> Get(int id);
        Task<BeerModel> Update(BeerModel beerModel);
    }
}