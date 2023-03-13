using MvcCoreUtilidades.Models;

namespace MvcCoreUtilidades.Repositories {
    public class RepositoryCoches {
        List<Coche> coches;
        public RepositoryCoches() {
            this.coches = new List<Coche>() {
                new Coche {IdCoche = 1, Marca = "Audi", Modelo = "TT", Imagen="audi-tt.jpg"},
                new Coche {IdCoche = 2, Marca = "Audi", Modelo = "Spider", Imagen="audi-spider.jpg"},
                new Coche {IdCoche = 3, Marca = "Mercedes", Modelo = "CLA", Imagen="mercedes-cla.jpg"},
                new Coche {IdCoche = 4, Marca = "Nissan", Modelo = "GTR", Imagen="nissan-gtr.jpg"},
            };
        }

        public List<Coche> GetCoches() {
            return this.coches;
        }

        public Coche FindCoche(int id) {
            return this.coches.FirstOrDefault(x => x.IdCoche == id);
        }
    }
}
