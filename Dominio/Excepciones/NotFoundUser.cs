using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Excepciones
{
    class NotFoundUser : Exception
    {

        public NotFoundUser() : base ("El usuario no existe")
        {}
    }
}
