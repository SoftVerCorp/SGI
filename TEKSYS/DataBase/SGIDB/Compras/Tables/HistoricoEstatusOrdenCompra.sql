CREATE TABLE [Compras].[HistoricoEstatusOrdenCompra] (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [IdOrderBuy] INT  NOT NULL,
    [IdStatus]   INT  NOT NULL,
    [Date]       DATE CONSTRAINT [DF_HistoricoEstatusOrdenCompra_Date] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_HistoricoEstatusOrdenCompra] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderBuy_1_HistOrderBuy_1] FOREIGN KEY ([IdOrderBuy]) REFERENCES [Compras].[OrdenCompra] ([Id]),
    CONSTRAINT [FK_OrderBuyStatus_1_HistoOrderBuy_1] FOREIGN KEY ([IdStatus]) REFERENCES [Catalogos].[Estatus_Compra] ([Id])
);

