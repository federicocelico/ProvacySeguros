using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Colaborador
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public string Patente { get; set; } = null!;
        public bool Pendiente { get; set; }
    }
}
