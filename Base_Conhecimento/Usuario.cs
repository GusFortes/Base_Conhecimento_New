﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base_Conhecimento
{
    public class Usuario
    {
        public int usuarioID { get; set; }
        public String nome { get; set; }
        public String area { get; set; }
        public bool nivel { get; set; }
    }
}