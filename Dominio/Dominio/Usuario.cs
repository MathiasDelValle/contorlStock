using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dominio
{
    public class Usuario
    {
        private int id;
        private string usuario;
        private string password;


        public Usuario(string usuario, string password)
        {
            
            this.usuario = usuario;
            this.password = password;
        }

        public Usuario(DataTable dt)
        {
            if(dt.Rows.Count == 0)
            {
                return;
            }

            this.id         =  (int)dt.Rows[0]["id"];
            this.usuario    = dt.Rows[0]["usuario"].ToString();
            this.password   = dt.Rows[0]["password"].ToString();
        }

        public bool noLogeado()
        {
            return (this.usuario == null || this.password == null);
        }

        public string getNombre()
        {
            return this.usuario;
        }

        public string getPassword()
        {
            return this.password;
        }


    }
}
