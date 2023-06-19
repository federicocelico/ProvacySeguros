using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web3.Storage.Clases
{
    public static class IV
    {
        private static byte[] _vector = {0x20, 0x22, 0x30, 0x32, 0x35, 0x88, 0x97, 0x58,
    0x09, 0x44, 0x16, 0x13, 0x01, 0x72, 0x15, 0x66};
        public static byte[] vector
        {
            get { return _vector; }
        }
    }
}
