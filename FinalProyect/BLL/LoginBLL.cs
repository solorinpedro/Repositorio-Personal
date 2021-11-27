using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FinalProyect.DAL;

namespace FinalProyect.BLL
{
    public class LoginBLL
    {
        public static bool Validar(string nombreusuario, string clave)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var validar = from usuario in contexto.Usuarios
                              where usuario.NombreUsuario == nombreusuario
                              && usuario.Clave == GetSHA256(clave)
                              select usuario;

                if (validar.Count() > 0)
                    paso = true;
                else
                    paso = false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
