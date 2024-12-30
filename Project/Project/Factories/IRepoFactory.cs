﻿using Project.Model;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Factories
{
    public interface IRepoFactory
    {
        IRepo<T> CreateRepo<T>() where T : BaseEntity;

    }
}