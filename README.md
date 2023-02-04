# Teste_Universidade_Dapper
Crud usando Dapper
Comandos SQL usados

```sql
USE Teste
GO

CREATE TABLE [Enderecos] (
	[Id] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[Ativo] BIT NOT NULL,
	[DataDeCriacao] DATETIME NOT NULL,
	[DataDeAlteracao] DATETIME NULL,
	[Rua] NVARCHAR(80) NOT NULL,
	[Cidade] NVARCHAR(80) NOT NULL,
	[Estado] NVARCHAR(80) NOT NULL,
	[Cep] NVARCHAR(80) NOT NULL,
	[Complemento] NVARCHAR(80) NULL
)
GO

CREATE TABLE [Departamentos] (
	[Id] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[Ativo] BIT NOT NULL,
	[DataDeCriacao] DATETIME NOT NULL,
	[DataDeAlteracao] DATETIME NULL,
	[Nome] NVARCHAR(80) NOT NULL,
	[EnderecoId] INT NOT NULL,
	CONSTRAINT FK_Departamentos_Enderecos_EnderecoId FOREIGN KEY (EnderecoId) REFERENCES Enderecos(Id) ON DELETE CASCADE
)
GO

CREATE TABLE [Cursos] (
	[Id] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[Ativo] BIT NOT NULL,
	[DataDeCriacao] DATETIME NOT NULL,
	[DataDeAlteracao] DATETIME NULL,
	[Nome] NVARCHAR(80) NOT NULL,
	[Turno] NVARCHAR(80) NOT NULL,
	[TipoCurso] NVARCHAR(80) NOT NULL,
	[DepartamentoId] INT NOT NULL,
	CONSTRAINT FK_Cursos_Departamentos_DepartamentoId FOREIGN KEY (DepartamentoId) REFERENCES Departamentos(Id) ON DELETE CASCADE
)
GO

ALTER TABLE [Enderecos] ALTER COLUMN [DataDeCriacao] DateTime2
GO

ALTER TABLE [Enderecos] ALTER COLUMN [DataDeAlteracao] DateTime2
GO

ALTER TABLE [Departamentos] ALTER COLUMN [DataDeCriacao] DateTime2
GO

ALTER TABLE [Departamentos] ALTER COLUMN [DataDeAlteracao] DateTime2
GO

ALTER TABLE [Cursos] ALTER COLUMN [DataDeCriacao] DateTime2
GO

ALTER TABLE [Cursos] ALTER COLUMN [DataDeAlteracao] DateTime2
GO
```
