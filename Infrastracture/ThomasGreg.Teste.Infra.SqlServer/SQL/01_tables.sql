IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE name='Clientes' and xtype='U') BEGIN
	CREATE TABLE Clientes(
		Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
		Nome VARCHAR(100) NOT NULL,
		Email VARCHAR(100) NOT NULL,
		Logotipo VARCHAR(2500) NOT NULL,
		CreatedAt DATETIME NOT NULL,
		UpdatedAt DATETIME NOT NULL
	);
END

IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE name='Logradouros' and xtype='U') BEGIN
	CREATE TABLE Logradouros(
		Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
		Nome VARCHAR(300),		
		CreatedAt DATETIME NOT NULL,
		UpdatedAt DATETIME NOT NULL
	);
END

IF EXISTS(SELECT 1 FROM sysobjects WHERE name='Logradouros' and xtype='U') BEGIN	
	ALTER TABLE Logradouros ADD ClienteId UNIQUEIDENTIFIER NOT NULL
	ALTER TABLE Logradouros	ADD FOREIGN KEY (ClienteId) REFERENCES Clientes (Id)
END

IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE name='Usuarios' and xtype='U') BEGIN
	CREATE TABLE Usuarios(
		Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
		Username VARCHAR(30),
		Password VARCHAR(30),
		CreatedAt DATETIME NOT NULL,
		UpdatedAt DATETIME NOT NULL
	);
END

IF EXISTS(SELECT 1 FROM sysobjects WHERE name='Usuarios' and xtype='U') BEGIN
	-- Pois é, por enquanto só temos admin
	ALTER TABLE Usuarios ADD Role VARCHAR(30) NOT NULL default 'admin'
END