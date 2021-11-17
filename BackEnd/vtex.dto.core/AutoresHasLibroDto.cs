using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtex.dto.core
{
    /// <summary>
    /// Clase de tipo Dto para representar la tabla Autor y libros en el contexto de datos
    /// </summary
    public class AutoresHasLibroDto
    {
        public int AutoresId { get; set; }
        public int LibrosIsbn { get; set; }
    }
}
