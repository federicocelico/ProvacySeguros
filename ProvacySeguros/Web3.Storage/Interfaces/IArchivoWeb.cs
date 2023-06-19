using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web3.Storage.Interfaces
{
    public  interface IArchivoWeb
    {
        public byte[] Encriptar(IFormFile file);
        string Desencriptar(IFormFile file);
    }
}
