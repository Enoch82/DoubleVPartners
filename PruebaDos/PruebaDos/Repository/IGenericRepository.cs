using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDos.Repository
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> ObtenerTodos();
        void Guardar(T entity);
        void Eliminar(T entity);
        void Actualizar(T entity);
    }
}
