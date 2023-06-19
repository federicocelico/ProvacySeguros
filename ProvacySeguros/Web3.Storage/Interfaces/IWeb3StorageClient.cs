using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web3.Storage.Interfaces
{
    public interface IWeb3StorageClient
    {
        string EnviarArchivos(byte[] file);
    }
}
