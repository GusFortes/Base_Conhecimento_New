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
            usuario = new Usuario();

            var user = from u in db.Usuario
                          where u.usuarioID == id
                          select u;

            foreach (Usuario u in user)
            {
                //if(u.senha == user.senha){}
                usuario = u;

            }

            return usuario;
        }
    }
}
