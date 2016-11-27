CREATE TABLE [Catalogos].[Modelos] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Modelo] VARCHAR (60) NOT NULL,
    [Activo] BIT          CONSTRAINT [DF_Modelos_Activo] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Modelos] PRIMARY KEY CLUSTERED ([Id] ASC)
);



