using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtex.context.core;
using vtex.context.core.Models;

namespace vtex.repository.core
{
    public class LibroAutorRepository : Repository<AutoresHasLibro>, ILibroAutorRepository
    {
        public LibroAutorRepository(vtex_testContext _vtex_testRepositoryContext) : base(_vtex_testRepositoryContext)
        {
        }

        public Task<AutoresHasLibro> GetLibroByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.LibrosIsbn == id);
        }

        public Task<AutoresHasLibro> GetAutorByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.AutoresId == id);
        }
    }
}
