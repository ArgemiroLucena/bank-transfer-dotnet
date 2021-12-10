using bank_transfer_dotnet;
class Program
{
    static List<Account> accountList = new List<Account>();
    static void Main(string[] args)
    {
        string userOption = GetUserOption();

        while (userOption.ToUpper() != "X")
        {
            switch (userOption)
            {
                case "1":
                    ListAccount();
                    break;
                case "2":
                    InsertAccount();
                    break;
                case "3":
                    TransferFounds();
                    break;
                case "4":
                    WithdrawFounds();
                    break;
                case "5":
                    DepositFounds();
                    break;
                case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            userOption = GetUserOption();
        }

        Console.WriteLine("Obrigado por utilizar nossos serviços.");
        Console.ReadLine();
    }

    private static void DepositFounds()
    {
        Console.Write("Digite o número da conta: ");
        int accountIndex = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser depositado: ");
        double depositValue = double.Parse(Console.ReadLine());

        accountList[accountIndex].DepositFounds(depositValue);
    }

    private static void WithdrawFounds()
    {
        Console.Write("Digite o número da conta: ");
        int accountIndex = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser sacado: ");
        double withdrawValue = double.Parse(Console.ReadLine());

        accountList[accountIndex].WithdrawFounds(withdrawValue);
    }

    private static void TransferFounds()
    {
        Console.Write("Digite o número da conta de origem: ");
        int accountSourceIndex = int.Parse(Console.ReadLine());

        Console.Write("Digite o número da conta de destino: ");
        int accountTargetIndex = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser transferido: ");
        double transferValue = double.Parse(Console.ReadLine());

        accountList[accountSourceIndex].TransferFounds(transferValue, accountList[accountTargetIndex]);
    }

    private static void InsertAccount()
    {
        Console.WriteLine("Inserir nova conta");

        Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
        int accountTypeEntry = int.Parse(Console.ReadLine());

        Console.Write("Digite o Nome do Cliente: ");
        string nameEntry = Console.ReadLine();

        Console.Write("Digite o saldo inicial: ");
        double balanceEntry = double.Parse(Console.ReadLine());

        Console.Write("Digite o crédito: ");
        double creditEntry = double.Parse(Console.ReadLine());

        Account newAccount = new Account(accountType: (AccountType)accountTypeEntry,
                                    balance: balanceEntry,
                                    credit: creditEntry,
                                    name: nameEntry);

        accountList.Add(newAccount);
    }

    private static void ListAccount()
    {
        Console.WriteLine("Listar contas");

        if (accountList.Count == 0)
        {
            Console.WriteLine("Nenhuma conta cadastrada.");
            return;
        }

        for (int i = 0; i < accountList.Count; i++)
        {
            Account account = accountList[i];
            Console.Write("#{0} - ", i);
            Console.WriteLine(account);
        }
    }

    private static string GetUserOption()
    {
        Console.WriteLine();
        Console.WriteLine("Bem vindo ao MirousBank");
        Console.WriteLine("Informe a opção desejada:");

        Console.WriteLine("1- Listar contas");
        Console.WriteLine("2- Inserir nova conta");
        Console.WriteLine("3- Transferir");
        Console.WriteLine("4- Sacar");
        Console.WriteLine("5- Depositar");
        Console.WriteLine("C- Limpar Tela");
        Console.WriteLine("X- Sair");
        Console.WriteLine();

        string userOption = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return userOption;
    }
}

