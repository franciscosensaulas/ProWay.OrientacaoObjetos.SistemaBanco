-- Drop table apaga a tabela
DROP TABLE ContasPoupanca;

CREATE TABLE ContasPoupanca ( 
	codigo INT PRIMARY KEY IDENTITY,
	nome VARCHAR(100) NOT NULL,
	saldo DECIMAL(6, 2) NOT NULL
);
-- Cria um registro
INSERT INTO ContasPoupanca (nome, saldo)
VALUES ('Francisco', 11.49)

SELECT * FROM ContasPoupanca;
-- VARCHAR(100) campo de texto permite até 100 caracteres
-- DECIMAL número do tipo real
-- INT inteiro
-- IDENTITY para ser auto incrementado a coluna, ou seja, primeiro registro 1, 2, 3
-- PRIMARY KEY chave primária
-- NOT NULL não permite nulo