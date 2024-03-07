USE [master]
GO

CREATE DATABASE [TarefaBD]
GO

USE [TarefaBD]
GO


CREATE TABLE [Tarefa]
(
    [IdTarefa] INT PRIMARY KEY IDENTITY(1,1),
    [Nome] NVARCHAR(40) NOT NULL,
    [Descricao] NVARCHAR(200) NOT NULL,
    [Responsavel] NVARCHAR(20) NOT NULL,
    [DataInicio] DATETIME NOT NULL,
	[DataConclusao] DATETIME NOT NULL,
	[Situacao] INT NOT NULL
)
GO

