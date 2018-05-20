using System;
using System.Collections;


namespace CardProject {

    // контейнер под элементы пользовательского типа
    class Container<T> : IEnumerable {

        public int Count { get; set; }
        public int LastIndex { get { return Count - 1; } }
        public T[] Arr { get; set; }

        // конструктор по умолчанию
        public Container()  {
            Count = 0;
            Arr = null;
        }

        // добавление в коллекцию элемента
        public void Add(T el)  {
            T[] Temp = new T[Count + 1];  // выделили память под массив размерностью больше на 1
            for (int i = 0; i < Count; i++) // 
                Temp[i] = Arr[i]; // скопировали элементы
            Temp[Count++] = el; // поместили новый элемент
            Arr = Temp; // переопределили Arr
        }

        // удаление элемента из коллекции
        public void Remove(int index)  {
            if (Count == 0) return; // если пустой массив
            T[] Temp = new T[Count - 1]; // выделили память размерностью меньше на элемент 
            for (int i = 0, j = 0; i < Count; i++)  {
                if (index == i) continue; // если удаляемый элемент пропускаем
                Temp[j++] = Arr[i]; // копируем в Temp
            }
            Arr = Temp; // переопределяем ссылку Arr
            Count--; // переопределяем count
        }

        //индексатор
        public T this[int i]  {
            get  {
                int index = 0;
                if (i >= 0 && i < Count) index = i;
                return Arr[index];
            }
            set   { 
                if (i >= 0 && i <= Count) Arr[i] = value; 
            }
        }

        public IEnumerator GetEnumerator()  { // реализация интерфейса
            foreach (T el in Arr)
                yield return el;
        }

        // вытолкнуть последний элемент
        public T Pop()  {
            T el = Arr[LastIndex];
            Remove(LastIndex);
            return el;
        }

        // получить ссылку на последний элемент
        public T LastEl()  {
            return Arr[LastIndex];
        }

        // вернуть первый элемент контейнера без удаления
        public T FirstEl()  {
            return Arr[0];
        }

        // обмен местами элементов контейнера 
        public void Swap(int index1, int index2) {
            if (index1 == index2) return;
            Console.WriteLine(index1 + "   " + index2);
            T c;
            c = Arr[index1];
            Arr[index1] = Arr[index2];
            Arr[index2] = c;
        }

        // вывод на консоль
        public virtual void Print() {
            Console.WriteLine(" котейтенер объектов типа " + typeof(T) + " Count = " + Count);
        }
    }
}
