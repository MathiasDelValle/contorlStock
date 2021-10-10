using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dominio
{
    public class Compra
    {
        private int id;
        private DateTime fecha;
        private Souvenir souvenir;
        private int cantidad;


        public Compra(int id, string fecha, int idSouvenir, int cantidad)
        {
            this.id = id;
            this.fecha = DateTime.Now;
            this.cantidad = cantidad;
        }

        public Compra(int id, string fecha, Souvenir souvenir, int cantidad)
        {
            this.id = id;
            this.fecha = DateTime.Now;
            this.souvenir = souvenir;
            this.cantidad = cantidad;
        }

        public bool Guardar()
        {
            return true;
        }


        public int Id { get => id; set => id = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Souvenir Souvenir { get => souvenir; set => souvenir = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
