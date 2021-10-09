using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Dominio;
using Dominio.Excepciones;
using Repositorio;

namespace Dominio.Servicios
{

    public class Autenticacion
    {
        private RepoUsuario repo;
        private Usuario usu;

        public Autenticacion()
        {
            this.repo = new RepoUsuario();
        }

        private bool validacion(string usuario, string password)
        {
            try
            {
                if(String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(password))
                {
                    return false;
                }
                Usuario usuarioSistema = new Usuario(repo.obtenerUsuario(usuario));
;

                if(usuarioSistema.noLogeado())
                {
                    return false;
                }

                this.usu = usuarioSistema;
                return true;

            }catch(Exception ex)
            {
                throw new Exception("Error en la validacion de cuenta");
            }
        }


        public Usuario login(string usuario, string pass)
        {
            try
            {
                if (!validacion(usuario, pass))
                {
                    throw new NotFoundUser();
                }
                else
                {
                    return this.usu;
                }

            }catch(Exception ex)
            {
                throw new NotFoundUser();
            }
        }

    }
}
