using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Upstart13.BeerApp.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Upstart13.BeerApp.Dal
{
    public class FoodPairingDal : IFoodPairingDal
    {
        public async Task<FoodPairing> GetAsync(int id)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                return await dbContext.FoodPairing.FindAsync(id);
            }
        }

        public async Task<IEnumerable<FoodPairing>> ListAsync(int beerId)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                return await (from c in dbContext.FoodPairing where c.BeerId == beerId select c).ToListAsync();
            }
        }

        public async Task<FoodPairing> AddAsync(FoodPairing foodPairing)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                await dbContext.FoodPairing.AddAsync(foodPairing);
                await dbContext.SaveChangesAsync();
                return foodPairing;
            }
        }

        public async Task<FoodPairing> UpdateAsync(FoodPairing foodPairing)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                dbContext.Attach(foodPairing);
                dbContext.Entry(foodPairing).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return foodPairing;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                var foodPairingToDelete = await GetAsync(id);
                dbContext.FoodPairing.Remove(foodPairingToDelete);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
