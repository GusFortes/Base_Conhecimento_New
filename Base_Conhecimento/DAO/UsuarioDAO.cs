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
        public Usuario consultaUsuario(int id)
        {

            var user = from u in db.Usuario
                          where u.usuarioID == id
                          select u;

            foreach (Usuario u in user)
            {
                usuario = u;
            }

            return usuario;
        }
    }
}
