﻿using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Exceptions.User
{
    internal class EditSelfePowersException : BaseException
    {
        public EditSelfePowersException() : base($"Can't edit your powers.")
        {
        }
    }
}
