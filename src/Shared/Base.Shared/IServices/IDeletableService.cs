using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.IServices
{
    public interface IDeletableService<GetResponse, AddRequest, UpdateRequest>
    {
        Task<GetResponse> GetById(Guid id);
        Task<List<GetResponse>> GetAll();
        Task Add(Guid id, AddRequest dto);
        Task Update(Guid id, UpdateRequest dto);
        Task Delete(Guid id, Guid userid);
    }
}
