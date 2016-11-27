CREATE TABLE [Catalogos].[Familias] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Familia] VARCHAR (60) NOT NULL,
    [Activo]  BIT          CONSTRAINT [DF_Familias_Activo] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Familias] PRIMARY KEY CLUSTERED ([Id] ASC)
);



