CREATE TABLE [dbo].[Contas] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [Nome]           VARCHAR (200) NOT NULL,
    [Email]          VARCHAR (100) NULL,
    [DataNascimento] DATE          NOT NULL,
    [Ativo]          BIT           CONSTRAINT [DF_Contas_Ativo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Contas] PRIMARY KEY CLUSTERED ([ID] ASC)
);

