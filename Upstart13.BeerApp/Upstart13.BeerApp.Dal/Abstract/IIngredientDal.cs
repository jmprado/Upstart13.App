using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Upstart13.BeerApp.Entities;

namespace Upstart13.BeerApp.Dal
{
    public interface IIngredientDal
    {
        Task<Ingredient> GetAsync(int id);
        Task<IEnumerable<Ingredient>> ListAsync(int idBeer);
        Task<Ingredient> AddAsync(Ingredient ingredient);
        Task<Ingredient> UpdateAsync(Ingredient ingredient);
        Task DeleteAsync(int id);
    }
}
