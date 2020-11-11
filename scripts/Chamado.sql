CREATE TABLE [dbo].[Chamado] (
    [ChamadoID]    VARCHAR (20) NOT NULL, --ID do chamado
    [Descricao]    TEXT         NULL, --Descrição do chamado
    [SolucaoID]    INT          NOT NULL, --ID da solução
    [UsuarioID]    VARCHAR (20) NULL, --ID do usuário que cadastrou/alterou
    [ItemCatalogo] TEXT         NULL, --Item do catálogo que o chamado pertence
    [nomeArquivo]  TEXT         NULL, --nome dos anexos que o chamado possui
    PRIMARY KEY CLUSTERED ([ChamadoID] ASC)
);
