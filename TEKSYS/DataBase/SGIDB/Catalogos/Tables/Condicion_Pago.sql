CREATE TABLE [Catalogos].[Condicion_Pago] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Nombre] VARCHAR (60) NULL,
    [Activo] BIT          CONSTRAINT [DF_Condicion_Pago_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Condicion_Pago] PRIMARY KEY CLUSTERED ([Id] ASC)
);



