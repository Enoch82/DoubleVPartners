using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PruebaDos.Model.Models;


namespace PruebaDos.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        public UnitOfWork(MyDbContext context)
        {
            _context = context;
            Tiket = new TiketRespository(_context); 
            
        }
        public ITiketRepository Tiket { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
