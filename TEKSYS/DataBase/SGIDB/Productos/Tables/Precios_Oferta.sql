CREATE TABLE [Productos].[Precios_Oferta] (
    [Id]                      INT          IDENTITY (1, 1) NOT NULL,
    [Id_Producto]             INT          NOT NULL,
    [Id_Producto_Tipo_Oferta] INT          NOT NULL,
    [Precio]                  DECIMAL (18) NOT NULL,
    [fecha_Inicio]            DATE         NULL,
    [Fecha_Final]             DATE         NULL,
    [Is_Active]               BIT          CONSTRAINT [DF_Precios_Oferta_Is_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Precios_Oferta] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Productos_1_Precios_ofertas_1] FOREIGN KEY ([Id_Producto]) REFERENCES [Catalogos].[Productos] ([Id]),
    CONSTRAINT [FK_Tipo_Oferta_1_Prod_Tipo_oferta_1] FOREIGN KEY ([Id_Producto_Tipo_Oferta]) REFERENCES [Productos].[Tipo_Oferta] ([Id])
);



