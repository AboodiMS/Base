using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Services
{
    public interface IEntity<Entity>
    {
        public long Id { get; set; }
        public Guid HeaderId { get; set; }
        public Guid BusinessId { get; set; }

    }
}
