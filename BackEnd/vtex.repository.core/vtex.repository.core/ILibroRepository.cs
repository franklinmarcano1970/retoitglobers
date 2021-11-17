using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtex.context.core.Models;

namespace vtex.repository.core
{
    public interface ILibroRepository:IRepository<Libro>
    {
        Task<Libro> GetLibroByIdAsync(int id);
    }
}
