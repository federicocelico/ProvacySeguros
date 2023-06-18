using Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
namespace Aplicacion.Clases
{
    public class UsuarioApp : IUsuario
    {
        private readonly ProvacySegurosContext db;
        public UsuarioApp(ProvacySegurosContext db)
        {
            this.db = db;   
        }
        public Usuario Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            return db.Usuarios.ToList();
        }
    }
}
