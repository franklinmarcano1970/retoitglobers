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
    public class EditorialRepository : Repository<Editorial>, IEditorialRepository
    {
        public EditorialRepository(vtex_testContext _vtex_testRepositoryContext) : base(_vtex_testRepositoryContext)
        {
        }

        public Task<Editorial> GetEditorialByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
