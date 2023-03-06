using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;
using static MvcCoreUtilidades.Helpers.HelperPathProvider;

namespace MvcCoreUtilidades.Controllers {
    public class MailsController : Controller {

        private HelperMails helperMails;
        private HelperUploadFiles helperUploadFiles;

        public MailsController(HelperMails helperMails, HelperUploadFiles helperUploadFiles) {
            this.helperMails = helperMails;
            this.helperUploadFiles = helperUploadFiles;
        }

        public IActionResult SendMail() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(string para, string asunto, string mensaje, List<IFormFile> files) {
            if (files.Count != 0) {
                if (files.Count > 1) {
                    List<string> paths = await this.helperUploadFiles.UploadFilesAsync(files, Folders.Temporal);
                    await this.helperMails.SendMailAsync(para, asunto, mensaje, paths);
                } else {
                    string path = await this.helperUploadFiles.UploadFileAsync(files[0], Folders.Temporal);
                    await this.helperMails.SendMailAsync(para, asunto, mensaje, path);
                }
            } else {
                await this.helperMails.SendMailAsync(para, asunto, mensaje);
            }

            ViewData["MENSAJE"] = "Email enviado correctamnete";

            return View();
        }
    }
}
