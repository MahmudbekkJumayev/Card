using System.Globalization;
class Card
{
    public int Id { get; set; }
    public string Owner { get; set; }
    public double Balance { get; set; }
    public CardType CardType { get; set; }

    public Card(int id = 0, string owner = "Alisher", double balance = 100, CardType cardType = CardType.UZCARD)
    {
        Id = id;
        Owner = owner;
        Balance = balance;
        CardType = cardType;
    }

    public void Transfer(Card recaiver , double amount)
    {
        if(!isSameCurrency(recaiver))
        {
            throw new CardTypeNotMatchExeption("Card type is not match");
        }
        else if(Balance < amount)
        {
            throw new NotEnoughMoneyException("Not enough money");
        }
        else
        {
            Balance -= amount;
            recaiver.Balance += amount;
            System.Console.WriteLine($"Transfered successful {amount} from {Owner} to {recaiver.Owner}");
        }
    }

    private bool isSameCurrency(Card recaiver)
    {
        bool isSanderUzOrHumo = CardType == CardType.UZCARD || CardType == CardType.HUMO;
        bool isRecaiverUzOrHumo = recaiver.CardType == CardType.UZCARD || recaiver.CardType == CardType.HUMO;
        bool isSanderVisaOrUnion = CardType == CardType.VISA || CardType == CardType.UNIONPAY;
        bool isRecaiverVisaOrUnion = recaiver.CardType == CardType.VISA || recaiver.CardType == CardType.UNIONPAY;
        return (isSanderUzOrHumo && isRecaiverUzOrHumo) || (isSanderVisaOrUnion && isRecaiverVisaOrUnion);
    }

    public void Display()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Owner: {Owner}");
        Console.WriteLine($"Balance: {Balance}");
        Console.WriteLine($"CardType: {CardType}");
    }

}

enum CardType
{
    UZCARD,
    HUMO,
    VISA,
    UNIONPAY
}

class User1 : Card
{
   public User1(string owner = "Alisher",int id = 123, double balance = 100, CardType cardType = CardType.UZCARD)
   {
       Owner = owner;
       Id = id;
       Balance = balance;
       CardType = cardType;
   }
}

class User2 : Card
{
    public User2(string owner = "Javohir",int id = 124,  double balance = 200, CardType cardType = CardType.HUMO)
    {
        Id = id;
        Owner = owner;
        Balance = balance;
        CardType = cardType;
    }
}

class User3 : Card
{
    public User3(string owner = "Shoxrux", int id = 125, double balance = 300, CardType cardType = CardType.VISA)
    {
        Id = id;
        Owner = owner;
        Balance = balance;
        CardType = cardType;
    }
}

class User4 : Card
{
    public User4(string owner = "Shahzod", int id = 126 , double balance = 400, CardType cardType = CardType.UNIONPAY)
    {
        Id = id;
        Owner = owner;
        Balance = balance;
        CardType = cardType;
    }
}