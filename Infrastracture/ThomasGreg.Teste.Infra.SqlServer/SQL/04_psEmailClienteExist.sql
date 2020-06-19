IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'psEmailClienteExist'
            AND type = 'P'
      )
      DROP PROCEDURE dbo.psEmailClienteExist
GO

CREATE PROCEDURE dbo.psEmailClienteExist
    @Email VARCHAR(300)
AS

    SELECT 1 FROM Clientes (NOLOCK) WHERE Email = @Email
GO