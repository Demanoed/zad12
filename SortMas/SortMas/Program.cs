using System;
using System.Collections.Generic;
using System.Linq;
using DemanT_Library;

namespace SortMas
{
    class Program
    {
        #region три вида массива
        private static double[] rndMas, vozMas, ubvMas;
        #endregion
        #region счетчики для сравнений и перестановок
        private static int rndSrv = 0, vozSrv = 0, ubvSrv = 0;
        private static int rndPer = 0, vozPer = 0, ubvPer = 0;
        #endregion
        #region Переменная для рандома
        private static Random rnd = new Random();
        #endregion
        #region Переменная для проверки сортированности
        private static bool sort = false;
        #endregion
        #region Печатает меню
        private static int Menu()
        {
            ColorMess.Yellow("\n Выберите пункт меню");
            ColorMess.Cyan("\n\n 1) Создать массив" +
                        "\n\n 2) Отсортировать массив" +
                        "\n\n 3) Напечатать массив" +
                        "\n\n 4) Выход");
            ColorMess.Green("\n\n Цифра: ");
            return Input.Check(1, 4);
        }
        #endregion
        #region Меню для выбора метода сортировки
        private static int ChooseSort()
        {
            Console.Clear();
            ColorMess.Yellow("\n Выберите пункт меню");
            ColorMess.Cyan("\n\n 1) Сортировка слиянием" +
                        "\n\n 2) Блочная сортировка" +
                        "\n\n 3) Назад");
            ColorMess.Green("\n\n Цифра: ");
            return Input.Check(1, 3);
        }
        #endregion
        #region Создает массив
        private static bool CreateMas()
        {
            Console.Clear();
            ColorMess.Yellow("\n Сколько эллементов в массиве (от 2 до 100): ");
            int kol = Input.Check(1, 100);
            rndMas = new double[kol];
            vozMas = new double[kol];
            ubvMas = new double[kol];
            Console.Clear();
            if (Message.HowAdd() == 1)
            {
                for (int i = 0; i < rndMas.Length; ++i)
                {
                    Console.Clear();
                    ColorMess.Yellow("\n Введите " + (i + 1) + " число: ");
                    rndMas[i] = Input.Check(-99, 100);
                }
            }
            else
            {
                for (int i = 0; i < rndMas.Length; ++i)
                    rndMas[i] = rnd.Next(-99, 100);
            }
            for (int i = 0; i < vozMas.Length; ++i)
                vozMas[i] = rndMas[i];
            for (int i = 0; i < ubvMas.Length; ++i)
                ubvMas[i] = rndMas[i];
            Array.Sort(vozMas);
            Array.Sort(ubvMas);
            Array.Reverse(ubvMas);
            return true;
        }
        #endregion
        #region Печатает массив
        private static void PrintMas()
        {
            Console.Clear();
            if (!sort)
            {
                ColorMess.Magenta("\n Рандомный массив выглядит так: \n\n");
                for (int i = 0; i < rndMas.Length; ++i)
                    ColorMess.Cyan(" " + rndMas[i]);
                ColorMess.Yellow("\n Колличество сравнений: " + rndSrv + ", Колличество перестановок: " + rndPer + "\n");
                ColorMess.Magenta("\n Возрастающий массив выглядит так: \n\n");
                for (int i = 0; i < vozMas.Length; ++i)
                    ColorMess.Cyan(" " + vozMas[i]);
                ColorMess.Yellow("\n Колличество сравнений: " + vozSrv + ", Колличество перестановок: " + vozPer + "\n");
                ColorMess.Magenta("\n Убывающий массив выглядит так: \n\n");
                for (int i = 0; i < ubvMas.Length; ++i)
                    ColorMess.Cyan(" " + ubvMas[i]);
                ColorMess.Yellow("\n Колличество сравнений: " + ubvSrv + ", Колличество перестановок: " + ubvPer + "\n");
            }
            else
            {
                ColorMess.Magenta("\n Отсортированный рандомный массив выглядит так: \n\n");
                for (int i = 0; i < rndMas.Length; ++i)
                    ColorMess.Cyan(" " + rndMas[i]);
                ColorMess.Yellow("\n Колличество сравнений: " + rndSrv + ", Колличество перестановок: " + rndPer + "\n");
                ColorMess.Magenta("\n Отсортированный возрастающий массив выглядит так: \n\n");
                for (int i = 0; i < vozMas.Length; ++i)
                    ColorMess.Cyan(" " + vozMas[i]);
                ColorMess.Yellow("\n Колличество сравнений: " + vozSrv + ", Колличество перестановок: " + vozPer + "\n");
                ColorMess.Magenta("\n Отсортированный убывающий массив выглядит так: \n\n");
                for (int i = 0; i < ubvMas.Length; ++i)
                    ColorMess.Cyan(" " + ubvMas[i]);
                ColorMess.Yellow("\n Колличество сравнений: " + ubvSrv + ", Колличество перестановок: " + ubvPer + "\n");
            }
        }
        #endregion
        #region Проверяет на кол-во элементов в массиве и вызывает метод сортировки слиянием
        private static double[] MergeSort(double[] massive, ref int sravnenie, ref int perestonovka)
        {
            if (massive.Length == 1)
                return massive;
            int mid_point = massive.Length / 2;
            return Merge(MergeSort(massive.Take(mid_point).ToArray(), ref sravnenie, ref perestonovka), MergeSort(massive.Skip(mid_point).ToArray(), ref sravnenie, ref perestonovka), ref sravnenie, ref perestonovka);
        }
        #endregion
        #region Метод сортировки слиянием
        private static double[] Merge(double[] mass1, double[] mass2, ref int sravnenie, ref int perestonovka)
        {
            int a = 0, b = 0;
            double[] merged = new double[mass1.Length + mass2.Length];
            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b])
                    {
                        sravnenie++;
                        merged[i] = mass2[b++];
                        perestonovka++;
                    }
                    else //if int go for
                    {
                        sravnenie++;
                        merged[i] = mass1[a++];
                        perestonovka++;
                    }
                else
                    if (b < mass2.Length)
                {
                    merged[i] = mass2[b++];
                    perestonovka++;
                }
                else
                {
                    merged[i] = mass1[a++];
                    perestonovka++;
                }
            }
            return merged;
        }
        #endregion
        #region Сортировка трех типов массива при помощи метода слияния
        private static void ForMergeSort()
        {
            rndMas = MergeSort(rndMas, ref rndSrv, ref rndPer);
            vozMas = MergeSort(vozMas, ref vozSrv, ref vozPer);
            ubvMas = MergeSort(ubvMas, ref ubvSrv, ref ubvPer);
        }
        #endregion
        #region Метод блочной сортировки
        private static void BucketSort(double[] a, ref int sravnenie, ref int perestonovka)
        {
            List<double>[] aux = new List<double>[a.Length];
            for (int i = 0; i < aux.Length; ++i)
                aux[i] = new List<double>();
            double minValue = a[0];
            double maxValue = a[0];
            for (int i = 1; i < a.Length; ++i)
            {
                if (a[i] < minValue)
                {
                    minValue = a[i];
                    sravnenie++;
                }
                else if (a[i] > maxValue)
                {
                    maxValue = a[i];
                    sravnenie++;
                }
            }
            double numRange = maxValue - minValue;
            for (int i = 0; i < a.Length; ++i)
            {
                int bcktIdx = (int)Math.Floor((a[i] - minValue) / numRange * (aux.Length - 1));
                aux[bcktIdx].Add(a[i]);
                perestonovka++;
            }
            for (int i = 0; i < aux.Length; ++i)
            {
                aux[i].Sort();
                sravnenie++;
                perestonovka++;
            }
            int idx = 0;
            for (int i = 0; i < aux.Length; ++i)
            {
                for (int j = 0; j < aux[i].Count; ++j)
                {
                    a[idx++] = aux[i][j];
                    perestonovka++;
                }
            }
        }
        #endregion
        #region Сортировка трех типов массива при помощи метода блочной сортировки
        private static void ForBucketSort()
        {
            BucketSort(rndMas, ref rndSrv, ref rndPer);
            BucketSort(vozMas, ref vozSrv, ref vozPer);
            BucketSort(ubvMas, ref ubvSrv, ref ubvPer);
        }
        #endregion
        #region Запрашивает у пользователя данные, печатает меню с выбором операции, выводит результат обработки
        static void Main()
        {
            bool ok = false;
            Again:
            Console.Clear();
            switch (Menu())
            {
                case 1:
                    ok = CreateMas();
                    sort = false;
                    rndPer = 0;
                    rndSrv = 0;
                    vozPer = 0;
                    vozSrv = 0;
                    ubvPer = 0;
                    ubvSrv = 0;
                    ColorMess.Green("\n Созданно!");
                    Message.GoToBack();
                    goto Again;
                case 2:
                    bool ok2 = false;
                    if (ok && !sort)
                    {
                        for (int i = 0; i < rndMas.Length; ++i)
                            try
                            {
                                if (rndMas[i] != rndMas[i + 1])
                                    ok2 = true;
                            }
                            catch (IndexOutOfRangeException) { }
                        if (ok2)
                        {
                            sort = true;
                            switch (ChooseSort())
                            {
                                case 1:
                                    ForMergeSort();
                                    break;
                                case 2:
                                    ForBucketSort();
                                    break;
                                case 3:
                                    sort = false;
                                    break;
                            }
                            ColorMess.Green("\n Отсортировано!");
                        }
                        else
                        {
                            ColorMess.Red("\n Массив состоит из повторяющихся элементов, сортировка невозможна!");
                        }
                    }
                    else
                    {
                        ColorMess.Red("\n Создайте новый массив!");
                    }
                    Message.GoToBack();
                    goto Again;
                case 3:
                    if (ok)
                    {
                        PrintMas();
                    }
                    else
                    {
                        ColorMess.Red("\n Создайте новый массив!");
                    }
                    Message.GoToBack();
                    goto Again;
                case 4:
                    break;
            }
        }
        #endregion
    }
}
