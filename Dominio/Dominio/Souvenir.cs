using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dominio
{
    public class Souvenir
    {

        private int id;
        private string nombre;
        private string descripcion;
        private int stock;
        private decimal precio;
        private DateTime fechaAlta;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Stock { get => stock; set => stock = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }

        public Souvenir(int id, string nombre, string descripcion, int stock, decimal precio, string fechaAlta)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.stock = stock;
            this.precio = precio;
            this.fechaAlta = new DateTime();
        }

        public bool guardar()
        {
            Repositorio.RepositorioSouvenir repo = new Repositorio.RepositorioSouvenir();
            bool resultado = false;
            if(this.id != 0)
            {
                resultado = repo.editarSouvenir(this.id, this.nombre, this.descripcion, this.stock, this.precio);
            }
            else
            {
                resultado = repo.altaSouvenir(this.nombre,this.descripcion, this.stock, this.precio);
            }

            return resultado;
        }


        public bool baja()
        {
            Repositorio.RepositorioSouvenir repo = new Repositorio.RepositorioSouvenir();
            return true;
            //repo.borrar(this.id);
        }

        override
        public string ToString()
        {
            return this.nombre;
        }
    }
}
