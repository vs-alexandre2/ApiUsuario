USE [master]
GO

CREATE DATABASE [UsuarioBD]
GO

USE [UsuarioBD]
GO



CREATE TABLE [Escolaridade]
(
    [IdEscolaridade] INT PRIMARY KEY IDENTITY(1,1),
    [Escolaridade] NVARCHAR(40) NOT NULL
)
GO


CREATE TABLE [HistoricoEscolar]
(
    [IdHistoricoEscolar] INT PRIMARY KEY IDENTITY(1,1),
    [Formato] NVARCHAR(4) NOT NULL,
	[Texto] NVARCHAR(200) NOT NULL
)
GO


CREATE TABLE [Usuario]
(
    [IdUsuario] INT PRIMARY KEY IDENTITY(1,1),
    [Nome] NVARCHAR(20) NOT NULL,
    [Sobrenome] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL,
    [DataNascimento] DATETIME NOT NULL,	
	[IdEscolaridade] INT NOT NULL
)
GO


CREATE TABLE [UsuarioHistoricoEscolar]
(
    [IdUsuarioHistoricoEscolar] INT PRIMARY KEY IDENTITY(1,1),
    [IdUsuario] INT NOT NULL,
	[IdHistoricoEscolar] INT NOT NULL
)
GO
