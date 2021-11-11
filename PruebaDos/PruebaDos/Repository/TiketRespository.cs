using PruebaDos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PruebaDos.Model.Models;

namespace PruebaDos.Repository
{
    public class TiketRespository : GenericRepository<TicketModel>, ITiketRepository
    {
        public TiketRespository(MyDbContext context) : base(context)
        {
        }

        
    }
}
