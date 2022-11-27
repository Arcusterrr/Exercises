Account acc = new Account(1000);
acc.RegisterHandler(PrintMessage);
acc.RegisterHandler(ColorPrintMessage);

acc.Take(800);
acc.Take(800);

acc.UnregisterHandler(ColorPrintMessage);
acc.Take(100);



void PrintMessage(string message) => Console.WriteLine(message);

void ColorPrintMessage(string message)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(message);
    Console.ResetColor();
}

public delegate void AccountHandler(string message);

public class Account
{
    public int sum { get; set; }
    public AccountHandler? taken;
    
    public Account(int sum) => this.sum = sum;

    public void RegisterHandler(AccountHandler del)
    {
        this.taken += del;
    }

    public void UnregisterHandler(AccountHandler del)
    {
        this.taken -= del;
    }
    

    public void Add(int sum) => this.sum += sum;

    public void Take(int sum)
    {
        if (this.sum >= sum)
        {
            this.sum -= sum;
            taken?.Invoke($"Со счета списано: {sum} р. Остаток: {this.sum}");
        }
        else
        {
            taken?.Invoke($"На счете недостаточно средств. Баланс: {this.sum} р.");
        }
    }

}