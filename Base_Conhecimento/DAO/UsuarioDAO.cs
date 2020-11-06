using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Base_Conhecimento.DAO
{
    class UsuarioDAO : IUsuarioDAO
    {
        private readonly BaseContext db = new BaseContext();
        Usuario usuario;
        public Usuario consultaUsuario(Usuario usuario)
        {
            var user = from u in db.Usuario
                       where u.usuarioID.Equals(usuario.usuarioID)
                       select u;

            foreach (Usuario u in user)
            {
                if (u.senha == usuario.senha)
                {
                    return u;
                }
                else
                {
                    Usuario usuarionaoencontrado = new Usuario();
                    return usuarionaoencontrado;
                }
            }

            return usuario;
        }
    }
}
