using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web.Mvc;

namespace Base_Conhecimento
{
    public class Chamado
    {
        [Display(Name = "Código do Chamado")]
        public String chamadoID { get; set; }
        public String usuarioID { get; set; }

        [Display(Name = "Código da Solução")]
        public int solucaoID { get; set; }

        [AllowHtml]
        [Display(Name = "Descrição do Chamado")]
        public String descricao { get; set; }


        [Display(Name = "Item do Catálogo")]
        public String itemCatalogo { get; set; }

        public String nomeArquivo { get; set; }

        [NotMapped]
        public List<IFormFile> arquivos { get; set; }

        [NotMapped]
        public List<String> nomeArquivos { get; set; }


    }


}
