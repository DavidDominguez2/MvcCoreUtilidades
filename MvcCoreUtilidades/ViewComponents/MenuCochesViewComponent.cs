using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Models;
using MvcCoreUtilidades.Repositories;

namespace MvcCoreUtilidades.ViewComponents {
    public class MenuCochesViewComponent : ViewComponent {

        private RepositoryCoches repo;

        public MenuCochesViewComponent(RepositoryCoches repo) {
            this.repo = repo;
        }

        //AQUI PODRIAMOS TENER CUALQUIER METODO DE UNA CLASE
        //LA PETICION SE REALIZA MEDIANTE EL METODO InvokeAsync
        //ES OBLIGATORIO TENERLO
        public async Task<IViewComponentResult> InvokeAsync() {
            List<Coche> coches = this.repo.GetCoches();
            return View(coches);
        }

    }
}
