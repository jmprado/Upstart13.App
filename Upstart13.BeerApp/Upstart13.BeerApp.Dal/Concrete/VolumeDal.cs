using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upstart13.BeerApp.Entities;

namespace Upstart13.BeerApp.Dal
{
    public class VolumeDal : IVolumeDal
    {
        public async Task<Volume> GetAsync(int id)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                return await dbContext.Volume.FindAsync(id);
            }
        }

        public async Task<IEnumerable<Volume>> ListAsync(int beerId)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                return await (from c in dbContext.Volume where c.BeerId == beerId select c).ToListAsync();
            }
        }

        public async Task<Volume> AddAsync(Volume volume)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                await dbContext.Volume.AddAsync(volume);
                await dbContext.SaveChangesAsync();
                return volume;
            }
        }

        public async Task<Volume> UpdateAsync(Volume volume)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                dbContext.Attach(volume);
                dbContext.Entry(volume).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return volume;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                var volumeToDelete = await GetAsync(id);
                dbContext.Volume.Remove(volumeToDelete);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
