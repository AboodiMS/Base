using Base.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Services
{
    internal interface IService
    {
        public void AddRange(List<Entity> entities);
        public void RemoveRangeByHeaderId(Guid HeaderId);
        public void GetByHeaderId(Guid HeaderId);
    }
}
