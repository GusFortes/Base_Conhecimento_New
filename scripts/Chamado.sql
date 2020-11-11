CREATE TABLE [dbo].[Chamado] (
    [ChamadoID]    VARCHAR (20) NOT NULL, --ID do chamado
    [Descricao]    TEXT         NULL, --Descri��o do chamado
    [SolucaoID]    INT          NOT NULL, --ID da solu��o
    [UsuarioID]    VARCHAR (20) NULL, --ID do usu�rio que cadastrou/alterou
    [ItemCatalogo] TEXT         NULL, --Item do cat�logo que o chamado pertence
    [nomeArquivo]  TEXT         NULL, --nome dos anexos que o chamado possui
    PRIMARY KEY CLUSTERED ([ChamadoID] ASC)
);
