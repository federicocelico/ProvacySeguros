using APIBlockchain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;


namespace ProvacySeguros.Controllers
{
    [ApiController]
    [Route("/Storage")]
    public class Web3StorageController : Controller
    {
        IHash _hash;

        public Web3StorageController(IHash hash)
        {
            _hash = hash;
        }
        [HttpPost]
        [Route("/Upload")]
        public List<string> UploadFile(List<IFormFile> files)
        {
            List<string> hashes = new List<string>();
            foreach (var file in files)
            {
                hashes.Add(_hash.CalcularHash(file));
                
            }
            return hashes;
        }

        [HttpPost]
        [Route("/Verify")]
        public bool VerifyHash(List<IFormFile> files)
        {
            List<string> hashes = new List<string>();
            foreach (var file in files)
            {
                hashes.Add(_hash.CalcularHash(file));


            }

            return _hash.VerifyHash(hashes[0], hashes[1]);
        }



    }
}
