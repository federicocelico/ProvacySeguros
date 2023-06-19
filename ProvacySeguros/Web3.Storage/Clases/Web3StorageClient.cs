using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Web3.Storage.Interfaces;

namespace Web3.Storage.Clases
{
    public class Web3StorageClient : IWeb3StorageClient
    {
        private readonly IConfiguration _configuration;

        public Web3StorageClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [EnableCors]
        public async  Task<string> EnviarArchivos(byte[] file)
        {
            {
              
                using var client = new HttpClient();
                client.BaseAddress = new Uri("https://api.web3.storage/car");
                ArchivoRequest arRequest = new ArchivoRequest();
                byte[] archivo = file;
                arRequest.binary = archivo;
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySW5mb3JtYXRpb24iOnsiaWQiOiJhNzliYmZlOC0wMDY5LTQ0M2MtOTIwZC0xNDlkMDNlYTIxYzUiLCJlbWFpbCI6ImZlZGVyaWNvLmNlbGljbzg3QGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJwaW5fcG9saWN5Ijp7InJlZ2lvbnMiOlt7ImlkIjoiRlJBMSIsImRlc2lyZWRSZXBsaWNhdGlvbkNvdW50IjoxfSx7ImlkIjoiTllDMSIsImRlc2lyZWRSZXBsaWNhdGlvbkNvdW50IjoxfV0sInZlcnNpb24iOjF9LCJtZmFfZW5hYmxlZCI6ZmFsc2UsInN0YXR1cyI6IkFDVElWRSJ9LCJhdXRoZW50aWNhdGlvblR5cGUiOiJzY29wZWRLZXkiLCJzY29wZWRLZXlLZXkiOiI0NDQxMzRjZDEzZmFiMDFkZjA0NyIsInNjb3BlZEtleVNlY3JldCI6ImI0ZDY4ZDQ5OTJmNTBhNmFjMDEwMjIzNTYwYjlhOWQ0M2M1OWZmMzkzM2NmYjQ4YmRiM2YxYmZjNTYzNjVkYzMiLCJpYXQiOjE2ODcxNjExNzZ9.9pHOF0U5sUV0Dtk2Q6_JulUlaxfhMdKn_XakE8AVefc");
                HttpContent body = new StringContent(JsonConvert.SerializeObject(arRequest), Encoding.UTF8, "application/json");
                HttpRequestMessage response = new HttpRequestMessage(HttpMethod.Post, "");
                response.Content = body;
                response.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
                response.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkaWQ6ZXRocjoweEVCMEE1MzhiRDgzRDQ1NDE5RDU0NUIyNTU5MTg5MWMwODU1QjQ1MTgiLCJpc3MiOiJ3ZWIzLXN0b3JhZ2UiLCJpYXQiOjE2ODcxNDY2ODMzNDgsIm5hbWUiOiJQcnVlYmFQcm92YWN5In0.xu0AxQvcCYB8Pqu2EGGc9giq4nWAqK4jeUYdGuSHfRA");

                var result = await client.SendAsync(response);
                //var response = await client.PostAsync("", body);
                //var response = client.GetAsync(new Uri("https://api.pinata.cloud/data/testAuthentication"));
                if (result.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        var objDeserializeObject = JsonConvert.DeserializeObject<ArchivosResponse>(content.Result);


                        if (objDeserializeObject != null)
                        {
                            return (objDeserializeObject.cid);
                        }
                    }
                }
                return "";

            }
        }
    }
}
