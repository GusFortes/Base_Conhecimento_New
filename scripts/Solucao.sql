CREATE TABLE [dbo].[Solucao] (
    [solucaoID]       INT          NOT NULL, --ID da solução
    [titulo]          TEXT         NULL, --Título da solução
    [usuarioID]       VARCHAR (20) NULL, --ID do usuário que cadastrou/alterou
    [descricao]       TEXT         NULL, --Descrição da solução
    [dataInclusao]    DATETIME     NULL, --Data de criação da solução
    [dataAtualizacao] DATETIME     NULL, --Data de atualização da solução
    [visualizacao]    TEXT         NULL, --Quem tem acesso a solução (Analista ou Cliente)
    [status]          TEXT         NULL, --Status da solução (Ativo ou Desativado)
    [nomeArquivo]     TEXT         NULL, --nome dos anexos que a solução possui
    [visitas]         INT          NULL, --número de visitas que a solução tem
    [curtidas]        INT          NULL, --número de curtidas da solução
    PRIMARY KEY CLUSTERED ([solucaoID] ASC)
);

