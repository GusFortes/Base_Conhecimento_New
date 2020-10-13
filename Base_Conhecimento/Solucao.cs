using Base_Conhecimento.DAO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base_Conhecimento
{
    public class Solucao
    {

        SolucaoDAO solucaoDao = new SolucaoDAO();


        [Display(Name = "Código da Solução")]

        public int solucaoID { get; set; }


        public String titulo { get; set; }
        [Display(Name = "Título")]

        public int usuarioID { get; set; }

        public String descricao { get; set; }
        [Display(Name = "Descrição")]

        public DateTime dataAtualizacao { get; set; }
        [Display(Name = "Data de Atualização")]

        public String visualizacao { get; set; }

        public String status { get; set; }


        public String nomeArquivo { get; set; }



        [NotMapped]
        public IFormFile arquivos { get; set; }


        public Solucao persistirSolucao(Solucao solucao, Chamado chamado)
        {
            return solucaoDao.persistirSolucao(solucao, chamado);
        }

        public bool alterarSolucao(Solucao solucao)
        {
            return solucaoDao.alterarSolucao(solucao);
        }

        public List<Solucao> consultaSolucoes(String problema, Usuario usuario)
        {
            return solucaoDao.consultaSolucoes(problema,  usuario);
        }
    }
}
