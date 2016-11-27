CREATE TABLE [Productos].[Tipo_Oferta] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Tipo_Oferta] VARCHAR (60) NOT NULL,
    [Activo]      BIT          CONSTRAINT [DF_Tipo_Oferta_Activo] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Productos_Tipo_Oferta] PRIMARY KEY CLUSTERED ([Id] ASC)
);



