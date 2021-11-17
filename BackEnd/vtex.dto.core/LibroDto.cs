using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtex.dto.core
{
    /// <summary>
    /// Clase de tipo Dto para representar la tabla Libro en el contexto de datos
    /// </summary
    public class LibroDto
    {
        public int Isbn { get; set; }
        public int? EditorialesId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
    }
}
