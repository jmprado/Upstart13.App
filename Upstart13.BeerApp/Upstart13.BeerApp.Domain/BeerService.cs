using AutoMapper;
using System;
using System.Threading.Tasks;
using Upstart13.BeerApp.Dal;
using Upstart13.BeerApp.Entities;
using Upstart13.BeerApp.ViewModel;

namespace Upstart13.BeerApp.Domain
{
    public class BeerService : IBeerService
    {
        private readonly IBeerDal _beerDal;
        private readonly IMapper _mapper;

        public BeerService(IBeerDal beerDal, IMapper mapper)
        {
            _beerDal = beerDal;
            _mapper = mapper;
        }

        public async Task<BeerModel> Get(int id)
        {
            return _mapper.Map<BeerModel>(await _beerDal.GetAsync(id));
        }

        public async Task<BeerModel> Add(BeerModel beerModel)
        {
            var beerEntity = _mapper.Map<Beer>(beerModel);
            var beerAdded = await _beerDal.AddAsync(beerEntity);
            return _mapper.Map<BeerModel>(beerAdded);
        }

        public async Task<BeerModel> Update(BeerModel beerModel)
        {
            var beerEntity = _mapper.Map<Beer>(beerModel);
            var beerAdded = await _beerDal.UpdateAsync(beerEntity);
            return _mapper.Map<BeerModel>(beerAdded);
        }

        public async Task Delete(int id)
        {
            await _beerDal.DeleteAsync(id);
        }
    }
}
