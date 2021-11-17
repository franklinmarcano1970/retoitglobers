using System;
using System.Collections.Generic;

#nullable disable

namespace vtex.context.core.Models
{
    /// <summary>
    /// Clase de tipo modelo para representar la tabla de rompimiento Autor y la relacion con libros en el contexto de datos
    /// </summary>
    public partial class AutoresHasLibro
    {
        public int AutoresId { get; set; }
        public int LibrosIsbn { get; set; }

        public virtual Autor Autores { get; set; }
        public virtual Libro LibrosIsbnNavigation { get; set; }
    }
}
