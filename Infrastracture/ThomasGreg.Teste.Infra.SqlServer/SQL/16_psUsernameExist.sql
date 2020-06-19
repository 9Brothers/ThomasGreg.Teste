IF EXISTS (
        SELECT 1
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'psUsernameExist'
            AND type = 'P'
      )
      DROP PROCEDURE psUsernameExist
GO

CREATE PROCEDURE psUsernameExist
    @Username VARCHAR(30)    
AS

    SELECT 1 FROM Usuarios (NOLOCK) WHERE Username = @Username
GO