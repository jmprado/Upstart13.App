using AutoMapper;
using System.Collections.Generic;
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

        public BeerService(
            IBeerDal beerDal,
            IMapper mapper)
        {
            _beerDal = beerDal;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BeerModel> Get(int id)
        {
            return _mapper.Map<BeerModel>(await _beerDal.GetAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beerModel"></param>
        /// <returns></returns>
        public async Task<BeerModel> Add(BeerModel beerModel)
        {
            var beerEntity = _mapper.Map<Beer>(beerModel);
            var beerAdded = await _beerDal.AddAsync(beerEntity);
            return _mapper.Map<BeerModel>(beerAdded);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beerModel"></param>
        /// <returns></returns>
        public async Task<BeerModel> Update(BeerModel beerModel)
        {
            var beerEntity = _mapper.Map<Beer>(beerModel);
            var beerAdded = await _beerDal.UpdateAsync(beerEntity);
            return _mapper.Map<BeerModel>(beerAdded);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            await _beerDal.DeleteAsync(id);
        }

        public async Task Import(IEnumerable<PunkApiBeerModel> listBeerImport)
        {
            var listBeerAdd = _mapper.Map<IEnumerable<Beer>>(listBeerImport);

        }
    }
}
