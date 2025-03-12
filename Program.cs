using System;
using System.Collections.Generic;

namespace Oop
{
    class Program 
    {
        static void Main(string[] args)
        {
          Card user1 = new User1();
          Card user2 = new User2();
          Card user3 = new User3();
          Card user4 = new User4();

          try
          {
            user1.Transfer(user4, 100);
          }catch(NotEnoughMoneyException ex)
          {
              Console.WriteLine(ex.Message);
          }catch(CardTypeNotMatchExeption ex)
          {
              Console.WriteLine(ex.Message);
          }

        }  

    }
}