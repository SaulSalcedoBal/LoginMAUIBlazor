﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginMAUIBlazor.Models;

namespace LoginMAUIBlazor.Interfaces
{
    internal interface ILogin
    {
        Task<Login> Authenticate(UserMin userMin);
    }
}
