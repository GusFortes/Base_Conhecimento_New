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
        public static Usuario usuarioLogado = new Usuario();
        public int idSolucao;


        public Usuario retornaUsuario()
        {
            return usuarioLogado;
        }

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

        public void Logout()
        {
            usuarioLogado = new Usuario();
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

        public void incrementarVisitas(int id)
        {
            solucaoDao.incrimentarVisitas(id);
        }

        public Chamado consultaChamadoporIdSolucao(int id)
        {
            idSolucao = id;
            return solucaoDao.consultaChamadoporIdSolucao(id);
        }

        public void incrementarCurtidas(int id)
        {
            solucaoDao.incrimentarCurtidas(id);
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
            sol.solucaoID = idSolucao;
            sol.usuarioID = usuarioLogado.usuarioID;
            return solucaoDao.alterarSolucao(sol);
        }

        public ChamadoSolucaoViewModel ExluirArquivoChamado(string nome)
        {
            ChamadoSolucaoViewModel cs = new ChamadoSolucaoViewModel();
            Chamado cham = solucaoDao.consultaChamadoporIdSolucao(solucaoDao.ExcluirArquivoChamado(nome).solucaoID);
            Solucao sol = solucaoDao.consultaSolucaoId(cham.solucaoID);
            cs.chamadoModel = cham;
            cs.solucaoModel = sol;

            return cs;
        }
        public ChamadoSolucaoViewModel ExluirArquivoSolucao(string nome)
        {
            ChamadoSolucaoViewModel cs = new ChamadoSolucaoViewModel();
            Solucao sol = solucaoDao.consultaSolucaoId(solucaoDao.ExcluirArquivoSolucao(nome).solucaoID);
            Chamado cham = solucaoDao.consultaChamadoporIdSolucao(sol.solucaoID);
            cs.chamadoModel = cham;
            cs.solucaoModel = sol;

            return cs;
        }

        public Usuario Login(int id)
        {
            if (usuarioLogado.usuarioID == 0)
            {
                usuarioLogado = usuarioDao.consultaUsuario(id);
            }
            return usuarioLogado;
        }

    }
}
