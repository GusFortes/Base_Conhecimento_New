using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Base_Conhecimento.DAO
{
    class SolucaoDAO : ISolucaoDAO
    {
        private BaseContext db = new BaseContext();
        private bool salvou;
        public ChamadoSolucaoViewModel persistirInformacoes(Solucao solucao, Chamado chamado)
        {
            db = new BaseContext();
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
                        status = "Ativo",
                        visitas = 0,
                        curtidas = 0
                    });
                    solucao.solucaoID = contador;
                    return solucao;
                }

                else
                {
                    String nomeDosArquivos = "";
                    foreach (var nomeAquivoSolucao in solucao.arquivos)
                    {
                        nomeDosArquivos = nomeDosArquivos + "/" + contador+"_"+nomeAquivoSolucao.FileName;
                    }

                    db.Solucao.Add(new Solucao
                    {
                        solucaoID = contador,
                        titulo = solucao.titulo,
                        usuarioID = solucao.usuarioID,
                        descricao = solucao.descricao,
                        dataAtualizacao = solucao.dataAtualizacao,
                        visualizacao = solucao.visualizacao,
                        status = "Ativo",
                        visitas = 0,
                        curtidas = 0,
                        nomeArquivo = nomeDosArquivos
                    });

                    solucao.solucaoID = contador;

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

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                solucao.solucaoID = -1;
            }

            return solucao;
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
                        nomeDosArquivos = nomeDosArquivos + "/" + chamado.solucaoID+"_"+nomeAquivoChamado.FileName;
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

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                chamado.solucaoID = -1;
            }
            return chamado;
        }
        internal void incrimentarCurtidas(int id)
        {
            db = new BaseContext();
            try
            {
                var solucao = from s in db.Solucao
                              where s.solucaoID == id
                              select s;

                foreach (Solucao sol in solucao)
                {
                    sol.curtidas++;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        internal void incrimentarVisitas(int id)
        {

            db = new BaseContext();
            try
            {
                var solucao = from s in db.Solucao
                              where s.solucaoID == id
                              select s;

                foreach (Solucao sol in solucao)
                {
                    sol.visitas++;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public Chamado ExcluirArquivoChamado(string nome)
        {
            db = new BaseContext();
            Chamado chamado = new Chamado();
            List<String> arquivonome = new List<String>();

            foreach (String nomeArquivo in nome.Split("_"))
            {
                arquivonome.Add(nomeArquivo);

            }
            int id = Int32.Parse(arquivonome.First());
            String arquivo = arquivonome.Last();

            var c = from s in db.Chamado
                    where s.solucaoID == id
                    select s;

            List<String> listaDeNomes = new List<String>();

            foreach (Chamado cham in c)
            {
                foreach (String nomeArquivo in cham.nomeArquivo.Split("/"))
                {

                    listaDeNomes.Add(nomeArquivo);
                }

                listaDeNomes.Remove(nome);

                if (listaDeNomes.Count() > 1)
                {
                    foreach (String nomeArq in listaDeNomes)
                    {
                        cham.nomeArquivo = "/" + nomeArq;
                    }
                }
                else
                {
                    cham.nomeArquivo = "";
                }
                chamado = cham;
            }
            db.SaveChanges();
            return chamado;
        }
        public Solucao ExcluirArquivoSolucao(string nome)
        {
            db = new BaseContext();
            Solucao solucao = new Solucao();
            List<String> arquivonome = new List<String>();
            foreach (String nomeArquivo in nome.Split("_"))
            {
                arquivonome.Add(nomeArquivo);

            }
            int id = Int32.Parse(arquivonome.First());
            String arquivo = arquivonome.Last();

            var solu = from s in db.Solucao
                       where s.solucaoID == id
                       select s;

            List<String> listaDeNomes = new List<String>();

            foreach (Solucao soldb in solu)
            {
                foreach (String nomeArquivo in soldb.nomeArquivo.Split("/"))
                {

                    listaDeNomes.Add(nomeArquivo);
                }

                listaDeNomes.Remove(nome);

                if (listaDeNomes.Count() > 1)
                {
                    foreach (String nomeArq in listaDeNomes)
                    {
                        soldb.nomeArquivo = "/" + nomeArq;
                    }
                }
                else
                {
                    soldb.nomeArquivo = "";
                }
                solucao = soldb;
            }
            db.SaveChanges();
            return solucao;
        }
        public List<Chamado> consultaTodosChamados()
        {
            db = new BaseContext();
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
            db = new BaseContext();
            Chamado chamado = new Chamado();

            var c = from s in db.Chamado
                    where s.chamadoID.Equals(id)
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
        public Chamado consultaChamadoporIdSolucao(int id)
        {
            db = new BaseContext();
            Chamado chamado = new Chamado();

            var c = from s in db.Chamado
                    where s.solucaoID == id
                    select s;

            foreach (Chamado cham in c)
            {
                chamado = cham;
            }
            List<String> arquivoNome = new List<string>();
            if (chamado.nomeArquivo != "" && chamado.nomeArquivo != null)
            {

                foreach (String nome in chamado.nomeArquivo.Split("/"))
                {
                    if (nome == "") { }
                    else
                    {
                        arquivoNome.Add(nome);
                    }
                }

            }
            chamado.nomeArquivos = arquivoNome;
            return chamado;
        }
        public List<Solucao> consultaTodasSolucoes()
        {
            db = new BaseContext();
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
            db = new BaseContext();
            Solucao solucaoencontrada = new Solucao();

            var solucao = from s in db.Solucao
                          where s.solucaoID == id
                          select s;

            foreach (Solucao sol in solucao)
            {
                solucaoencontrada = sol;
            }
            List<String> arquivoNome = new List<string>();
            if (solucaoencontrada.nomeArquivo != "" && solucaoencontrada.nomeArquivo != null)
            {
                foreach (String nome in solucaoencontrada.nomeArquivo.Split("/"))
                {
                    if (nome == "") { }
                    else
                    {
                        arquivoNome.Add(nome);
                    }
                }
                solucaoencontrada.nomeArquivos = arquivoNome;

            }
            else
            {
                solucaoencontrada.nomeArquivos = arquivoNome;
            }
            return solucaoencontrada;
        }
        public Solucao alterarSolucao(Solucao solucao)
        {
            db = new BaseContext();

            var solucoes = from s in db.Solucao
                           where s.solucaoID == solucao.solucaoID
                           select s;
            try
            {
                if (solucao.arquivos == null)
                {
                    {
                        foreach (Solucao s in solucoes)
                        {
                            s.titulo = solucao.titulo;
                            s.descricao = solucao.descricao;
                            s.visualizacao = solucao.visualizacao;
                            s.status = solucao.status;
                            s.usuarioID = solucao.usuarioID;
                            s.dataAtualizacao = DateTime.Now;
                        }
                    }
                }
                else
                {
                    String nomeDosArquivos = "";
                    foreach (var nomeAquivoSolucao in solucao.arquivos)
                    {
                        nomeDosArquivos = nomeDosArquivos + "/" + solucao.solucaoID+"_"+nomeAquivoSolucao.FileName;
                    }

                    foreach (Solucao s in solucoes)
                    {
                        s.titulo = solucao.titulo;
                        s.descricao = solucao.descricao;
                        s.visualizacao = solucao.visualizacao;
                        s.status = solucao.status;
                        s.usuarioID = solucao.usuarioID;
                        s.nomeArquivo = s.nomeArquivo + nomeDosArquivos;
                        s.dataAtualizacao = DateTime.Now;
                        nomeDosArquivos = s.nomeArquivo;
                    }

                    if (nomeDosArquivos != "")
                    {
                        List<String> arquivonome = new List<String>();
                        foreach (String nomeArquivo in nomeDosArquivos.Split("/"))
                        {
                            if (nomeArquivo == "") { }
                            else
                            {
                                arquivonome.Add(nomeArquivo);
                            }
                        }
                        solucao.nomeArquivos = arquivonome;
                    }

                }
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return solucao;
        }
        public Chamado alterarChamado(Chamado chamado)
        {
            db = new BaseContext();
            var chamados = from c in db.Chamado
                           where c.solucaoID == chamado.solucaoID
                           select c;
            try
            {
                if (chamado.arquivos == null)
                {

                    foreach (Chamado c in chamados)
                    {
                        c.descricao = chamado.descricao;
                        c.itemCatalogo = chamado.itemCatalogo;
                    }

                }
                else
                {
                    String nomeDosArquivos = "";
                    foreach (var nomeAquivoChamado in chamado.arquivos)
                    {
                        nomeDosArquivos = nomeDosArquivos + "/" + chamado.solucaoID+"_"+nomeAquivoChamado.FileName;
                    }
                    foreach (Chamado c in chamados)
                    {
                        c.descricao = chamado.descricao;
                        c.itemCatalogo = chamado.itemCatalogo;
                        c.nomeArquivo = c.nomeArquivo + nomeDosArquivos;
                        c.usuarioID = chamado.usuarioID;
                        nomeDosArquivos = c.nomeArquivo;
                    }

                    if (nomeDosArquivos != "")
                    {
                        List<String> arquivonome = new List<String>();
                        foreach (String nomeArquivo in nomeDosArquivos.Split("/"))
                        {
                            if (nomeArquivo == "") { }
                            else
                            {
                                arquivonome.Add(nomeArquivo);
                            }
                        }
                        chamado.nomeArquivos = arquivonome;
                    }
                }

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return chamado;
        }
        public List<Solucao> consultaSolucoes(string problema, Usuario usuario){
            db = new BaseContext();
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
                                  where s.descricao.Contains(palavra) && s.status.Contains("Ativo")
                                  select s;

                    foreach (Solucao se in solucao)
                    {

                        if (se.visualizacao == "Analista")
                        {
                            if (usuario != null && usuario.nivel)
                            {
                                if (solucoesencontradas.Contains(se))
                                {

                                }
                                else
                                {
                                    solucoesencontradas.Add(se);
                                }
                            }
                        }
                        else
                        {
                            if (solucoesencontradas.Contains(se))
                            {

                            }
                            else
                            {
                                solucoesencontradas.Add(se);
                            }
                        }
                    }
                }

                return solucoesencontradas;
            }
            catch { throw new NotImplementedException("Solução não encontrada."); }
        }
    }
}
