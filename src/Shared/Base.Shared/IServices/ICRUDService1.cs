using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.IServices
{
    public interface ICRUDService1<GetResponse, GetDetailsResponse, CreateRequest, UpdateRequest>
    {
        Task<GetDetailsResponse> GetById(Guid id, Guid businessId);
        Task<List<GetResponse>> GetAll(Guid businessId);
        Task Create(CreateRequest dto);
        Task Update(UpdateRequest dto);
        Task Delete(Guid id, Guid businessId, Guid userid);
    }
}
