using System;
using System.Collections.Generic;

#nullable disable

namespace vtex.context.core.Models
{
    /// <summary>
    /// Clase de tipo modelo para representar la tabla Linro en el contexto de datos
    /// </summary>
    public partial class Libro
    {
        public Libro()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

        public int Isbn { get; set; }
        public int? EditorialesId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }

        public virtual Editorial Editoriales { get; set; }
        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}
