using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtex.dto.core;

namespace vtex.service.core
{
    public interface ILibroAutorService
    {
        Task<AutoresHasLibroDto> AddAutorLibroAsync(AutoresHasLibroDto Autor);
        List<AutoresHasLibroDto> GetAllAutorLibroAsync();
        Task<AutoresHasLibroDto> GetAutorLibroByIdAsync(int id, int isbn);
        Task<AutoresHasLibroDto> GetAutorByIdAsync(int id);
        Task<AutoresHasLibroDto> GetLibroByIdAsync(int id);
    }
}
