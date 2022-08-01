using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.IServices
{
    public interface IService<Entity>
    {
        Task AddRange(List<Entity> entities);
        Task RemoveRangeByHeaderId(Guid HeaderId);
        Task GetByHeaderId(Guid HeaderId);
    }
}
