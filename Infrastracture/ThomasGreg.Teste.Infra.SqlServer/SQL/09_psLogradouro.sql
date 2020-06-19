IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'psLogradouro'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.psLogradouro
GO

CREATE PROCEDURE dbo.psLogradouro
    @Id UNIQUEIDENTIFIER
AS

    SELECT * FROM Logradouros WHERE Id = @Id
GO