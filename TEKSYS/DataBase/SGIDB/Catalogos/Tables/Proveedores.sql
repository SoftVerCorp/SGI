CREATE TABLE [Catalogos].[Proveedores] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]    VARCHAR (100) NOT NULL,
    [RFC]       VARCHAR (20)  NULL,
    [Direccion] VARCHAR (100) NULL,
    [Activo]    BIT           CONSTRAINT [DF_Proveedores_Activo] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED ([Id] ASC)
);





