using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDos.Model;

namespace PruebaDos.Repository
{
    public interface ITiketRepository : IGenericRepository<TicketModel>
    {
       // IEnumerable<TiketRespository> GetTikets();
    }
}
