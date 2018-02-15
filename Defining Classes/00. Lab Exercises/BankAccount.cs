
public class BankAccount
{
    private int id;
    private decimal balance;

    public int ID
    {
        get => this.id;
        set { this.id = value; }
    }

    public decimal Balance
    {
        get => this.balance;
        set { this.balance = value; }
    }

    public void Deposit(decimal amount)
    {
        this.Balance = +amount;
    }

    public void Withdraw(decimal amount)
    {
            this.Balance -= amount;
            }

    public override string ToString()
    {
        return $"Account ID{this.ID}, balance {this.Balance:f2}";
    }
}
