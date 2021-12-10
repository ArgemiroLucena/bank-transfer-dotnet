namespace bank_transfer_dotnet
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }
        
        public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }
        
        public bool WithdrawFounds(double withdrawValue)
        {
            //Validação de saldo suficiente
            if (this.Balance - withdrawValue < (this.Credit *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Balance -= withdrawValue;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);
            return true;
        }
        
        public void DepositFounds(double depositValue)
        {
            this.Balance += depositValue;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);
        }

        public void TransferFounds(double transferValue, Account accountTarget)
        {
            if (this.WithdrawFounds(transferValue)){
                accountTarget.DepositFounds(transferValue);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.AccountType + " | ";
            retorno += "Nome " + this.Name + " | ";
            retorno += "Saldo " + this.Balance + " | ";
            retorno += "Crédito " + this.Credit;
            return retorno;
        }
    }
}