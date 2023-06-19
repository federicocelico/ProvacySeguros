using Aplicacion.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Clases
{
    public class ColaboradorApp : IColaborador
    {
        private readonly ProvacySegurosContext db;
        public ColaboradorApp(ProvacySegurosContext db)
        {
            this.db = db;
        }
        public int InsertColaborador(Colaborador colaborador)
        {
            db.Colaboradors.Add(colaborador);
            db.SaveChanges();
            return colaborador.Id;
        }
    }
}
