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
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(vtex_testContext _vtex_testRepositoryContext) : base(_vtex_testRepositoryContext)
        {
        }

        public Task<Autor> GetAutorByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
