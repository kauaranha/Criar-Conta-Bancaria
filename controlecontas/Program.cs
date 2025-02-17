using System;

namespace controleContas
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Conta conta1 = new Conta(123456);
                Conta conta2 = new Conta(654321);
                Cliente cliente1 = new Cliente("Humberto", 2000, "12345678910");

                conta1.Titular = cliente1;
                conta2.Titular = cliente1;

                int opc = 0;
                while (opc != 5)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("|1 - Cadastrar Conta/Cliente           |");
                    Console.WriteLine("|2 - Depositar Valores                 |");
                    Console.WriteLine("|3 - Sacar Valores                     |");
                    Console.WriteLine("|4 - Transferir entre Contas           |");
                    Console.WriteLine("|5 - Sair                              |");
                    Console.Write("Escolha uma Opção de <1 - 5>: ");
                    opc = Convert.ToInt32(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            Console.Write("Digite o nome do cliente: ");
                            string nome = Console.ReadLine();
                            Console.Write("Digite o ano de nascimento: ");
                            int anoNascimento = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite o CPF: ");
                            string cpf = Console.ReadLine();

                            cliente1 = new Cliente(nome, anoNascimento, cpf);
                            conta1.Titular = cliente1;
                            conta2.Titular = cliente1;
                            Console.WriteLine("Cliente cadastrado com sucesso!!");
                            break;

                        case 2:
                            Console.Write("Escolha a conta para depositar (1 ou 2): ");
                            int contaDeposito = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite o valor a depositar: ");
                            decimal valorDeposito = Convert.ToDecimal(Console.ReadLine());

                            if (contaDeposito == 1)
                            {
                                conta1.Depositar(valorDeposito);
                                Console.WriteLine("Saldo da conta 1: {0}", conta1.Saldo);
                            }
                            else if (contaDeposito == 2)
                            {
                                conta2.Depositar(valorDeposito);
                                Console.WriteLine("Saldo da conta 2: {0}", conta2.Saldo);
                            }
                            else
                            {
                                Console.WriteLine("Conta inválida, tente novamente!");
                            }
                            break;

                        case 3:
                            Console.Write("Escolha a conta para sacar (1 ou 2): ");
                            int contaSaque = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite o valor a sacar: ");
                            decimal valorSaque = Convert.ToDecimal(Console.ReadLine());

                            if (contaSaque == 1)
                            {
                                conta1.Sacar(valorSaque);
                                Console.WriteLine("Saldo da conta 1: {0}", conta1.Saldo);
                            }
                            else if (contaSaque == 2)
                            {
                                conta2.Sacar(valorSaque);
                                Console.WriteLine("Saldo da conta 2: {0}", conta2.Saldo);
                            }
                            else
                            {
                                Console.WriteLine("Conta inválida, tente novamente!");
                            }
                            break;

                        case 4:
                            Console.Write("Escolha a conta de origem (1 ou 2): ");
                            int contaOrigem = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Escolha a conta de destino (1 ou 2): ");
                            int contaDestino = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite o valor a transferir: ");
                            decimal valorTransferencia = Convert.ToDecimal(Console.ReadLine());

                            if (contaOrigem == 1 && contaDestino == 2)
                            {
                                conta1.Transferir(conta2, valorTransferencia);
                            }
                            else if (contaOrigem == 2 && contaDestino == 1)
                            {
                                conta2.Transferir(conta1, valorTransferencia);
                            }
                            else
                            {
                                Console.WriteLine("Operação de transferência inválida.");
                            }

                            Console.WriteLine("Saldo da conta 1: {0}", conta1.Saldo);
                            Console.WriteLine("Saldo da conta 2: {0}", conta2.Saldo);
                            break;

                        case 5:
                            Console.WriteLine("Saindo do programa...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida. Escolha entre 1 e 5.");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}
