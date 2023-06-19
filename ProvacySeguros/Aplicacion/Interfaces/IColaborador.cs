using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IColaborador
    {
        int InsertColaborador(Colaborador colaborador);
    }
}
