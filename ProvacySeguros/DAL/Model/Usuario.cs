using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public long Dni { get; set; }
    }
}
