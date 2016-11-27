CREATE TABLE [Catalogos].[Usuarios] (
    [IdUsuario] VARCHAR (20)   NOT NULL,
    [Password]  NVARCHAR (300) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);



