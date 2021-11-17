using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtex.context.core.Models;

namespace vtex.repository.core
{
    public interface ILibroAutorRepository : IRepository<AutoresHasLibro>
    {
        Task<AutoresHasLibro> GetAutorByIdAsync(int id);
        Task<AutoresHasLibro> GetLibroByIdAsync(int id);
    }
}
