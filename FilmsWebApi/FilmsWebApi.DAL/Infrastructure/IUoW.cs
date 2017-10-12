﻿using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsWebApi.DAL.Infrastructure
{
    public interface IUoW
    {
        IBaseRepository<Film> FilmsRepository { get; }

        void SaveChanges();
    }
}
