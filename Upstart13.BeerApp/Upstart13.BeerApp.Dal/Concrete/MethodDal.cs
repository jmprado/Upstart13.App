using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upstart13.BeerApp.Entities;

namespace Upstart13.BeerApp.Dal
{
    public class MethodDal : IMethodDal
    {
        public async Task<Method> GetAsync(int id)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                return await dbContext.Method.FindAsync(id);
            }
        }

        public async Task<IEnumerable<Method>> ListAsync(int beerId)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                return await (from c in dbContext.Method where c.BeerId == beerId select c).ToListAsync();
            }
        }

        public async Task<Method> AddAsync(Method method)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                await dbContext.Method.AddAsync(method);
                await dbContext.SaveChangesAsync();
                return method;
            }
        }

        public async Task<Method> UpdateAsync(Method method)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                dbContext.Attach(method);
                dbContext.Entry(method).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return method;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var dbContext = new Upstart13beerappContext())
            {
                var methodToDelete = await GetAsync(id);
                dbContext.Method.Remove(methodToDelete);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
