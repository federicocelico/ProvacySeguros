using APIBlockchain.Clases;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APIBlockchain.Interfaces
{
    public interface IHash
    {
        string CalcularHash(IFormFile file);
        string GetHash(HashAlgorithm hashAlgorithm, byte[] input);
        bool VerifyHash(string input1, string input2);
    }
}
