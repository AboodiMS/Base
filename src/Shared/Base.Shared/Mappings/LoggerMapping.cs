
using Base.Shared.Dtos.Logger;
using Base.Shared.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Mappings
{
    public static class LoggerMapping
    {
        public static ActionLogger AsEntity(this AddActionLoggerDto dto)
        => new ActionLogger
        {
            Id=Guid.NewGuid(),
            CreatedDate=DateTimeOffset.Now,
            Action=dto.Action,
            BusinessId=dto.BusinessId,
            ObjectData = dto.ObjectData,
            ObjectId=dto.ObjectId,
            Table=dto.Table,
            UserId=dto.UserId,
        };

    }
}
