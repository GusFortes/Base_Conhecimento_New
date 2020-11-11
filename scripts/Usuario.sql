CREATE TABLE [dbo].[Usuario] (
    [usuarioID] VARCHAR (20) NOT NULL, --ID do usuário
    [senha]     VARCHAR (20) NOT NULL, --senha de acesso
    [nome]      VARCHAR (50) NULL, --nome do usuário
    [area]      VARCHAR (20) NULL, --área que o usuário trabalha
    [nivel]     BIT          NULL, --nível de acesso do usuário(True = acesso de analista ou false = acesso de cliente) 
    PRIMARY KEY CLUSTERED ([usuarioID] ASC)
);