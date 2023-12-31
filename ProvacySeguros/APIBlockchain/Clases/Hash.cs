﻿using APIBlockchain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace APIBlockchain.Clases
{
    public class Hash : IHash
    {
        private readonly IBlockchainClient _blockhainClient;

        public Hash(IBlockchainClient blockchainClient)
        {
            _blockhainClient = blockchainClient;
        }

        public string CalcularHash(IFormFile file, int idColab)
        {
            byte[] bytes;
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                bytes = stream.ToArray();
            }

            string hash;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                hash = GetHash(sha256Hash, bytes);
            }
            if(idColab != 0)
            {
                _blockhainClient.InsertarHash(idColab, hash);
            }
            return hash;
        }

        public string GetHash(HashAlgorithm hashAlgorithm, byte[] input)
        {
            byte[] data = hashAlgorithm.ComputeHash(input);

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public bool VerifyHash(string input1, string input2)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(input1, input2) == 0;
        }
    }
}
