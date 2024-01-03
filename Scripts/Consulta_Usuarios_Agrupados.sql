USE [UsuarioBD]
GO

--Comando Select que traz os usuários agrupados por faixa etária, cuja escolaridade seja igual a “Superior”. 

SELECT 
    CASE 
        WHEN DATEDIFF(YEAR, U.DataNascimento, GETDATE()) <= 20 THEN 'Até 20 anos'
        WHEN DATEDIFF(YEAR, U.DataNascimento, GETDATE()) BETWEEN 21 AND 50 THEN 'De 21 a 50 anos'
        ELSE 'Acima de 50 anos'
    END AS FaixaEtaria,
    E.Escolaridade,
    COUNT(*) AS Quantidade,
    STRING_AGG(CONCAT(U.Nome, ' - ', U.Email), '; ') AS Detalhes
FROM 
    Usuario U
JOIN 
    Escolaridade E ON U.IdEscolaridade = E.IdEscolaridade
WHERE 
	E.IdEscolaridade = 4
GROUP BY 
    CASE 
        WHEN DATEDIFF(YEAR, U.DataNascimento, GETDATE()) <= 20 THEN 'Até 20 anos'
        WHEN DATEDIFF(YEAR, U.DataNascimento, GETDATE()) BETWEEN 21 AND 50 THEN 'De 21 a 50 anos'
        ELSE 'Acima de 50 anos'
    END,
    E.Escolaridade
