using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDos.Model;

using static PruebaDos.Model.Models;

namespace PruebaDos.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MyDbContext _context; 

        public GenericRepository(MyDbContext context)
        {
            _context = context;
        }

        public void Actualizar(T entity)
        {
            _context.Set<T>().Update(entity);


        }

        public void Guardar(T entity)
        {
            _context.Set<T>().Add(entity);


        }

        public void Eliminar(T entity)
        {
            _context.Set<T>().Remove(entity);


        }

        public IEnumerable<T> ObtenerTodos()
        {
            return _context.Set<T>().ToList();
        }

    }
}
