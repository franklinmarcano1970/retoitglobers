using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtex.dto.core;

namespace vtex.service.core
{
    public interface ILibroService
    {
        Task<LibroDto> AddLibroAsync(LibroDto libro);
        Task<LibroDto> UpdateLibroAsync(LibroDto libro);
        List<LibroDto> GetAllLibroAsync();
        Task<LibroDto>GetLibroByIdAsync(int id);
    }
}
