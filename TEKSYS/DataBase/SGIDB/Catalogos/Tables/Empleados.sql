CREATE TABLE [Catalogos].[Empleados] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]               VARCHAR (100)  NOT NULL,
    [FechaDeContratacion]  DATE           NULL,
    [PathImage]            VARCHAR (1024) NULL,
    [Email]                VARCHAR (60)   NULL,
    [EnviarNotificaciones] BIT            CONSTRAINT [DF_Empleados_EnviarNotificacion] DEFAULT ((0)) NOT NULL,
    [Activo]               BIT            CONSTRAINT [DF_Empleados_Active] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED ([Id] ASC)
);







