using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBlockchain.Interfaces
{
    public interface IBlockchainClient
    {
        void InsertarHash(int id, string hash);
        void GetHash(int id);
    }
}
