CREATE TABLE [Compras].[DetalleOrdenCompra] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [IdProducto]    INT          NOT NULL,
    [IdMarca]       INT          NOT NULL,
    [IdOrdenCompra] INT          NOT NULL,
    [IdProveedor]   INT          NOT NULL,
    [Costo]         DECIMAL (18) CONSTRAINT [DF_DetalleOrdenCompra_Costo] DEFAULT ((0)) NOT NULL,
    [Piezas]        INT          NOT NULL,
    [Precio]        DECIMAL (18) NOT NULL,
    CONSTRAINT [PK_DetalleOrdenCompra] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DetOrdCom_Marca] FOREIGN KEY ([IdMarca]) REFERENCES [Catalogos].[Marcas] ([Id]),
    CONSTRAINT [FK_DetOrdCom_OrdenCompra] FOREIGN KEY ([IdOrdenCompra]) REFERENCES [Compras].[OrdenCompra] ([Id]),
    CONSTRAINT [FK_DetOrdCom_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [Catalogos].[Productos] ([Id]),
    CONSTRAINT [FK_DetOrderComp_Proveedor] FOREIGN KEY ([IdProveedor]) REFERENCES [Catalogos].[Proveedores] ([Id])
);





