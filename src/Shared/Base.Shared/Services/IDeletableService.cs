using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Services
{
    public interface IDeletableService<GetResponse, AddRequest, UpdateRequest>
    {
        public GetResponse GetById(Guid id);
        public List<GetResponse> GetAll();
        public void Add(Guid id, AddRequest entity);
        public void Update(Guid id, UpdateRequest entity);
        public void Delete(Guid id, Guid userid);
    }
}
