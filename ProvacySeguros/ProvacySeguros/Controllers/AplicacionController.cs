using APIBlockchain.Interfaces;
using Aplicacion.Interfaces;
using AutoMapper;
using DAL.Model;
using DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web3.Storage.Interfaces;

namespace ProvacySeguros.Controllers
{
    [ApiController]
    [Route("/Aplicacion")]
    public class AplicacionController : Controller
    {

        private readonly IUsuario _usuario;
        private readonly IHash _hash;
        private readonly IColaborador _colaborador;
        private readonly IMapper _mapper;
        private readonly IArchivoWeb _iArchivoWeb;
        public AplicacionController(IUsuario usuario, IHash hash, IColaborador colaborador, IArchivoWeb iArchivoWeb, IMapper mapper)
        {
            _usuario = usuario;
            _hash = hash;
            _colaborador = colaborador;
            _iArchivoWeb = iArchivoWeb;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuario.GetAll();
        }
        [EnableCors]
        [HttpPost, Route("/Colaborador")]
        public void Colaborador([FromQuery] ColaboradorDTO colaboradorInput, [FromQuery] List<IFormFile> files)
        {
            
            List<string> hashes = new List<string>();
            Usuario usuario1 = _usuario.Get(1);
            Colaborador colab = new Colaborador();
            colab.IdUsuario = usuario1.Id;
            colab.Direccion = colaboradorInput.Direccion;
            colab.Descripcion = colaboradorInput.Descripcion;
            colab.Patente = colaboradorInput.Patente;
           
           
            _colaborador.InsertColaborador(colab);
            foreach (var file in files)
            {
                hashes.Add(_hash.CalcularHash(file));
                _iArchivoWeb.Encriptar(file);
            }

        }

        [HttpPost, Route("/Desencriptar")]
        public void Desencriptar([FromQuery] List<IFormFile> files)
        {
            foreach (var file in files)
            {
                _iArchivoWeb.Desencriptar(file);
            }

        }
            // GET: AplicacionController
            //public ActionResult Index()
            //{
            //    return View();
            //}

            //// GET: AplicacionController/Details/5
            //public ActionResult Details(int id)
            //{
            //    return View();
            //}

            //// GET: AplicacionController/Create
            //public ActionResult Create()
            //{
            //    return View();
            //}

            //// POST: AplicacionController/Create
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Create(IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}

            //// GET: AplicacionController/Edit/5
            //public ActionResult Edit(int id)
            //{
            //    return View();
            //}

            //// POST: AplicacionController/Edit/5
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Edit(int id, IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}

            //// GET: AplicacionController/Delete/5
            //public ActionResult Delete(int id)
            //{
            //    return View();
            //}

            //// POST: AplicacionController/Delete/5
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Delete(int id, IFormCollection collection)
            //{
            //    try
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}
        }
}
