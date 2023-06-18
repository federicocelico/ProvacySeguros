using Aplicacion.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProvacySeguros.Controllers
{
    [ApiController]
    [Route("/Aplicacion")]
    public class AplicacionController : Controller
    {

        IUsuario _usuario;

        public AplicacionController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuario.GetAll();
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
