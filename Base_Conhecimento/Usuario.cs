using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Base_Conhecimento
{
    public class Usuario
    {
        [Display(Name = "Usuário")]
        public String usuarioID { get; set; }
        [Display(Name = "Senha")]
        public String senha { get; set; }
        public String nome { get; set; }
        public String area { get; set; }
        public bool nivel { get; set; }

    }
}
