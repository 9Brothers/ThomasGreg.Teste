IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'pdLogradouro'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.pdLogradouro
GO

CREATE PROCEDURE dbo.pdLogradouro
    @Guid UNIQUEIDENTIFIER
AS

    DELETE FROM Logradouros WHERE Id = @Guid
GO