CREATE TABLE [Catalogos].[Productos] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [Id_Modelo]            INT           CONSTRAINT [DF_Productos_Id_Modelo] DEFAULT ((1)) NOT NULL,
    [Id_Marca]             INT           CONSTRAINT [DF_Productos_Id_Marca] DEFAULT ((1)) NOT NULL,
    [Id_Familia]           INT           NOT NULL,
    [Id_Moneda]            INT           CONSTRAINT [DF_Productos_Id_Moneda] DEFAULT ((1)) NOT NULL,
    [Clave_Proveedor]      VARCHAR (50)  NULL,
    [Clave_Teknobike]      VARCHAR (50)  NOT NULL,
    [Sku]                  VARCHAR (50)  NOT NULL,
    [Nombre]               VARCHAR (100) NOT NULL,
    [Description]          VARCHAR (MAX) NULL,
    [Precio_Mayoreo]       DECIMAL (18)  NULL,
    [Precio_Medio_Mayoreo] DECIMAL (18)  NULL,
    [Precio_Publico]       DECIMAL (18)  NULL,
    [Costo]                DECIMAL (18)  NULL,
    [Piezas]               INT           CONSTRAINT [DF_Productos_Piezas] DEFAULT ((0)) NOT NULL,
    [Activo]               BIT           CONSTRAINT [DF_Productos_Is_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Productos_1_Familias_1] FOREIGN KEY ([Id_Familia]) REFERENCES [Catalogos].[Familias] ([Id]),
    CONSTRAINT [FK_Productos_Marcas] FOREIGN KEY ([Id_Marca]) REFERENCES [Catalogos].[Marcas] ([Id]),
    CONSTRAINT [FK_Productos_Modelos] FOREIGN KEY ([Id_Modelo]) REFERENCES [Catalogos].[Modelos] ([Id]),
    CONSTRAINT [FK_Productos_Monedas] FOREIGN KEY ([Id_Moneda]) REFERENCES [Catalogos].[Monedas] ([Id])
);





