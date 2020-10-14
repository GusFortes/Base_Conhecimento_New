using Base_Conhecimento.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Conhecimento
{
    public class FachadaBase
    {
        SolucaoDAO solucaoDao = new SolucaoDAO();
        UsuarioDAO usuarioDao = new UsuarioDAO();
        private Solucao solucaoaux = new Solucao();
        public static FachadaBase fachada;
        private Chamado chamadoaux;
        public static Usuario usuarioLogado;


        public void registrarChamado(Chamado cham)
        {
            this.chamadoaux = cham;
        }
        public Solucao persistirSolucao(Solucao sol)
        {
            chamadoaux.solucaoID = sol.solucaoID;
            sol.dataAtualizacao = DateTime.Now;
            sol.usuarioID = usuarioLogado.usuarioID;
            chamadoaux.usuarioID = usuarioLogado.usuarioID;
            return solucaoDao.persistirSolucao(sol, chamadoaux);
        }

        public static FachadaBase getInstance()
        {

            if (fachada == null)
            {
                fachada = new FachadaBase();
            }
            return fachada;

        }

        public List<Solucao> consultaSolucoes(String problema)
        {
            return solucaoDao.consultaSolucoes(problema, usuarioLogado);
        }

        public Chamado retornarChamado()
        {
            return chamadoaux;
        }

        public Solucao consultaSolucaoId(int id)
        {

            this.solucaoaux = solucaoDao.consultaSolucaoId(id);
            //  this.id = this.solucaoaux.solucaoID;
            return this.solucaoaux;
        }

        public bool alterarSolucao(Solucao sol)
        {
            // this.solucaoaux.solucaoID = this.id;
            this.solucaoaux.titulo = sol.titulo;
            this.solucaoaux.descricao = sol.descricao;
            this.solucaoaux.usuarioID = usuarioLogado.usuarioID;

            return solucaoDao.alterarSolucao(solucaoaux);
        }

        public Usuario Login(int id)
        {
            if (usuarioLogado == null)
            {
                usuarioLogado = usuarioDao.consultaUsuario(id);
            }
            return usuarioLogado;
        }

    }
}
