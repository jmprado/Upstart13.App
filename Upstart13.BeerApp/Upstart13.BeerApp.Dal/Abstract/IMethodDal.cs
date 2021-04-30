using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Upstart13.BeerApp.Entities;

namespace Upstart13.BeerApp.Dal
{
    public interface IMethodDal
    {
        Task<Method> GetAsync(int id);
        Task<IEnumerable<Method>> ListAsync(int idBeer);
        Task<Method> AddAsync(Method method);
        Task<Method> UpdateAsync(Method method);
        Task DeleteAsync(int id);
    }
}
