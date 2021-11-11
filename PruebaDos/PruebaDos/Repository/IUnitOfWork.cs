using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDos.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ITiketRepository Tiket { get;  }
        int Complete();
    }
}
