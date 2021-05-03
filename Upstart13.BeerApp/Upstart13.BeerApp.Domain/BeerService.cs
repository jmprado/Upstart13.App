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
        private readonly IVolumeDal _volumeDal;
        private readonly IMethodDal _methodDal;
        private readonly IIngredientDal _ingredientDal;
        private readonly IMapper _mapper;

        public BeerService(
            IBeerDal beerDal,
            IVolumeDal volumeDal,
            IMethodDal methodDal,
            IIngredientDal ingredientDal,
            IMapper mapper)
        {
            _beerDal = beerDal;
            _volumeDal = volumeDal;
            _methodDal = methodDal;
            _ingredientDal = ingredientDal;
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
            foreach (var punkApibeer in listBeerImport)
            {
                var beerEntity = _mapper.Map<Beer>(punkApibeer);
                var beerAdded = await _beerDal.AddAsync(beerEntity);

                var volumeEntity = _mapper.Map<Volume>(punkApibeer.Volume);
                volumeEntity.BeerId = beerAdded.BeerId;
                await _volumeDal.AddAsync(volumeEntity);

                var boilVolumeEntity = _mapper.Map<Volume>(punkApibeer.BoilVolume);
                boilVolumeEntity.BeerId = beerAdded.BeerId;
                await _volumeDal.AddAsync(boilVolumeEntity);

                var listMashTempMethod = _mapper.Map<IEnumerable<Method>>(punkApibeer.Method.MashTemp);
                foreach (var mashTemp in listMashTempMethod)
                {
                    mashTemp.BeerId = beerAdded.BeerId;
                    await _methodDal.AddAsync(mashTemp);
                }

                var fermentation = _mapper.Map<Method>(punkApibeer.Method.Fermentation);
                fermentation.BeerId = beerAdded.BeerId;
                await _methodDal.AddAsync(fermentation);

                var twist = _mapper.Map<Method>(punkApibeer.Method.Twist);
                twist.BeerId = beerAdded.BeerId;
                await _methodDal.AddAsync(twist);

                var listMalt = _mapper.Map<IEnumerable<Ingredient>>(punkApibeer.Ingredients.Malt);
                foreach (var malt in listMalt)
                {
                    malt.BeerId = beerAdded.BeerId;
                    await _ingredientDal.AddAsync(malt);
                }

                var listHops = _mapper.Map<IEnumerable<Ingredient>>(punkApibeer.Ingredients.Hops);
                foreach (var hops in listHops)
                {
                    hops.BeerId = beerAdded.BeerId;
                    await _ingredientDal.AddAsync(hops);
                }

                var yeast = _mapper.Map<Ingredient>(punkApibeer.Ingredients.Yeast);
                yeast.BeerId = beerAdded.BeerId;
                await _ingredientDal.AddAsync(yeast);
            }
        }
    }
}
