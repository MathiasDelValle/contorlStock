using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioCompra
    {
        private Conexion bd = new Conexion();

        public DataTable obtenerCompras()
        {
            string sql = "SELECT * FROM compras ORDER BY id DESC LIMIT 100";
            return bd.queryConsulta(sql);
        }

        public bool altaCompra(int id_souvenir, int cantidad)
        {
            try
            {
                string sql = "INSERT INTO compras (souvenir_id, cantidad) VALUES (" + id_souvenir + ", " + cantidad + ");";
                return bd.queryInsertUpdate(sql);
            }
            catch (Exception ex)
            {
                //Aca deberia logear el error
                throw new Exception("Error al generar el alta del souvenir");
            }

        }
    }
}
