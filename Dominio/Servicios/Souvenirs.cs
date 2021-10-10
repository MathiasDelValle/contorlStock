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
    class Souvenirs
    {

        private RepositorioSouvenir repo = new RepositorioSouvenir();
            
        public List<Souvenir> listarSouvenirs()
        {
            DataTable dataSouvenirs = repo.obtenerSouvenirs();
            List<Souvenir> souvenirs = new List<Souvenir>();
            foreach (DataRow row in dataSouvenirs.Rows)
            {
                int id = (int)row["id"];
                string nombre = row["nombre"].ToString();
                string descripcion = row["descripcion"].ToString();
                int stock = (int)row["stock"];
                decimal precio = (decimal)row["precio"];
                string fecha = row["fecha_creado"].ToString();
                
                souvenirs.Add(new Souvenir(id, nombre, descripcion, stock, precio, fecha));
            }

            return souvenirs;
        }
    }
}
