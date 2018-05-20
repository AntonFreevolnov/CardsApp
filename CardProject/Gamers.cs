using System;

namespace CardProject {

    class Gamers : Container<Gamer>  { // группа игроков

        public int AssaulterIndex;  // индекс заходного
        public int DefendsIndex; // индекс отбивающегося

        public void Process()  {
            Console.WriteLine("Process");
        }

        public Gamers() : base() {
            AssaulterIndex = -1;
            DefendsIndex = -1;
        }

        private void SetDefendsIndex()  {
                if (AssaulterIndex == LastIndex)  
                    DefendsIndex = 0;
                else  
                    DefendsIndex = AssaulterIndex + 1;
        }

        public int GetBeginnerIndex() {
            int MinTramp = 35;
            int GamerIndex = 0;
            foreach (Gamer Gamer in Arr)  {
                foreach (Card Card in Gamer._hand)  {
                    if (Card._rang >= 27 && Card._rang < MinTramp)  {
                        MinTramp = Card._rang;
                        AssaulterIndex = GamerIndex;
                    }
                }
                GamerIndex++;
            }
            if (AssaulterIndex != -1) 
                SetDefendsIndex();
            return AssaulterIndex;
        }
    }
}