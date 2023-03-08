-- cria o banco de dados
CREATE DATABASE TesteSegurancaBET12FST13;

--colocar o banco de dados em uso
USE TesteSegurancaBET12FST13;

-- realizar a criação de tabela no Banco de Dados

CREATE TABLE Usuarios
(
	Id INT PRIMARY KEY IDENTITY,
	Email VARCHAR(100) UNIQUE NOT NULL,
	Senha VARCHAR(50) NOT NULL
);

-- inserir dados no banco de dados
INSERT INTO Usuarios VALUES ('email@email.com', 1234);

-- consultar os usuarios existentes no banco de dados
SELECT * FROM Usuarios;

-- hasheando campos do banco de dados
SELECT Email, Senha FROM Usuarios;

SELECT Email, HASHBYTES('MD2',Senha) FROM Usuarios;
SELECT Id, Email, HASHBYTES('MD2',Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;
SELECT Id, Email, HASHBYTES('MD4',Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;
SELECT Id, Email, HASHBYTES('MD5',Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;
SELECT Id, Email, HASHBYTES('SHA',Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;
SELECT Id, Email, HASHBYTES('SHA1',Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;
SELECT Id, Email, HASHBYTES('SHA2_256',Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;
SELECT Id, Email, HASHBYTES('SHA2_512',Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;











