class CardTypeNotMatchExeption : Exception
{
    public CardTypeNotMatchExeption(string message) : base(message)
    {
    }
    
}

class NotEnoughMoneyException : Exception
{
    public NotEnoughMoneyException(string message) : base(message)
    {
    }
    
}