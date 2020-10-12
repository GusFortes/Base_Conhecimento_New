using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base_Conhecimento
{
    public class Usuario
    {
        public String usuarioID { get; set; }
        public string email { get; set; }
        [DataType(DataType.EmailAddress)]
        public String nome { get; set; }
        public String area { get; set; }
        public byte nivel { get; set; }
    }
}
