using AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Upstart13.BeerApp.Entities;
using Upstart13.BeerApp.ViewModel;
using Xunit;

namespace Upstart13.BeerApp.Tests
{
    public class TestMapping
    {
        private static string _jsonOneBeer = GetJsonFile("one-beer.json");
        private static string _jsonListBeer = GetJsonFile("beer-list.json");
        private static PunkApiBeerModel _beerModel = JsonConvert.DeserializeObject<PunkApiBeerModel>(_jsonOneBeer);
        private static IMapper _mapper = Mapping.MappingGetter.Get();


        [Theory]
        [InlineData("Buzz")]
        public void TestJsonLoadOneBeer(string beerName)
        {
            Assert.Equal(beerName, _beerModel.Name);
        }

        [Theory]
        [InlineData(80)]
        public void TestJsonLoadAllBeers(int numberOfBeers)
        {
            var listBeerModel = JsonConvert.DeserializeObject<IEnumerable<PunkApiBeerModel>>(_jsonListBeer);
            Assert.Equal(listBeerModel.Count(), numberOfBeers);
        }

        [Theory]
        [InlineData("Buzz")]
        public void TestMappingPunkApiToBeerEntity(string beerName)
        {
            var beerEntity = _mapper.Map<Beer>(_beerModel);
            Assert.Equal(beerName, beerEntity.Name);
        }

        [Theory]
        [InlineData(3)]
        public void TestMappingPunkApiFoodPairingToFoodPairingEntity(int value)
        {
            var beerEntity = _mapper.Map<Beer>(_beerModel);
            Assert.Equal(value, beerEntity.FoodPairing.Count());
        }

        [Theory]
        [InlineData(20, "litres")]
        public void TestMappingPunkApiVolumeToVolumeEntity(int value, string unit)
        {
            var volume = _mapper.Map<Volume>(_beerModel.Volume);
            Assert.Equal(value, volume.VolumeValue);
            Assert.Equal(unit, volume.VolumeUnit);
        }

        [Theory]
        [InlineData(25, "litres")]
        public void TestMappingPunkApiBoilVolumeToVolumeEntity(int value, string unit)
        {
            var volume = _mapper.Map<Volume>(_beerModel.BoilVolume);
            Assert.Equal(value, volume.VolumeValue);
            Assert.Equal(unit, volume.VolumeUnit);
        }

        [Theory]
        [InlineData(64, 19)]
        public void TestMappingPunkApiMethodsToMethodEntity(int mashTemp, int fermentationTemp)
        {
            var mashTempMethod = _mapper.Map<IEnumerable<Method>>(_beerModel.Method.MashTemp);
            var fermentationMethod = _mapper.Map<Method>(_beerModel.Method.Fermentation);

            Assert.Equal(mashTemp, mashTempMethod.First().TemperatureValue);
            Assert.Equal(fermentationTemp, fermentationMethod.TemperatureValue);
        }

        [Theory]
        [InlineData("Fuggles", 25, "grams")]
        public void TestMappingPunkApiIngredientsToIngredientEntity(string ingredientName, int amount, string unit)
        {
            var listIngredients = _mapper.Map<IEnumerable<Ingredient>>(_beerModel.Ingredients.Hops);

            Assert.Equal(ingredientName, listIngredients.First().Name);
            Assert.Equal(amount, listIngredients.First().AmountValue);
            Assert.Equal(unit, listIngredients.First().AmountUnit);
        }

        [Theory]
        [InlineData("Wyeast 1056 - American Ale™")]
        public void TestMappingPunkApiYeastToIngredientEntity(string ingredientName)
        {
            var ingredient = _mapper.Map<Ingredient>(_beerModel.Ingredients.Yeast);
            Assert.Equal(ingredientName, ingredient.Name);
        }

        private static string GetJsonFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream($"Upstart13.BeerApp.Tests.Data.{fileName}"))
            using (var reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();
                return text;
            }
        }
    }
}
