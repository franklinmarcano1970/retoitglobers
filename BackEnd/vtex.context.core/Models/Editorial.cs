using System;
using System.Collections.Generic;

#nullable disable

namespace vtex.context.core.Models
{
    /// <summary>
    /// Clase de tipo modelo para representar la tabla Editoriales en el contexto de datos
    /// </summary>
    public partial class Editorial
    {
        public Editorial()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
