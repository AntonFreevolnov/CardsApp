using System;

namespace CardProject {

    class Dealer   { // дилер

        private const int CountCards = 36;  // количество карт в колоде
        private const int CardInHand = 6; // карт раздается на руки
        private Random rnd = new Random(); // объект Random
        public Cards Deck;

        // динамическое создание колоды карт
        private void InitDeck()  {
            Deck = new Cards();
            int id = 1, name = 1, suit = 1;
            for (; id <= CountCards; id++)  {
                if (suit > 4) {
                    suit = 1;
                    ++name;
                    if (name > 8) name = 0;
                }
                Deck.Add(new Card(id, name, suit));
                suit++;
            }
        }

        // вычисление "случайного" индекса в диапазоне
        private int Rand(int lower, int higher)    {
            return rnd.Next(lower, higher + 1);
        }

        // перетасовать колоду
        private void MixDeck()  {
            Cards newDeck = new Cards(); // выделили память под результат
            for (int i = CountCards - 1; i >= 0; i--)  {
                int index = Rand(0, i); // определили случайный индекс
                newDeck.Add(Deck[index]); // определили текущий элемент результирующего массива
                Deck.Remove(index); // удалили использованное значение original
            }
            Deck = newDeck; // переопределили Cards
        }

        // переопределить ранг для карт козырной масти при определении козыря
        private void InitTramp(Card trampCard) {
            foreach (Card c in Deck)  {
                if (c._suit == trampCard._suit)
                    c.SetIsTramp();
            }
        }

        // коструктор
        public Dealer()  {
            InitDeck(); // создать колоду
            MixDeck(); // перетасовать
        }

        // вернуть колоду
        public Cards GetDeck()  {
            return Deck;
        }

        private void HandOutAttempt(Gamers gamers)  {
            int tIndex = Deck.LastIndex - CardInHand * gamers.Count; // индекс вскрываемого козыря
            if (tIndex == -1) tIndex = 0; // если будут разданы все карты
            Card trampCard = Deck[tIndex]; // ссылка на вскрываемый козырь
            InitTramp(trampCard); // обновили ранг карт ставших козырными
            Deck.Swap(tIndex, 0); // "вскрытый" козырь в конец колоды
            foreach (Gamer gamer in gamers) // раздать игрокам по 6 карт
                gamer.AddCards(Deck, CardInHand);
        }

        public void HandOut(Gamers Gamers)  {
            do { // если нет козырей у игроков - пересдача
                HandOutAttempt(Gamers); 
            } while (Gamers.GetBeginnerIndex() == -1);
        }
    }
}
