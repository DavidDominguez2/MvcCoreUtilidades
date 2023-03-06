using Microsoft.AspNetCore.Mvc;

namespace MvcCoreUtilidades.Controllers {
    public class CifradosController : Controller {


        public IActionResult CifradoBasico() {
            return View();
        }

        [HttpPost]
        public IActionResult CifradoBasico(string contenido) {
            return View();
        }
    }
}
