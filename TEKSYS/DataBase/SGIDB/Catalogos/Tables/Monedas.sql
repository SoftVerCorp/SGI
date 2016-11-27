CREATE TABLE [Catalogos].[Monedas] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Moneda] VARCHAR (60) NOT NULL,
    [Activo] BIT          CONSTRAINT [DF_Monedas_Activo] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Moneda] PRIMARY KEY CLUSTERED ([Id] ASC)
);



