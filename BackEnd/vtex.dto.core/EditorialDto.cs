using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtex.dto.core
{
    /// <summary>
    /// Clase de tipo Dto para representar la tabla Editorial en el contexto de datos
    /// </summary
    public class EditorialDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }
    }
}
