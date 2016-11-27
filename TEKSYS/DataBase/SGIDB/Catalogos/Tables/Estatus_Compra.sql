CREATE TABLE [Catalogos].[Estatus_Compra] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]            VARCHAR (60) NOT NULL,
    [EnviaNotificacion] BIT          CONSTRAINT [DF_Estatus_Compra_EnviaNotificacion] DEFAULT ((0)) NOT NULL,
    [Activo]            BIT          CONSTRAINT [DF_Estatus_Compra_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Estatus_Compra] PRIMARY KEY CLUSTERED ([Id] ASC)
);



