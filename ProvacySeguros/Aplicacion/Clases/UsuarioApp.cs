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
           return db.Usuarios.Where(x => x.Id == id).FirstOrDefault();  
        }

        public List<Usuario> GetAll()
        {
            return db.Usuarios.ToList();
        }

        public void InsertUsuario(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
        }
    }
}
