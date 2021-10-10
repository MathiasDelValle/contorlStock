using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Dominio;
using Repositorio;

namespace Dominio.Servicios
{
    public class ServicioSouvenirs
    {
        private RepositorioSouvenir repo = new RepositorioSouvenir();

        public List<Souvenir> listarSouvenirs(bool controlarStock = false)
        {

            DataTable dataSouvenirs = repo.obtenerSouvenirs(stock: controlarStock);
            List<Souvenir> souvenirs = new List<Souvenir>();
            foreach (DataRow row in dataSouvenirs.Rows)
            {
                int id = (int)row["id"];
                string nombre = row["nombre"].ToString();
                string descripcion = row["descripcion"].ToString();
                int stock = (int)row["stock"];
                decimal precio = (decimal)row["precio"];
                string fecha = row["fecha_alta"].ToString();

                souvenirs.Add(new Souvenir(id, nombre, descripcion, stock, precio, fecha));
            }

            return souvenirs;
        }

        public bool altaSouvenir(int id, string nombre, string descripcion, int stock, decimal precio)
        {
            Souvenir souv = new Souvenir(id,nombre: nombre, descripcion: descripcion, stock: stock, precio: precio, fechaAlta: DateTime.Now.ToString());

            return souv.guardar();
        }

        public Souvenir obtenerSouvenir(int id)
        {
            DataTable dataSounvenir = repo.obtenerSouvenirs(id);

            if(dataSounvenir.Rows.Count <= 0)
            {
                throw new Exception("No existe el souvenir indicado indicado");
            }

            DataRow row = dataSounvenir.Rows[0];

            string nombre = row["nombre"].ToString();
            string descripcion = row["descripcion"].ToString();
            int stock = (int)row["stock"];
            decimal precio = (decimal)row["precio"];
            string fecha = row["fecha_alta"].ToString();

            return new Souvenir(id, nombre, descripcion, stock, precio, fecha);
        }


        public bool bajaSouvenir(int id)
        {
            return this.repo.borrar(id);
        }
    }
}
