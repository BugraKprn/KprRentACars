﻿using CarRental.Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Library.Services
{
    public interface ISettingService
    {
        Setting Get();
        void Create(Setting setting);
    }
}
