using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public static class PasswordHelper
    {
        public static string ConvertirABase64(string textoPlano)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(textoPlano);
            return Convert.ToBase64String(bytes);
        }
    }
}
