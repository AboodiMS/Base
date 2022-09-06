﻿using Base.Modules.Users.Domain.Entities;
using Base.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.IServices
{
    public interface ITreePowesService
    {
        Task<List<TreePower>> GetAsTreeAsync(); 
    }
}
