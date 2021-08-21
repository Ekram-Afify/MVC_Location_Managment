﻿using LocationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Repositories
{
    public interface ICityRepository: IRepository<City>
    {
        void RemoveAll(int countryId);
    }
}
