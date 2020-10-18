﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Base_Conhecimento.DAO
{
    class SolucaoDAO : ISolucaoDAO
    {
        private readonly BaseContext db = new BaseContext();
        public ChamadoSolucaoViewModel persistirInformacoes(Solucao solucao, Chamado chamado)
        {
            ChamadoSolucaoViewModel chamadoSolucao = new ChamadoSolucaoViewModel();

            chamadoSolucao.solucaoModel = persistirSolucao(solucao);
            chamado.solucaoID = chamadoSolucao.solucaoModel.solucaoID;
            chamadoSolucao.chamadoModel = persistirChamado(chamado);

            return chamadoSolucao;
        }

        public Solucao persistirSolucao(Solucao solucao)
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
                    solucao.solucaoID = contador;
                    return solucao;
                }

                else
                {
                    String nomeDosArquivos = "";
                    foreach (var nomeAquivoSolucao in solucao.arquivos)
                    {
                        nomeDosArquivos = nomeDosArquivos + "/" + nomeAquivoSolucao.FileName;
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
                        nomeArquivo = nomeDosArquivos
                    });

                    solucao.solucaoID = contador++;

                    if (nomeDosArquivos != "")
                    {
                        List<String> arquivonome = new List<String>();
                        foreach (String nomeArquivo in nomeDosArquivos.Split("/"))
                        {
                            if (nomeArquivo == "") { }
                            else
                            {
                                arquivonome.Add(solucao.solucaoID + "_" + nomeArquivo);
                            }
                        }
                        solucao.nomeArquivos = arquivonome;
                    }
                    return solucao;
                }

            }
            catch
            {
                throw new NotImplementedException("Erro ao Gravar Solução. Verifique os dados e tente novamente.");
            }

        }
        public Chamado persistirChamado(Chamado chamado)
        {
            try
            {
                if (chamado.arquivos == null)
                {
                    db.Chamado.Add(new Chamado
                    {
                        chamadoID = chamado.chamadoID,
                        descricao = chamado.descricao,
                        usuarioID = chamado.usuarioID,
                        solucaoID = chamado.solucaoID,
                        itemCatalogo = chamado.itemCatalogo
                    });
                    db.SaveChanges();
                    return chamado;
                }
                else
                {
                    String nomeDosArquivos = "";
                    foreach (var nomeAquivoChamado in chamado.arquivos)
                    {
                        nomeDosArquivos = nomeDosArquivos + "/" + nomeAquivoChamado.FileName;
                    }
                    db.Chamado.Add(new Chamado
                    {
                        chamadoID = chamado.chamadoID,
                        descricao = chamado.descricao,
                        usuarioID = chamado.usuarioID,
                        solucaoID = chamado.solucaoID,
                        itemCatalogo = chamado.itemCatalogo,
                        nomeArquivo = nomeDosArquivos
                    });
                    db.SaveChanges();

                    if (nomeDosArquivos != "")
                    {
                        List<String> arquivonome = new List<String>();
                        foreach (String nomeArquivo in nomeDosArquivos.Split("/"))
                        {
                            if (nomeArquivo == "") { }
                            else
                            {
                                arquivonome.Add(chamado.solucaoID + "_" + nomeArquivo);
                            }
                        }
                        chamado.nomeArquivos = arquivonome;
                    }
                    return chamado;
                }
            }

            catch
            {
                throw new NotImplementedException("Erro ao Gravar Chamado. Verifique os dados e tente novamente.");
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

        public Chamado consultaChamadoId(int id)
        {
            Chamado chamado = new Chamado();

            var c = from s in db.Chamado
                    where s.solucaoID == id
                    select s;

            foreach (Chamado cham in c)
            {
                chamado = cham;
            }

            if (chamado.nomeArquivo != "" && chamado.nomeArquivo != null)
            {
                List<String> arquivoNome = new List<string>();
                foreach (String nome in chamado.nomeArquivo.Split("/"))
                {
                    if (nome == "") { }
                    else
                    {
                        arquivoNome.Add(chamado.solucaoID + "_" + nome);
                    }
                }
                chamado.nomeArquivos = arquivoNome;
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

        public bool alterarChamado(Chamado chamado)
        {
            var chamados = from c in db.Chamado
                           where c.solucaoID == chamado.solucaoID
                           select c;
            try
            {
                foreach (Chamado c in chamados)
                {
                    c.descricao = chamado.descricao;
                    c.itemCatalogo = chamado.itemCatalogo;

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
            try
            {
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
            }
            catch { throw new NotImplementedException("Solução não encontrada."); }
        }
    }
}
