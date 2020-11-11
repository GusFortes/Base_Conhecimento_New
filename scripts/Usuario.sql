CREATE TABLE [dbo].[Usuario] (
    [usuarioID] VARCHAR (20) NOT NULL, --ID do usu�rio
    [senha]     VARCHAR (20) NOT NULL, --senha de acesso
    [nome]      VARCHAR (50) NULL, --nome do usu�rio
    [area]      VARCHAR (20) NULL, --�rea que o usu�rio trabalha
    [nivel]     BIT          NULL, --n�vel de acesso do usu�rio(True = acesso de analista ou false = acesso de cliente) 
    PRIMARY KEY CLUSTERED ([usuarioID] ASC)
);