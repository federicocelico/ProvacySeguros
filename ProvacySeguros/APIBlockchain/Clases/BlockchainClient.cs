using APIBlockchain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBlockchain.Clases
{
    public class BlockchainClient : IBlockchainClient
    {
        public async void InsertarHash(int id, string hash)
        {
            

                using var client = new HttpClient();
                client.BaseAddress = new Uri("https://provacy-blockchain.onrender.com/record");
                BlockchainRequest Request = new BlockchainRequest();
                Request.id= id;
            Request.hash = hash;
                HttpContent body = new StringContent(JsonConvert.SerializeObject(Request), Encoding.UTF8, "application/json");
            HttpRequestMessage response = new HttpRequestMessage(HttpMethod.Post, "");
            response.Content = body;
            response.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
            var result = await client.SendAsync(response);
        }

        public async void GetHash(int id)
        {


            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://provacy-blockchain.onrender.com/record/" + id);
            BlockchainRequest Request = new BlockchainRequest();
            Request.id = id;
            HttpRequestMessage response = new HttpRequestMessage(HttpMethod.Get, "");
            response.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
            var result = await client.SendAsync(response);
            if (result.IsSuccessStatusCode)
            {
                var content = result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    var objdeserializeobject = JsonConvert.DeserializeObject<string>(content.Result);
                }
            }


        }
    }
}
