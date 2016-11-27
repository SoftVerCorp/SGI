CREATE TABLE [Catalogos].[Marcas] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Marca]  VARCHAR (60) NOT NULL,
    [Activo] BIT          CONSTRAINT [DF_Marcas_Activo] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED ([Id] ASC)
);



