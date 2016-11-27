CREATE TABLE [dbo].[Costo_Concepto] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Concepto] VARCHAR (60) NOT NULL,
    [Activo]   BIT          CONSTRAINT [DF_Costo_Concepto_Activo] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Costo_Concepto] PRIMARY KEY CLUSTERED ([Id] ASC)
);



