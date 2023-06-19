using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Web3.Storage.Interfaces;

namespace Web3.Storage.Clases
{
    public class ArchivoWeb : IArchivoWeb
    {
        private readonly IConfiguration _configuration;
        private readonly IWeb3StorageClient _web3StorageClient;

        public ArchivoWeb(IConfiguration configuration, IWeb3StorageClient web3StorageClient)
        {
            _configuration = configuration;
            _web3StorageClient = web3StorageClient;
        }
        public string Desencriptar(IFormFile file)
        {
            string filePath = @"C:\GitHub\ProvacySeguros\ProvacySeguros\Web3.Storage\Archivos\Encrypt\" + file.FileName;
            string filePathDecrypt = @"C:\GitHub\ProvacySeguros\ProvacySeguros\Web3.Storage\Archivos\Decrypt\" + file.FileName;

            byte[] fileByteArray = File.ReadAllBytes(filePath);
            using Aes aes = Aes.Create();
            aes.Key = CrearSALT();
            aes.IV = IV.vector;
            using MemoryStream input = new(fileByteArray);
            using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using MemoryStream output = new();
            cryptoStream.CopyTo(output);

            using (FileStream fs = File.Create(filePathDecrypt))
            {
                byte[] info = output.ToArray();
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
       
            return Encoding.Unicode.GetString(output.ToArray());
        }

        public byte[] Encriptar(IFormFile file)
        {
            try
            { 
                
                
                byte[] byteFile;
                long fileSize = file.Length;
                string fileType = file.ContentType;
                string filePath = @"C:\GitHub\ProvacySeguros\ProvacySeguros\Web3.Storage\Archivos\Encrypt\" + file.FileName;
                if (fileSize > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        file.CopyTo(stream);
                        byteFile = stream.ToArray();
                    }
                    //using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    //{
                    //    file.CopyTo(stream);
                    //}
                    //File.Encrypt(filePath);

                    using Aes aes = Aes.Create();
                    aes.Key = CrearSALT();
                    aes.IV = IV.vector;
                    using MemoryStream output = new();
                    using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(byteFile);
                    cryptoStream.FlushFinalBlock();

                    using (FileStream fs = File.Create(filePath))
                    {
                        byte[] info = output.ToArray();
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                        
                    }

                    Task<string> cid = _web3StorageClient.EnviarArchivos(output.ToArray());
                    return output.ToArray();
                }
                else
                {
                    throw new Exception("Sin Archivo");
                }

            }
            catch (Exception)
            {

                throw;
            }
           
            


        }

        private byte[] CrearSALT()
        {
            string password = _configuration["Key"];
            var emptySalt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLength = 16; // 16 bytes equal 128 bits.
            var hashMethod = HashAlgorithmName.SHA384;
            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(password),
                                             emptySalt,
                                             iterations,
                                             hashMethod,
                                             desiredKeyLength);
        }
    }
}
