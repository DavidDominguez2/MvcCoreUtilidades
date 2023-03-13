using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Models;

namespace MvcCoreUtilidades.Controllers {
    public class CochesController : Controller {

        private List<Coche> Cars;

        public CochesController() {
            this.Cars = new List<Coche>() {
                new Coche {IdCoche = 1, Marca = "Audi", Modelo = "TT", Imagen="audi-tt.jpg"},
                new Coche {IdCoche = 2, Marca = "Audi", Modelo = "Spider", Imagen="audi-spider.jpg"},
                new Coche {IdCoche = 3, Marca = "Mercedes", Modelo = "CLA", Imagen="mercedes-cla.jpg"},
                new Coche {IdCoche = 4, Marca = "Nissan", Modelo = "GTR", Imagen="nissan-gtr.jpg"},
            };
        }

        //EN LA VISTA PRINCIPAL SERA DONDE INTEGREMOS
        //LAS PETICIONES ASINCRONAS
        public IActionResult Index() {
            return View();
        }

        public IActionResult Details(int idCoche) {
            Coche car = this.Cars.FirstOrDefault(x => x.IdCoche == idCoche);
            return View(car);
        }

        //NECESITAMOS UNA PETICION PARA CADA VISTA ASINCRONA
        //QUE VAYAMOS A UTILIZAR
        //LOS METODS PUEDEN LLAMARSE COMO QUERAMOS, ES DECIR,
        //DIFERENTES A LOS NOMBRES DE LAS VISTAS QUE UTILIZAN
        public IActionResult _CochesPartial() {
            //SI VAMOS A UTILIZAR UNA VISTA PARCIAL CON AJAX
            //DEBEMOS DEVOLVER PartialView
            //PartialView DEBE TENER EL NOMBRE DE LA VISTA PARCIAL
            //Y EL MODELO SI LO NECESITAMOS
            return PartialView("_CochesPartial", this.Cars);
        }

        //SI ESTAMOS UTILIZANDO PartialView, SOLAMENTE
        //PODEMOS RECIBIR PRIMITIVOS
        public IActionResult _DetailsCoche(int idCoche) {
            Coche car = this.Cars.FirstOrDefault(x => x.IdCoche == idCoche);
            return PartialView("_DetailsCoche", car);
        }
    }
}
