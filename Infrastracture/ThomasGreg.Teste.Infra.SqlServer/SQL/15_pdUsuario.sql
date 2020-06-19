IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'pdUsuario'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.pdUsuario
GO

CREATE PROCEDURE dbo.pdUsuario
    @Guid UNIQUEIDENTIFIER
AS

    DELETE FROM Usuarios WHERE Id = @Guid
GO