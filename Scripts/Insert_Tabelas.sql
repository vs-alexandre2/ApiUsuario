USE [UsuarioBD]
GO

--Insert na tabela de Escolaridade
INSERT INTO [Escolaridade] VALUES('Infantil')
INSERT INTO [Escolaridade] VALUES('Fundamental')
INSERT INTO [Escolaridade] VALUES('Médio')
INSERT INTO [Escolaridade] VALUES('Superior')

--Insert na tabela de Usuários
INSERT INTO [Usuario] VALUES ('José', 'da Silva', 'jose_dasilva@email.com', GETDATE(), 1)
INSERT INTO [Usuario] VALUES ('Pedro', 'Oliveira', 'pedro_oliveira@email.com', GETDATE(), 2)
INSERT INTO [Usuario] VALUES ('Maria', 'Ferreira', 'maria_ferreira@email.com', GETDATE(), 3)
INSERT INTO [Usuario] VALUES ('Ana', 'Gouveia', 'ana_gouveia@email.com', GETDATE(), 4)