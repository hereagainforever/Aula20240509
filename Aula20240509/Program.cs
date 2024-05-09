using Aula20240509;

bool existe;
CCorrente conta = null;
double valor;
string? menu, submenu, numero;
List<CCorrente> contas = new List<CCorrente>();

do
{
    Console.WriteLine("\n----- Seleção de acesso -----");
    Console.WriteLine("\n1- Acesso Administrativo\n2- Caixa Eletrônico\n3- Sair\n");
    Console.WriteLine("Digite a opção desejada: ");
    menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            do
            {
                Console.WriteLine("\n--- Acesso Administrativo ---");
                Console.WriteLine("\n1- Cadastro de Conta Corrente\n2- Mostrar saldo das contas\n3- Excluir conta\n4- Retornar\n");
                Console.WriteLine("Digite a opção desejada: ");
                submenu = Console.ReadLine();
                switch (submenu)
                {
                    case "1":
                        existe = false;
                        Console.WriteLine("Digite o número da conta:");
                        numero = Console.ReadLine();
                        foreach (CCorrente c in contas)
                            if (c.numero == numero)
                                existe = true;
                        if (!existe)
                        {
                            Console.WriteLine("Digite o limite da conta: ");
                            Double.TryParse(Console.ReadLine(), out valor);
                            CCorrente contaNova = new CCorrente(numero, valor);
                            contas.Add(contaNova);
                            Console.WriteLine("Conta cadastrada!");
                        }
                        else
                            Console.WriteLine("Uma conta com esse número já existe");
                        break;

                    case "2":
                        if (contas.Count > 0)
                            foreach (CCorrente c in contas)
                                Console.WriteLine("Conta: " + c.numero + ", Saldo: " + c.saldo);
                        else
                            Console.WriteLine("Não existem contas disponíveis");
                        break;

                    case "3":
                        Console.WriteLine("Digite o número da conta que deseja excluir: ");
                        numero = Console.ReadLine();
                        conta = null;
                        foreach (CCorrente c in contas)
                            if (c.numero == numero)
                                conta = c;
                        if (conta != null)
                        {
                            conta.status = false;
                            contas.Remove(conta);
                            Console.WriteLine("Conta excluída");
                        }
                        else
                            Console.WriteLine("Conta não encontrada");
                        break;

                    case "4": break;

                    default:
                        Console.WriteLine("Opção inválida digitada. Tente novamente.");
                        break;
                }
            } while (submenu != "4");
            break;

        case "2":
            Console.WriteLine("\nDigite a conta corrente desejada:");
            numero = Console.ReadLine();
            conta = null;
            foreach (CCorrente c in contas)
                if (c.numero == numero)
                    conta = c;
            if (conta != null && conta.status)
            {
                do
                {
                    Console.WriteLine("-- Caixa Eletrônico --");
                    Console.WriteLine("\n1- Saque\n2- Depósito\n3- Transferência\n4- Retornar\n");
                    Console.WriteLine("Digite a opcao desejada:");
                    submenu = Console.ReadLine();
                    switch (submenu)
                    {
                        case "1":
                            Console.WriteLine("Digite o valor que deseja sacar:");
                            Double.TryParse(Console.ReadLine(), out valor);
                            if (conta.Sacar(valor))
                                Console.WriteLine("Saque realizado");
                            else
                                Console.WriteLine("Não foi possível realizar o saque");
                            break;

                        case "2":
                            Console.WriteLine("Digite o valor que deseja depositar:");
                            Double.TryParse(Console.ReadLine(), out valor);
                            if (conta.Depositar(valor))
                                Console.WriteLine("Depósito realizado");
                            else
                                Console.WriteLine("Não foi possível realizar o depósito");
                            break;

                        case "3":
                            Console.WriteLine("Digite o número da conta de destino:");
                            string? destino = Console.ReadLine();
                            CCorrente contaDestino = null;
                            foreach (CCorrente c in contas)
                                if (c.numero == destino)
                                    contaDestino = c;
                            if (contaDestino != null && contaDestino.status)
                            {
                                Console.WriteLine("Digite o valor a ser transferido");
                                Double.TryParse(Console.ReadLine(), out valor);
                                if (conta.Transferir(contaDestino, valor))
                                    Console.WriteLine("Transferência realizada");
                                else
                                    Console.WriteLine("Não foi possível realizar a transferência");
                            }
                            else
                                Console.WriteLine("Conta de destino não encontrada");
                            break;

                        case "4": break;

                        default:
                            Console.WriteLine("Opção inválida digitada. Tente novamente.");
                            break;
                    }
                } while (submenu != "4");
            }
            else
                Console.WriteLine("\nConta não encontrada");
            break;

        case "3":
            Console.WriteLine("Tenha um bom dia!");
            break;

        default:
            Console.WriteLine("Opção inválida digitada. Tente novamente.");
            break;
    }
} while (menu != "3");