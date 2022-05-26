using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netCore.Datos;
using netCore.Models;
namespace netCore.Controllers
{
    public class MantenedorController : Controller
    { UnidadesDatos _UnidadesDatos = new UnidadesDatos();
        public IActionResult Listar()
        {
            // muestra Unidades
            var oLista = _UnidadesDatos.Listar();
            return View(oLista);
        }
        public IActionResult Crear()
        {
            //devuelve vista
            return View();
        }
        [HttpPost]
        public IActionResult Crear(UnidadesModel ounidades)
        {//recibe un objeto y lo guarda en base de datos
            if (!ModelState.IsValid)
                return View();
            
            
            var respuesta = _UnidadesDatos.Crear(ounidades);
            if (respuesta)
                return RedirectToAction("Listar");
            else
            return View();
        }
   
    }
   
}
