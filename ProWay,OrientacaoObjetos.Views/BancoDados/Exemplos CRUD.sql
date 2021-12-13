INSERT INTO ContasPoupanca (nome, saldo)
VALUES ('Pedro', 2990.50)

SELECT * FROM ContasPoupanca

UPDATE ContasPoupanca 
	SET saldo = 3190.50
	WHERE codigo = 2

DELETE FROM ContasPoupanca WHERE codigo = 2
