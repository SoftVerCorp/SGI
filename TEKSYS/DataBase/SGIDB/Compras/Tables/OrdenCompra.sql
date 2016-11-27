CREATE TABLE [Compras].[OrdenCompra] (
    [Id]                  INT          IDENTITY (1, 1) NOT NULL,
    [IdProveedor]         INT          NOT NULL,
    [IdEmpleadoComprador] INT          NOT NULL,
    [IdEmpleadoValidador] INT          NOT NULL,
    [IdCondicionPago]     INT          NOT NULL,
    [OrdenCompra]         VARCHAR (30) NOT NULL,
    [FechaColocacion]     DATE         NULL,
    [FechaValidacion]     DATE         NULL,
    [IdStatus]            INT          NOT NULL,
    [Activo]              BIT          CONSTRAINT [DF_OrdenCompra_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_OrdenCompra] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CostoCom_1_ConPago_1] FOREIGN KEY ([IdCondicionPago]) REFERENCES [Catalogos].[Condicion_Pago] ([Id]),
    CONSTRAINT [FK_CostoCom_1_EmpComp_1] FOREIGN KEY ([IdEmpleadoComprador]) REFERENCES [Catalogos].[Empleados] ([Id]),
    CONSTRAINT [FK_CostoCom_1_EmpVal_1] FOREIGN KEY ([IdEmpleadoValidador]) REFERENCES [Catalogos].[Empleados] ([Id]),
    CONSTRAINT [FK_CostoCom_1_EstatusComp_1] FOREIGN KEY ([IdStatus]) REFERENCES [Catalogos].[Estatus_Compra] ([Id]),
    CONSTRAINT [FK_CostoCom_1_Prov_1] FOREIGN KEY ([IdProveedor]) REFERENCES [Catalogos].[Proveedores] ([Id])
);

