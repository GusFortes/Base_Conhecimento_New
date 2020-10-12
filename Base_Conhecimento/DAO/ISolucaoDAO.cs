using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Conhecimento.DAO
{
    interface ISolucaoDAO
    {
        public Solucao persistirSolucao(Solucao solucao, Chamado chamado);

        public List <Solucao> consultaSolucoes(String problema);

        public bool alterarSolucao(Solucao solucao);
        public Solucao consultaSolucaoId(int id);
        
         
        
    }
}
