using System;

namespace CardProject {

    class Cards : Container<Card> { // коллекция карт

        public Cards() : base() { } // конструктор

        public override void Print()  { // вывод коллекции на консоль
            int i = 0; // индексатор списка
            foreach (Card c in Arr)
                Console.WriteLine("|{0, 2}| {1}|", ++i, c.ToString());
            Console.WriteLine();
        }
    }
}
