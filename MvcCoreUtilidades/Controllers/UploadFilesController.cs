using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;
using static MvcCoreUtilidades.Helpers.HelperPathProvider;

namespace MvcCoreUtilidades.Controllers {
    public class UploadFilesController : Controller {


        private HelperPathProvider helperPathProvider;

        public UploadFilesController(HelperPathProvider helperPathProvider) {

            this.helperPathProvider = helperPathProvider;
        }

        public IActionResult SubirFicheros() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirFicheros(IFormFile fichero) {
            string fileName = fichero.FileName;
            string path = this.helperPathProvider.MapPath(fileName, Folders.Uploads);

            using (Stream stream = new FileStream(path, FileMode.Create)) {
                await fichero.CopyToAsync(stream);
            }



            ViewData["MENSAJE"] = "Fichero subido a " + path;
            ViewData["URL"] = "<a href=''>Mi fichero</a>";
            return View();
        }
    }
}
