using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Repositorio
{
    public class RepoUsuario
    {
        private Conexion bd = new Conexion();

        public DataTable obtenerUsuario(string usuario)
        {
            try
            {
                string sql = "SELECT * FROM usuarios WHERE usuario = '" + usuario + "'";
                return bd.queryConsulta(sql);
            }catch(Exception ex)
            {
                throw new Exception("Error al realizar la consulta");
            }
            
        }
    }
}
