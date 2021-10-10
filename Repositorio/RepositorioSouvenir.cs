using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System;

namespace Repositorio
{
    public class RepositorioSouvenir
    {
        private Conexion bd = new Conexion();

        public DataTable obtenerSouvenirs(int id = 0, string nombre = "")
        {
            string sql = "SELECT * FROM souvenirs ";
            string where = "";
            if (id != 0)
            {
                where = " WHERE id = " + id;
            }
            else
            {
                if (nombre != "")
                {
                    where = " WHERE nombre = '" + nombre + "'";
                }
            }

            if(where == "")
            {
                where = " WHERE activo = 1";
            }

            sql += where;
            return bd.queryConsulta(sql);
        }

        public bool altaSouvenir(string nombre, string descripcion, int stock, decimal precio)
        {
            try
            {
                string sql = "INSERT INTO souvenirs (nombre, descripcion, stock, precio) VALUES ('" + nombre + "', '" + descripcion + "'," + stock + ", " + precio + ");";
                return bd.queryInsertUpdate(sql);
                
            ;}
            catch (Exception ex)
            {
                //Aca deberia logear el error
                throw new Exception("Error al generar el alta del souvenir");
            }
            
        }

        public bool editarSouvenir(int id, string nombre, string descripcion, int stock, decimal precio)
        {
            try
            {
                string p = precio.ToString();
                p = p.Replace(",", ".");
                string sql = "UPDATE souvenirs SET nombre = '" + nombre + "', descripcion = '" + descripcion + "', stock = " + stock + ", precio=" + p + " WHERE id = " + id + ";";
                return bd.queryInsertUpdate(sql);
            }
            catch (Exception ex)
            {
                //Aca deberia logear el error
                throw new Exception("Error al editar el souvenir");
            }
        }

        public bool borrar(int id)
        {
            string sql = "UPDATE souvenirs SET activo = 0 WHERE id = " + id + ";";
            return bd.queryInsertUpdate(sql);
        }
    }
}
