using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Base_Conhecimento.DAO
{
    class SolucaoDAO : ISolucaoDAO
    {
        private readonly BaseContext db = new BaseContext();


        public Solucao persistirSolucao(Solucao solucao, Chamado chamado)
        {
            int contador = (from s in db.Solucao
                            select s).Count();
            contador = contador + 1;

            try
            {
                if (solucao.arquivos == null)
                {

                    db.Solucao.Add(new Solucao
                    {
                        solucaoID = contador,
                        titulo = solucao.titulo,
                        usuarioID = solucao.usuarioID,
                        descricao = solucao.descricao,
                        dataAtualizacao = solucao.dataAtualizacao,
                        visualizacao = solucao.visualizacao,
                        status = "Ativo"
                    });

                    db.Chamado.Add(new Chamado
                    {
                        chamadoID = chamado.chamadoID,
                        descricao = chamado.descricao,
                        usuarioID = chamado.usuarioID,
                        solucaoID = contador,
                        itemCatalogo = chamado.itemCatalogo
                    });
                    db.SaveChanges();

                    solucao.solucaoID = contador;
                    return solucao;
                }

                else
                {
                    String nomeArquivos = "";
                    foreach (var nomeAquivoSolucao in solucao.arquivos)
                    {
                        nomeArquivos = nomeArquivos + "/" + nomeAquivoSolucao.FileName;
                    }

                    db.Solucao.Add(new Solucao
                    {
                        solucaoID = contador + 1,
                        titulo = solucao.titulo,
                        usuarioID = solucao.usuarioID,
                        descricao = solucao.descricao,
                        dataAtualizacao = solucao.dataAtualizacao,
                        visualizacao = solucao.visualizacao,
                        status = "Ativo",
                        nomeArquivo = nomeArquivos
                    });

                    db.Chamado.Add(new Chamado
                    {
                        chamadoID = chamado.chamadoID,
                        descricao = chamado.descricao,
                        usuarioID = chamado.usuarioID,
                        solucaoID = chamado.solucaoID,
                        itemCatalogo = chamado.itemCatalogo
                    });
                    db.SaveChanges();

                    solucao.solucaoID = contador++;
                    return solucao;

                }

            }
            catch
            {
                throw new NotImplementedException("Erro ao Gravar Solução. Verifique os dados e tente novamente.");
            }

        }

        public List<Chamado> consultaTodosChamados()
        {
            List<Chamado> chamados = new List<Chamado>();
            var chamadosencontrados = from c in db.Chamado
                                      select c;

            foreach (Chamado cham in chamadosencontrados)
            {
                chamados.Add(cham);
            }

            return chamados;

        }

        public Chamado consultaChamadoId(String id)
        {
            Chamado chamado = new Chamado();

            var c = from s in db.Chamado
                    where s.chamadoID.Equals(id)
                    select s;

            foreach (Chamado cham in c)
            {
                chamado = cham;
            }
            return chamado;
        }

        public List<Solucao> consultaTodasSolucoes()
        {
            List<Solucao> solucoes = new List<Solucao>();
            var solucao = from s in db.Solucao
                          select s;


            foreach (Solucao sol in solucao)
            {
                solucoes.Add(sol);
            }

            foreach (Solucao sol in solucoes)
            {
                if (sol.nomeArquivo != null)
                {
                    List<String> arquivonome = new List<String>();
                    foreach (String nomeaquivo in sol.nomeArquivo.Split("/"))
                    {
                        arquivonome.Add(nomeaquivo);
                    }
                }
            }


            return solucoes;
        }

        public Solucao consultaSolucaoId(int id)
        {
            Solucao solucaoencontrada = new Solucao();

            var solucao = from s in db.Solucao
                          where s.solucaoID == id
                          select s;

            foreach (Solucao sol in solucao)
            {
                solucaoencontrada = sol;
            }

            return solucaoencontrada;
        }

        public bool alterarSolucao(Solucao solucao)
        {
            var solucoes = from s in db.Solucao
                           where s.solucaoID == solucao.solucaoID
                           select s;
            try
            {
                foreach (Solucao s in solucoes)
                {
                    s.titulo = solucao.titulo;
                    s.descricao = solucao.descricao;
                    s.visualizacao = solucao.visualizacao;
                    s.status = solucao.status;
                }
                db.SaveChanges();
            }
            catch { throw new NotImplementedException("Erro ao alterar solução. Favor, verificar."); }
            return true;
        }

        public List<Solucao> consultaSolucoes(string problema, Usuario usuario)
        {
            List<String> palavrasProblemas = new List<String>();
            List<Solucao> solucoesencontradas = new List<Solucao>();

            foreach (var palavra in problema.Split(' '))
            {
                palavrasProblemas.Add(palavra);
            }
            //try
            //{
            foreach (var palavra in palavrasProblemas)
            {
                var solucao = from s in db.Solucao
                              where s.descricao.Contains(palavra)
                              select s;

                foreach (Solucao se in solucao)
                {

                    if (se.visualizacao == "Analista")
                    {
                        if (usuario != null && usuario.nivel)
                        {
                            solucoesencontradas.Add(se);
                        }
                    }
                    else
                    {
                        solucoesencontradas.Add(se);
                    }
                }
            }

            return solucoesencontradas;
            //}
            //catch { throw new NotImplementedException("Solução não encontrada."); }
        }


    }
}
