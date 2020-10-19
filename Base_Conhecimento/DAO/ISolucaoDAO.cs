using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Conhecimento.DAO
{
    interface ISolucaoDAO
    {
        public Solucao persistirSolucao(Solucao solucao);
        public Chamado persistirChamado(Chamado chamado);
        public List<Solucao> consultaSolucoes(String problema, Usuario usuario);
        public Solucao alterarSolucao(Solucao solucao);
        public Solucao consultaSolucaoId(int id);
        public List<Solucao> consultaTodasSolucoes();
        public List<Chamado> consultaTodosChamados();
        public Chamado consultaChamadoId(String id);
        public ChamadoSolucaoViewModel persistirInformacoes(Solucao solucao, Chamado chamado);

    }
}
