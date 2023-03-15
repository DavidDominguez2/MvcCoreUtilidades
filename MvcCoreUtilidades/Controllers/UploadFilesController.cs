using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;
using static MvcCoreUtilidades.Helpers.HelperPathProvider;

namespace MvcCoreUtilidades.Controllers {
    public class UploadFilesController : Controller {


        private HelperUploadFiles helperUpload;

        public UploadFilesController(HelperUploadFiles helperUpload) {

            this.helperUpload = helperUpload;
        }

        public IActionResult SubirFicheros() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirFicheros(IFormFile fichero) {
           string protocol  = HttpContext.Request.IsHttps ? "https://" : "http://";
            string domainName = HttpContext.Request.Host.Value.ToString();
            string url = protocol + domainName;
            string path = await this.helperUpload.UploadFileAsync(fichero, fichero.FileName, url, Folders.Images);
            ViewData["PATH"] = path;
            return View();
        }
    }
}
