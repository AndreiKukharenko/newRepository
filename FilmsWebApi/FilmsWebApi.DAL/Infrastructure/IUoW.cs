using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsWebApi.DAL.Infrastructure
{
    public interface IUoW
    {
        IFilmsRepository FilmsRepository { get; }

        void SaveChanges();
    }
}
