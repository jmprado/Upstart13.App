using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Upstart13.BeerApp.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Upstart13.BeerApp.Dal
{
    public class BeerDal : IBeerDal
    {
        public async Task<Beer> GetAsync(int id)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                return await dbContext.Beer.FindAsync(id);
            }
        }

        public async Task<IEnumerable<Beer>> ListAsync()
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                return await dbContext.Beer.ToListAsync();
            }
        }

        public async Task<Beer> AddAsync(Beer beer)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                await dbContext.Beer.AddAsync(beer);
                await dbContext.SaveChangesAsync();
                return beer;
            }
        }

        public async Task<Beer> UpdateAsync(Beer beer)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                dbContext.Attach(beer);
                dbContext.Entry(beer).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return beer;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                var beerToDelete = await GetAsync(id);
                dbContext.Beer.Remove(beerToDelete);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
