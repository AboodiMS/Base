
using Base.Shared.Dtos;
using Base.Shared.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.IServices
{
    public interface ICRUDService<TEntity, TQuery>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(TQuery query);
        Task<TEntity> GetByIdAsync(int id);
        Task<AutoCompleteDto> AutoComplete(AutoCompleteFilter query);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(int id, TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> Restore(int id);
    }
}
