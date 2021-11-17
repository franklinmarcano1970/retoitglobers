using System;
using System.Collections.Generic;

#nullable disable

namespace vtex.context.core.Models
{
    /// <summary>
    /// Clase de tipo modelo para representar la tabla Autor en el contexto de datos
    /// </summary>
    public partial class Autor
    {
        public Autor()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}
