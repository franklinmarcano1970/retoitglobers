using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtex.dto.core;

namespace vtex.service.core
{
    public interface IAutorService
    {
        Task<AutorDto> AddAutorAsync(AutorDto Autor);
        Task<AutorDto> UpdateAutorAsync(AutorDto Autor);
        List<AutorDto> GetAllAutorAsync();
        Task<AutorDto>GetAutorByIdAsync(int id);
    }
}
