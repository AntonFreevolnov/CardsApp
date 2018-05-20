using System;
namespace CardProject {

    class Game {

        static void Main() {


            Dealer Dealer = new Dealer();


            Gamers Gamers = new Gamers(); // создали группу игроков
            Gamers.Add(new Gamer("Anton"));
            Gamers.Add(new Gamer("Victor"));
            Gamers.Add(new Gamer("Ivan"));
            Gamers.Add(new Gamer("Denis"));
           // Gamers.Add(new Gamer("Vasily"));
           // Gamers.Add(new Gamer("Anna"));

            Dealer.HandOut(Gamers); // раздали карты

         //   Dealer.GetDeck().Print();

            foreach(Gamer Gamer in Gamers)
                Gamer.Print();

            Console.WriteLine(Gamers.GetBeginnerIndex());

        }
    }
}
