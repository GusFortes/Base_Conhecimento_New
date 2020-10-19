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
        public int idSolucao;

        public List<Solucao> consultaTodasSolucoes()
        {
            return solucaoDao.consultaTodasSolucoes();
        }

        public List<Chamado> consultaTodosChamados()
        {
            return solucaoDao.consultaTodosChamados();
        }

        public void registrarChamado(Chamado cham)
        {
            this.chamadoaux = cham;
        }
        public ChamadoSolucaoViewModel persistirInformacoes(Solucao sol, Chamado cham)
        {
            chamadoaux.solucaoID = sol.solucaoID;
            sol.dataAtualizacao = DateTime.Now;
            sol.usuarioID = usuarioLogado.usuarioID;
            chamadoaux.usuarioID = usuarioLogado.usuarioID;
            return solucaoDao.persistirInformacoes(sol, cham);
        }

        public static FachadaBase getInstance()
        {

            if (fachada == null)
            {
                fachada = new FachadaBase();
            }
            return fachada;

        }

        public Chamado consultaChamadoId(String id)
        {
            return solucaoDao.consultaChamadoId(id);
        }

        public Chamado consultaChamadoporId(int id)
        {
            idSolucao = id;
            return solucaoDao.consultaChamadoporId(id);
        }

        public List<Solucao> consultaSolucoes(String problema)
        {
            return solucaoDao.consultaSolucoes(problema, usuarioLogado);
        }

        public Chamado alterarChamado(Chamado chamadoModel)
        {
            chamadoModel.usuarioID = usuarioLogado.usuarioID;
            chamadoModel.solucaoID = idSolucao;
            return solucaoDao.alterarChamado(chamadoModel);
        }

        public Solucao consultaSolucaoId(int id)
        {

            this.solucaoaux = solucaoDao.consultaSolucaoId(id);
            //  this.id = this.solucaoaux.solucaoID;
            return this.solucaoaux;
        }

        public Solucao alterarSolucao(Solucao sol)
        {
            return solucaoDao.alterarSolucao(sol);
        }

        public ChamadoSolucaoViewModel ExluirArquivo(string nome)
        {
            ChamadoSolucaoViewModel cs = new ChamadoSolucaoViewModel();
            Chamado cham = solucaoDao.ExcluirArquivo(nome);
            Solucao sol = solucaoDao.consultaSolucaoId(cham.solucaoID);
            cs.chamadoModel = cham;
            cs.solucaoModel = sol;

            return cs;
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
