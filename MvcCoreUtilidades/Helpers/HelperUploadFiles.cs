using static MvcCoreUtilidades.Helpers.HelperPathProvider;

namespace MvcCoreUtilidades.Helpers {
    public class HelperUploadFiles {

        private HelperPathProvider helperPath;
        private IWebHostEnvironment hostEnv;

        public HelperUploadFiles(HelperPathProvider pathProvider, IWebHostEnvironment hostEnv) {
            this.helperPath = pathProvider;
            this.hostEnv = hostEnv;
        }

        public async Task<string> UploadFileAsync(IFormFile file,string fileName, string host, Folders folder) {
            string carpeta = (folder == Folders.Images) ? "images" : "temp";
            string rootPath = this.hostEnv.WebRootPath;
            string path = Path.Combine(rootPath,carpeta,fileName);

            using (Stream stream = new FileStream(path, FileMode.Create)) {
                await file.CopyToAsync(stream);
                return Path.Combine(host, carpeta, fileName);
            }
    
        }

        public async Task<List<string>> UploadFilesAsync(List<IFormFile> files, Folders folder) {
            List<string> paths = new List<string>();
            foreach (IFormFile file in files) {
                string fileName = file.FileName;
                string path = this.helperPath.MapPath(fileName, folder);
                using (Stream stream = new FileStream(path, FileMode.Create)) {
                    await stream.CopyToAsync(stream);
                }
                paths.Add(path);
            }
            return paths;
        }

    }
}
