using Base_Conhecimento.DAO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Base_Conhecimento
{
    public class Solucao
    {

        SolucaoDAO solucaoDao = new SolucaoDAO();


        [Display(Name = "Código da Solução")]
        public int solucaoID { get; set; }

        [Display(Name = "Título")]
        public String titulo { get; set; }


        public int usuarioID { get; set; }


        [AllowHtml]
        [Display(Name = "Descrição")]
        public String descricao { get; set; }


        [Display(Name = "Data de Atualização")]
        public DateTime dataAtualizacao { get; set; }

        public String visualizacao { get; set; }
        public String status { get; set; }

        public String nomeArquivo { get; set; }

        [NotMapped]
        public List<IFormFile> arquivos { get; set; }

        [NotMapped]
        public List<String> nomeArquivos { get; set; }


        public Solucao persistirSolucao(Solucao solucao, Chamado chamado)
        {
            return solucaoDao.persistirSolucao(solucao);
        }

        public bool alterarSolucao(Solucao solucao)
        {
            return solucaoDao.alterarSolucao(solucao);
        }

        public List<Solucao> consultaSolucoes(String problema, Usuario usuario)
        {
            return solucaoDao.consultaSolucoes(problema, usuario);
        }
    }
}
