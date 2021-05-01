using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upstart13.BeerApp.Entities;

namespace Upstart13.BeerApp.Dal
{
    public class IngredientDal : IIngredientDal
    {
        public async Task<Ingredient> GetAsync(int id)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                return await dbContext.Ingredient.FindAsync(id);
            }
        }

        public async Task<IEnumerable<Ingredient>> ListAsync(int beerId)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                return await (from c in dbContext.Ingredient where c.BeerId == beerId select c).ToListAsync();
            }
        }

        public async Task<Ingredient> AddAsync(Ingredient ingredient)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                await dbContext.Ingredient.AddAsync(ingredient);
                await dbContext.SaveChangesAsync();
                return ingredient;
            }
        }

        public async Task<Ingredient> UpdateAsync(Ingredient ingredient)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                dbContext.Attach(ingredient);
                dbContext.Entry(ingredient).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return ingredient;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                var ingredientToDelete = await GetAsync(id);
                dbContext.Ingredient.Remove(ingredientToDelete);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
