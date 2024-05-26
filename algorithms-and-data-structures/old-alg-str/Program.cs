using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            { //Быстрая и Qsort метод Сложность O(n log n)
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                List<int> list = new List<int>();
                RandomList(list, 10, 11);
                PrintList(list);
                StartQsort(list);
                PrintList(list);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }
            { //Слиянием и Merge метод Сложность O(n log n)
                List<int> list = new List<int>();
                RandomList(list, 10, 11);
                PrintList(list);
                list = MergeSort(list);
                PrintList(list);
            }
            { //Подсчетом Сложность Лучшая:O(n) Худшая:O(n + k)
                List<int> list = new List<int>();
                RandomList(list, 10, 11);
                PrintList(list);
                CountSort(list, 10, 11);
                PrintList(list);
            }
            { //Порязрядная и метод breake Сложность: O(n + k)        
                List<int> list = new List<int>();
                RandomList(list, 10, 11);
                PrintList(list);
                RadixSort(list, 2);
                PrintList(list);
            }
            {//Гномья Сложность: O(n^2)
                List<int> list = new List<int>();
                RandomList(list, 10, 11);
                PrintList(list);
                GnomeSort(list);
                PrintList(list);
            }
            {
                List<List<int>> data = new List<List<int>>();
                //Матрица смежности ориентированного графа
                                                // a  b  c  d  e  f  g  h
                data.Add(new List<int>(new int[] { 0, 1, 1, 0, 0, 0, 0, 0 }));//a
                data.Add(new List<int>(new int[] { 0, 0, 0, 1, 1, 0, 0, 0 }));//b
                data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 1, 1, 0 }));//c
                data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }));//d
                data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 1 }));//e
                data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }));//f
                data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }));//g
                data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }));//h

                List<int> obhod = new List<int>();
                Console.WriteLine("Обход в глубину");
                InDeep(data, data[0], obhod);
                PrintList(obhod);
                obhod.Clear();
                Console.WriteLine("Обход в ширину");
                InSize(data, data[0], obhod);
                PrintList(obhod);
            }
            {
                //бинарное дерево
                BinaryTree binaryTree = new BinaryTree(8);
                binaryTree.add(3);
                binaryTree.add(1);
                binaryTree.add(6);
                binaryTree.add(7);
                binaryTree.add(4);
                binaryTree.add(10);
                binaryTree.add(14);
                binaryTree.add(13);
                //bynaryTree.Remove(8);

                binaryTree.DisplayTree();
                Console.WriteLine();
                Console.WriteLine(binaryTree.Find(binaryTree.start, 8));
                Console.WriteLine(binaryTree.Find(binaryTree.start, 3));
                Console.WriteLine(binaryTree.Find(binaryTree.start, 1));
                Console.WriteLine(binaryTree.Find(binaryTree.start, 6));
                Console.WriteLine(binaryTree.Find(binaryTree.start, 7));
                Console.WriteLine(binaryTree.Find(binaryTree.start, 4));
                Console.WriteLine(binaryTree.Find(binaryTree.start, 10));
                Console.WriteLine(binaryTree.Find(binaryTree.start, 14));
                Console.WriteLine(binaryTree.Find(binaryTree.start, 13));
                Console.WriteLine(binaryTree.Find(binaryTree.start, 20));

            }
            {
                // Элементы массива для создания
                // круговой двусвязный список
                int[] arr = { 1, 2, 3, 4, 5, 6 };
                int n = arr.Length;

                DoubleList doubleList = new DoubleList(arr, n);
                doubleList.displayList();
                doubleList.add(199);
                doubleList.displayList();
                doubleList.add(299);
                doubleList.displayList();
                doubleList.add(399);
                doubleList.displayList();
                doubleList.add(499);
                doubleList.displayList();
            }
        }

        /// <summary>
        /// Обход в глубину 
        /// </summary>
        /// <param name="data">матрица смежности</param>
        /// <param name="elem">Вершина по которой нужно пройти</param>
        /// <param name="obhod">вершины которые мы обошли</param>
        static void InDeep(List<List<int>> data, List<int> elem, List<int> obhod)
        {
            //добавляем в пройденные вершины
            obhod.Add(data.IndexOf(elem));
            //проходим по соседним элементам данной вершины 
            for (int i = 0; i < elem.Count; i++)
            {
                if (elem[i] == 1)
                {
                    if (!obhod.Contains(data.IndexOf(data[i])))
                    {
                        Console.WriteLine("Входим в {0}", i);
                        //Рекурсивно вызывает что бы пройти вглубь (до конца)
                        InDeep(data, data[i], obhod);
                        Console.WriteLine("Выходим из {0}", i);
                    }
                }
            }
        }
        /// <summary>
        /// Проход в ширину
        /// </summary>
        /// <param name="data">матрица смежности</param>
        /// <param name="elem"></param>
        /// <param name="obhod"></param>
        static void InSize(List<List<int>> data, List<int> elem, List<int> obhod)
        {
            // создаем очередь
            Queue<List<int>> queue = new Queue<List<int>>();
            obhod.Add(data.IndexOf(elem));
            queue.Enqueue(elem);
            // добовляем в нее смежные елементы, проходим по ним и добовляем смежные со смнежными и тд.
            while (queue.Count > 0)
            {
                List<int> temp = queue.Dequeue();
                Console.WriteLine("Входим в {0}", data.IndexOf(temp));
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i] == 1)
                    {
                        if (!obhod.Contains(i))
                        {
                            obhod.Add(i);
                            queue.Enqueue(data[i]);
                        }
                    }
                }
                Console.WriteLine("Выходим из {0}", data.IndexOf(temp));
            }
        }
        /// <summary>
        /// Рандомизация спика
        /// </summary>
        /// <param name="list">Передаем список</param>
        /// <param name="count">Количество элементов</param>
        /// <param name="maxNumber">Максимальное для рандома</param>
        static void RandomList(List<int> list, int count, int maxNumber)
        {
            Random random = new Random(123);
            for (int i = 0; i < count; i++)
            {
                list.Add(random.Next(maxNumber));
            }
        }
        /// <summary>
        /// Печать списка
        /// </summary>
        /// <param name="list">Список для печати</param>
        static void PrintList(List<int> list)
        {
            foreach (int i in list)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Начало быстрой сортировки
        /// </summary>
        /// <param name="list">Список для сортировки</param>
        static void StartQsort(List<int> list)
        {//Это сделанно что бы передать индексы в новый метод
            var a = Qsort(list, 0, list.Count - 1);
        }
        /// <summary>
        /// Быстрая сортировка(рекурсивный метод)
        /// </summary>
        /// <param name="array">Список</param>
        /// <param name="leftIndex">С чего мы начинаем сортировать</param>
        /// <param name="rightIndex">На чем заканчиваем сортировать</param>
        /// <returns></returns>
        static List<int> Qsort(List<int> array, int leftIndex, int rightIndex)
        {
            
            var i = leftIndex;
            var j = rightIndex;
            //Опорный элемент
            var pivot = array[leftIndex];
            // Пока левый индекс меньше правого
            while (i <= j)
            {
                // Пока левый Элемент меньше опорного двигаемся вправо
                while (array[i] < pivot)
                {
                    i++;
                }
                // Пока правый Элемент больше опорного двигаемся влево
                while (array[j] > pivot)
                {
                    j--;
                }
                // На данный момент i укаывает на левый элемент меньше опорного,
                // А j указывавет на правый элемент больше опорного
                // 
                if (i <= j)
                {
                    // Меняем элементы местами
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    //двигаемся дальше так как элементы найденный ранее упорядочились
                    i++;
                    j--;
                }
            }
           
            if (leftIndex < j)
                //Выбираем новую облать работы сортировки слева
                Qsort(array, leftIndex, j);
            if (i < rightIndex)
                //Выбираем новую область сортировки справа
                Qsort(array, i, rightIndex);
            return array;
        }
        /// <summary>
        /// Сортировка Слиянием 
        /// </summary>
        /// <param name="list">Список</param>
        /// <returns></returns>
        static List<int> MergeSort(List<int> list)
        {
            // ЕСЛИ В СПИСКЕ ТОЛЬКО 1 ЭЛЕМЕНТ ЕГО НЕ НАДО СОРТИРОВАТЬ
            if (list.Count == 1)
            {
                return list;
            }
            // Находим центр списка
            int center = list.Count / 2;
            // Делим список на 2 части
            List<int> left = list.GetRange(0, center);
            List<int> right = list.GetRange(center, list.Count - center);

            //Применяем алгоритм сортировки для левой и правой части и соединяем результаты
            return Merge(MergeSort(left), MergeSort(right));
        }
        /// <summary>
        /// Соединение разделенных списков
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        static List<int> Merge(List<int> list1, List<int> list2)
        {
            int i = 0, j = 0;
            //список для обьединение двух списков
            List<int> merged = new List<int>();
            for (int k = 0; k < list1.Count + list2.Count; k++)
            {
                // Проверяем если ти в каждом списке не пройденные елементы
                if (i < list1.Count && j < list2.Count)
                {
                    //Записываем больший элемент в список слияния
                    if (list1[i] > list2[j])
                    {
                        merged.Add(list2[j]);
                        j++;
                    }
                    else
                    {
                        merged.Add(list1[i]);
                        i++;
                    }
                }
                // Если в одном списке закончились оствшиеся элементы добавляем в конец списка
                else
                {
                    if (j < list2.Count)
                    {
                        merged.Add(list2[j]);
                        j++;
                    }
                    else
                    {
                        merged.Add(list1[i]);
                        i++;
                    }
                }
            }
            return merged;
        }
        /// <summary>
        /// Сортировка подсчетом
        /// </summary>
        /// <param name="list"></param>
        /// <param name="count"></param>
        /// <param name="maxNumber"></param>
        static void CountSort(List<int> list, int count, int maxNumber)
        {
            // создаем таблицу для подсчета
            int[] table = new int[maxNumber];
            foreach (var num in list)
            {
                table[num]++;
            }
            list.Clear();
            //Записывает попорядку элементы в зависимости с подсчетом
            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < table[i]; j++)
                {
                    list.Add(i);
                }
            }
        }
        /// <summary>
        /// Поразрядная сортировка
        /// </summary>
        /// <param name="list"></param>
        /// <param name="maxLength">Максимальная Длинна цифры в символах</param>
        /// <param name="iter">На каком разряде для сортировки вы сейчас</param>
        static void RadixSort(List<int> list, int maxLength, int iter = 0)
        {
            //Список для промежуточных сортироваок по разрядам
            List<List<int>> data = new List<List<int>>(10);
            // добавляем в список списки
            for (int i = 0; i < 10; i++)
            {
                data.Add(new List<int>());
            }
            // идем по элементам
            foreach (var num in list)
            {
                //  В промежуточный список добавляем элемент по break выбираем число с помощью iter
                data[Break(num, maxLength)[iter]].Add(num);
            }
            list.Clear();
            // идем по разрядам и поочередно записываем числа 
            foreach (var raz in data)
            {
                int count = raz.Count;
                for (int i = 0; i < count; i++)
                {
                    list.Add(raz[0]);
                    raz.RemoveAt(0);
                }
            }
            // увеличиваем разряд уходим на новую итерацию
            iter++;
            if (iter > maxLength - 1) return;
            RadixSort(list, maxLength, iter);
        }
        /// <summary>
        /// Разбивает число на разряды и выводит в виде массива в обратном порядке например 125 будет {5, 2, 1,} 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        static int[] Break(int num, int maxLength)
        {
            int[] data = new int[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                data[i] = num % 10;
                num = num / 10;
            }
            return data;
        }
        /// <summary>
        /// Гномья сортировка 
        /// </summary>
        /// <param name="list">Передаем список</param>
        private static void GnomeSort(List<int> list)
        {
            //идем со второго элемента если 1 елемент меньше или равен второму элементу увеличиваем i
            //В противном случае меняем элементы местави и уменьшаем i
            for (int i = 1; i < list.Count;)
            {
                if (list[i - 1] <= list[i])
                    ++i;
                else
                {
                    int tmp = list[i];
                    list[i] = list[i - 1];
                    list[i - 1] = tmp;
                    --i;
                    if (i == 0)
                        i = 1;
                }
            }
        }
    }
    /// <summary>
    /// Вершина бинарного дерева
    /// </summary>
    public class node
    {
        public int data { get; set; }
        public node less { get; set; }
        public node bigger { get; set; }
        public node(int number)
        {
            data = number;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class BinaryTree
    {
        public node start { get; set; }
        public BinaryTree(int number)
        {
            start = new node(number);
        }
        //добавление
        public void add(int number)
        {
            add(start, number);
        }
        /// <summary>
        /// Добавление
        /// Берем ноду если больше значений внутри нее то мы идем вправо если там пустая ячейка создаем ноду,
        /// если там занято рекурсивно запускаем добавление
        /// с меньше аналогично
        /// </summary>
        /// <param name="node"></param>
        /// <param name="number"></param>
        private void add(node node, int number)
        {
            if (number > node.data)
            {
                if (node.bigger == null)
                {
                    node.bigger = new node(number);
                }
                else
                {
                    add(node.bigger, number);
                }
            }
            else
            {
                if (node.less == null)
                {
                    node.less = new node(number);
                }
                else
                {
                    add(node.less, number);
                }
            }
        }
        
        public void Remove(int key)
        {
            RemoveHelper(start, key);
        }
        /// <summary>
        /// Удаление ноды из дерева
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private node RemoveHelper(node root, int key)
        {

            if (root == null)
                return root;
            //если ключ меньше корневого узла, идем влево рекурсивно
            if (key < root.data)
                root.less = RemoveHelper(root.less, key);
            // если ключ больше, чем корневой узел, идем вправо рекурсивно
            else if (key > root.data)
            {
                root.bigger = RemoveHelper(root.bigger, key);
            }
            //иначе мы нашли ключ
            else
            {
                //случай 1: удаляемый узел не имеет дочерних элементов
                if (root.less == null && root.bigger == null)
                {
                    //просто удаляем ноду
                    root = null;
                }
                //случай 2: удаляемый узел имеет два дочерних элемента
                else if (root.less != null && root.bigger != null)
                {
                    var maxNode = FindMin(root.bigger);
                    //скопируйте значение
                    root.data = maxNode.data;
                    root.bigger = RemoveHelper(root.bigger, maxNode.data);
                }
                //узел, который нужно удалить, имеет один дочерней элемент
                else
                {
                    var child = root.less != null ? root.less : root.bigger;
                    root = child;
                }

            }
            return root;

        }
        /// <summary>
        /// Поиск минимального относительно принятой ноды
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private node FindMin(node node)
        {
            while (node.less != null)
            {
                node = node.less;
            }
            return node;
        }
        /// <summary>
        /// рекурсивный вывод дерева
        /// идем макс на лево и потом чисто на право
        /// </summary>
        /// <param name="root"></param>
        private void DisplayTree(node root)
        {
            if (root == null) return;

            DisplayTree(root.less);
            System.Console.Write(root.data + " ");
            DisplayTree(root.bigger);
        }
        
        public void DisplayTree()
        {
            DisplayTree(start);
        }
        /// <summary>
        /// Нахождение 
        /// Обход в глубину пока не встретим этот элемент
        /// </summary>
        /// <param name="node">нода</param>
        /// <param name="num">значение ноды</param>
        /// <returns></returns>
        public Boolean Find(node node, int num)
        {
            if (node == null) return false;
            if (node.data == num)
            {
                return true;
            }
            else if (num < node.data)
            {
                return Find(node.less, num);
            }
            else if (num > node.data)
            {
                return Find(node.bigger, num);
            }
            return false;
        }
    }
    /// <summary>
    /// Двусвязный список
    /// </summary>
    public class DoubleList
    {
        // Начальный указатель
        node start = null;
        public DoubleList(int[] arr, int n)
        {
            // Создание списка
            start = createList(arr, n, start);
        }
        public class node
        {
            public int data;
            public node next;
            public node prev;
        };

        // вспомогательная функция вернуть ноду
        public node getNode()
        {
            return new node();
        }

        // Вывод списка в консоль
        public int displayList()
        {
            node temp = start;
            node t = temp;
            if (temp == null)
                return 0;
            else
            {
                Console.WriteLine("The list is: ");

                while (temp.next != t)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }

                Console.WriteLine(temp.data);

                return 1;
            }
        }

        // Возвращает количество элементов в списке
        public int countList()
        {
            // Declare temp pointer to
            // traverse the list
            node temp = start;

            // Variable to store the count
            int count = 0;

            // Iterate the list and
            // increment the count
            while (temp.next != start)
            {
                temp = temp.next;
                count++;
            }

            // As the list is circular, increment
            // the counter at last
            count++;

            return count;
        }

        // Вставляем ноду в центр списка
        public void add(int num)
        {
            this.insertAtLocation(num, this.countList() / 2 + 1);
        }

        private node insertAtLocation(int data, int loc)
        {
            // Declare two pointers
            node temp, newNode;
            int i, count;

            // Create a new node in memory
            newNode = getNode();

            // Point temp to start
            temp = start;

            // count of total elements in the list
            count = countList();

            // If list is empty or the position is
            // not valid, return false
            if (temp == null || count < loc)
                return start;

            else
            {
                // Assign the data
                newNode.data = data;

                // Iterate till the loc
                for (i = 1; i < loc - 1; i++)
                {
                    temp = temp.next;
                }

                // See in Image, circle 1
                newNode.next = temp.next;

                // See in Image, Circle 2
                (temp.next).prev = newNode;

                // See in Image, Circle 3
                temp.next = newNode;

                // See in Image, Circle 4
                newNode.prev = temp;

                return start;
            }

        }

        /// <summary>
        /// Создание двусвязного списка
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        private node createList(int[] arr, int n, node start)
        {
            // Объявить newNode и временный указатель
            node newNode, temp;
            int i;

            // Добавляем данные
            for (i = 0; i < n; i++)
            {
                // Создаем новую ноду
                newNode = getNode();

                // добовляем данные в ноду
                newNode.data = arr[i];

                // Закручиваем первый элемент
                if (i == 0)
                {
                    start = newNode;
                    newNode.prev = start;
                    newNode.next = start;
                }

                else
                {
                    // Находим последнюю ноду
                    temp = (start).prev;

                    //добавляем элемент и
                    //Закручиваем список
                    temp.next = newNode;
                    newNode.next = start;
                    newNode.prev = temp;
                    temp = start;
                    temp.prev = newNode;
                }
            }
            return start;
        }
    }
    public class DoublyLinkedList<T> : IEnumerable<T>  // двусвязный список
    {
        public class DoublyNode<T>
        {
            public DoublyNode(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public DoublyNode<T> Previous { get; set; }
            public DoublyNode<T> Next { get; set; }
        }

        DoublyNode<T> head; // головной/первый элемент
        DoublyNode<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        // удаление
        public bool Remove(T data)
        {
            DoublyNode<T> current = head;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Previous;
                }

                // если узел не первый
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

        public static void test()
        {
            DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();
            // добавление элементов
            linkedList.Add("Bob");
            linkedList.Add("Bill");
            linkedList.Add("Tom");
            linkedList.AddFirst("Kate");
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            // удаление
            linkedList.Remove("Bill");

            // перебор с последнего элемента
            foreach (var t in linkedList.BackEnumerator())
            {
                Console.WriteLine(t);
            }
        }
    }
}
