using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Upstart13.BeerApp.Entities;

namespace Upstart13.BeerApp.Dal
{
    public interface IVolumeDal
    {
        Task<Volume> GetAsync(int id);
        Task<IEnumerable<Volume>> ListAsync(int idBeer);
        Task<Volume> AddAsync(Volume method);
        Task<Volume> UpdateAsync(Volume method);
        Task DeleteAsync(int id);
    }
}
