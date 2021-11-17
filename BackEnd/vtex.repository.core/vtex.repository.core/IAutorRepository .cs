using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtex.context.core.Models;

namespace vtex.repository.core
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Task<Autor> GetAutorByIdAsync(int id);
    }
}
