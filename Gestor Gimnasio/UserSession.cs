using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//mantiene en memoria los datos del usuario mientras la app está abierta
namespace Gestor_Gimnasio
{
    public enum RolSistema
    {
        SuperAdmin = 1,
        Dueño = 2,
        Administrador = 3
    }

    public static class UserSession
    {
        public static int IdUsuario { get; set; }
        public static string Nombre { get; set; }
        public static RolSistema Rol { get; set; }

        public static bool IsLogged => IdUsuario > 0;
    }
}
