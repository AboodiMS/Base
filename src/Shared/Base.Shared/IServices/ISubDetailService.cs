using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.IServices
{
    public interface ISubDetailService<Entity>
    {
        Task CreateRange(List<Entity> entities);
        Task RemoveRangeByHeaderId(Guid headerId);
        Task GetByHeaderId(Guid headerId);
    }
}
