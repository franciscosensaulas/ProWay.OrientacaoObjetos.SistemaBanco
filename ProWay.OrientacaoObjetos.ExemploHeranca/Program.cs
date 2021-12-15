using ProWay.OrientacaoObjetos.Models.ContaBancaria;

ContaPoupanca contaPoupanca = new ContaPoupanca("Pedro", 2000);
Console.WriteLine($"Saldo Pedro: {contaPoupanca.Saldo}");

contaPoupanca.Sacar(100);
Console.WriteLine($"Saldo Pedro: {contaPoupanca.Saldo}");
contaPoupanca.Sacar(150);
Console.WriteLine($"Saldo Pedro: {contaPoupanca.Saldo}");
Console.WriteLine(contaPoupanca.ToString());

ContaCorrente contaCorrente = new ContaCorrente(2000);
Console.WriteLine($"Saldo Conta Corrente: {contaCorrente.Saldo}");

contaCorrente.Sacar(100);
Console.WriteLine($"Saldo Conta Corrente: {contaCorrente.Saldo}");
contaCorrente.Sacar(150);
Console.WriteLine($"Saldo Conta Corrente: {contaCorrente.Saldo}");
Console.WriteLine(contaCorrente.ToString());

contaCorrente.Depositar(100002);

try
{
    contaCorrente.Sacar(2000);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{

}