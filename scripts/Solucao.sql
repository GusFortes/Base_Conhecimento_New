CREATE TABLE [dbo].[Solucao] (
    [solucaoID]       INT          NOT NULL, --ID da solu��o
    [titulo]          TEXT         NULL, --T�tulo da solu��o
    [usuarioID]       VARCHAR (20) NULL, --ID do usu�rio que cadastrou/alterou
    [descricao]       TEXT         NULL, --Descri��o da solu��o
    [dataInclusao]    DATETIME     NULL, --Data de cria��o da solu��o
    [dataAtualizacao] DATETIME     NULL, --Data de atualiza��o da solu��o
    [visualizacao]    TEXT         NULL, --Quem tem acesso a solu��o (Analista ou Cliente)
    [status]          TEXT         NULL, --Status da solu��o (Ativo ou Desativado)
    [nomeArquivo]     TEXT         NULL, --nome dos anexos que a solu��o possui
    [visitas]         INT          NULL, --n�mero de visitas que a solu��o tem
    [curtidas]        INT          NULL, --n�mero de curtidas da solu��o
    PRIMARY KEY CLUSTERED ([solucaoID] ASC)
);

