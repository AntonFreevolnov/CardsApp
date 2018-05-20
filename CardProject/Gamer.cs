using System;

namespace CardProject {

    class Gamer  {

        public string _name { get; set; } // имя игрока
        public Cards _hand { get; set; } // карты на руках игрока
        public bool _inGame { get; set; } // в игре игрок или нет

        // коснтруктор
        public Gamer(string name) {
            _hand = new Cards();
            _name = name;
            _inGame = false;
        }

        public void PrintCards() {
            _hand.Print();
        }

        // вывод на консоль данных игрока
        public void Print()  {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("|{0,-31}|", _name);
            Console.WriteLine("--------------------------------");
            PrintCards();
            Console.WriteLine("--------------------------------");
        }

        // добавление карты игроку
        public void AddCard(Cards crds)  {
            _hand.Add(crds.Pop());
        }

        // добавление массива карт игроку
        public void AddCards(Cards crds, int n) {
            for (int i = 0; i < n; i++)
                _hand.Add(crds.Pop());
        }
    }

}


