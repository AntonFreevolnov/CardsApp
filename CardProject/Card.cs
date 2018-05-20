using System;

namespace CardProject {

    enum CardName { six , seven, nine, eight, ten, jack, queen, king, ace };
    enum Suit { Spades = 1, Hearth, Diamonds, Clubs };


    class Card {

        public int _cardId { get; set; } // id карты
        public CardName _cardName { get; set; } // имя
        public Suit _suit { get; set; } // масть
        public int _rang { get; set; } // рейтинг
        public bool _isTramp { get; set; } // является ли козырем


        public void SetIsTramp()  {
            _isTramp = true;
            _rang += 27;
        }


        public Card() { } // по умолчанию




        public Card(int id, int name, int suit)  { // конструктор
            _cardId = id;
            _cardName = (CardName)name;
            _suit = (Suit)suit;
            _isTramp = false;
            _rang = name;
        }


        public override String ToString()  {
            return String.Format("{0, 2:N0} - {1, 6} - {2, 8} - {3, 2}", _cardId, _cardName, _suit, _rang);
        }

        public void Print()  {
            Console.WriteLine(ToString());
        }
    }
}
