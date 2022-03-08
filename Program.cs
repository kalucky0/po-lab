using System;

namespace po_lab
{
    public class Program {
        public static void Main(string[] args) {
            PersonProperties person = new PersonProperties();
            person.FirstName = "Jan";
            Console.WriteLine(person.FirstName);

            Money money = Money.Of(100, Currency.PLN)!;
            Money money2 = Money.Of(100, Currency.PLN)!;

            Console.WriteLine(money == money2);
            Console.WriteLine(money + money2);
            Console.WriteLine(money - money2);
            Console.WriteLine(money * 2);
            Console.WriteLine(2 * money);
            Console.WriteLine(money / 2);
            Console.WriteLine(2 / money);
        }
    }
}