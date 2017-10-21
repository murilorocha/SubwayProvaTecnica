CREATE TABLE [dbo].[Compras] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [ContaId]  INT            NOT NULL,
    [Produtos] VARCHAR (2000) NOT NULL,
    [Valor]    MONEY          NOT NULL,
    [Ativo]    BIT            CONSTRAINT [DF_Compras_Ativo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Compras_Conta] FOREIGN KEY ([ContaId]) REFERENCES [dbo].[Contas] ([ID])
);

