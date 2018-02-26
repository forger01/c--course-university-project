using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1, n2;
            string str;
            bool run = true;
            Arr MyArr = new Arr();
            while (run)
            {
                Console.WriteLine("Нажмите 1, чтобы вывести меню на консоль");
                str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                        Console.WriteLine(@"Меню:
1- Распечатка меню.
2- Создать массив из файла
3- создать массив с консоли
4 - рандомно создать массив
5 - напечатать массив
6 - напечатать массив в файл
7 - напечатать подматрицу
8- Реализация функции 1: поменять столбцы в подматрице.
9 - Реализация функции 2: поменять строки в подматрице.
10 - Реализация функции 3: среднее арифметическое элементов, стоящих над побочной диагональю подматрицы.
11 - Реализация функции 4: сумма элементов с четными индексами на диагонали подматрицы.
12 - Реализация функции 5: медианы каждой строки.
13- Завершение работы.");
                        Console.WriteLine(" Выбкрите следующий пункт меню");
                        break;

                    case "2":
                        try
                        {
                            Console.WriteLine("Input file name");
                            str = Console.ReadLine();
                            MyArr = new Arr(str);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "3":
                        try
                        {
                            MyArr = new Arr(1);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "4":
                        try
                        {
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "5":
                        try
                        {
                            MyArr.PrintToConsol();
                        }                    
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "6":
                        try
                        {
                            MyArr.PrintToFile();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "7":
                        try
                        {
                            MyArr.PrintFragmToConsol();
                        }
                        catch (Exception e)
                        { Console.WriteLine(e.Message); }
                        break;

                    case "8":
                        try
                        {
                            Console.WriteLine("Inpute number of col1 and col2");
                            n1 = Int32.Parse(Console.ReadLine());
                            n2 = Int32.Parse(Console.ReadLine());
                            MyArr.ChangeCol(n1, n2);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case "9":
                        try
                        {
                            Console.WriteLine("Inpute number of str1 and str2");
                            n1 = Int32.Parse(Console.ReadLine());
                            n2 = Int32.Parse(Console.ReadLine());
                            MyArr.ChangeLine(n1, n2);
                        }
                        catch (Exception e)
                        { 
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "10":
                        Console.WriteLine("Average is" + MyArr.Average().ToString());
                        break;
                    case "11":
                        Console.WriteLine("Sum is" + MyArr.SumOfEvenElem().ToString());
                        break;
                    case "12":
                        for (int i = 0; i < 11; i++)
                            Console.WriteLine(MyArr.FindMediana()[i].ToString());
                        break;
                    case "13":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Неверно введен пункт меню.Введите правильный номер!");
                        break;
                }
            }
        }
    }
}
