using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtex.dto.core
{
    /// <summary>
    /// Clase de tipo Dto para representar la tabla Autor en el contexto de datos
    /// </summary
    public class AutorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}
