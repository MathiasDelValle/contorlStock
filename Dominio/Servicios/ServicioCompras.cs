using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Dominio;

namespace Dominio.Servicios
{
    public class ServicioCompras
    {

        private Repositorio.RepositorioCompra repo = new Repositorio.RepositorioCompra();

        public List<Compra> listadoCompras()
        {
            DataTable dataSouvenirs = repo.obtenerCompras();
            List<Compra> compras = new List<Compra>();
            ServicioSouvenirs s = new ServicioSouvenirs();
            foreach (DataRow row in dataSouvenirs.Rows)
            {
                int id = (int)row["id"];
                Souvenir souvenir = s.obtenerSouvenir((int)row["souvenir_id"]);
                string fecha = row["fecha_compra"].ToString();
                int cantidad = (int)row["cantidad"];

                compras.Add(new Compra(id, fecha, souvenir, cantidad));
            }

            return compras;
        }

        public bool realizarCompra(ref Souvenir suv, int cantidad)
        {
            try
            {
                bool resultado = repo.altaCompra(suv.Id, cantidad);
                if (resultado){suv.Stock -= 1;}
                return resultado;

            }catch(Exception ex)
            {
                throw new Exception("Error al realizar la compra");
            }
        }
    }
}
