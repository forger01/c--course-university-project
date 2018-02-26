using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyNamespace
{
    public abstract class BaseArr
    {
        protected static int NumOfLines = 11;
        protected double[][] MyArr;
        protected int s1, st1, min_lenght_of_line = 18;
        protected BaseArr()
        {
            int temp;
            Random rand = new Random();
            MyArr = new double[NumOfLines][];
            for (int i = 0; i < 11; i++)
            {
                temp = rand.Next(9, 18);
                if (min_lenght_of_line > temp)
                    min_lenght_of_line = temp;
                MyArr[i] = new double[temp];
                for (int j = 0; j < MyArr[i].Length; j++)
                    MyArr[i][j] = rand.Next(100) + rand.NextDouble();
            }
            s1 = rand.Next(2, 10);
            st1 = rand.Next(2, min_lenght_of_line - 2);
            
        }
        protected BaseArr(int k) 
        {
            int temp = 0;
            MyArr = new double[NumOfLines][];
            Console.WriteLine("Input num of elements in 11 lines");
            for (int i = 0; i < 11; i++)
            {
                temp = Int32.Parse(Console.ReadLine());
                if (temp < 9 || temp > 18)
                    throw new ApplicationException("Wrong number");
                else
                {
                    if (min_lenght_of_line > temp)
                        min_lenght_of_line = temp;
                    MyArr[i] = new double[temp];
                }
            }
            Console.WriteLine("Input numbers:");
            for (int i = 0; i < NumOfLines; i++)
                for (int j = 0; j < MyArr[i].Length; j++)
                    MyArr[i][j] = Double.Parse(Console.ReadLine());
            Console.WriteLine("Input s1");
            temp = Int32.Parse(Console.ReadLine());
            if (temp < 1 || temp > 11)
                throw new ApplicationException("Wrong number");
            else
                s1 = temp;
            Console.WriteLine("Input st1");
            temp = Int32.Parse(Console.ReadLine());
            if (temp < 1 || temp > min_lenght_of_line)
                throw new ApplicationException("Wrong number");
            else
                st1 = temp;

        }
        protected BaseArr(string FileName) 
        {
            using (StreamReader file = new StreamReader("1.txt"))
            {
                int temp = 0;
                MyArr = new double[NumOfLines][];
                for (int i = 0; i < 11; i++)
                {
                    temp = Int32.Parse(file.ReadLine());                         //считываем количество элементов в строке
                    if (temp < 9 || temp > 18)
                        throw new ApplicationException("Wrong number");
                    else
                    {
                        if (min_lenght_of_line > temp)
                        min_lenght_of_line = temp;
                        MyArr[i] = new double[temp];                                //считываем элементы
                        for (int j = 0; j < temp; j++)
                            MyArr[i][j] = Double.Parse(file.ReadLine());
                    }
                }
                temp = Int32.Parse(file.ReadLine());
                if (temp < 1 || temp > 11)
                    throw new ApplicationException("Wrong number");
                else
                    s1 = temp;
                temp = Int32.Parse(file.ReadLine());
                if (temp < 1 || temp > min_lenght_of_line)
                    throw new ApplicationException("Wrong number");
                else
                    st1 = temp;
            }
        }
        public abstract void ChangeCol(int Col1, int Col2);
        public abstract void ChangeLine(int Line1, int Line2);
        public abstract double[] FindMediana();
        public abstract double SumOfEvenElem();
        public abstract double Average();
        public abstract void PrintToConsol();
        public abstract void PrintFragmToConsol();
        public abstract void PrintToFile();
    }

    public class Arr : BaseArr
    {
        public Arr() : base() { }
        public Arr(int i) : base(i) { }
        public Arr(string FileName) : base(FileName) { }
        public override void PrintToConsol()
        {
            for (int i = 0; i < NumOfLines; i++)
            {
                for (int j = 0; j < MyArr[i].Length - 1; j++)
                {
                    Console.Write("{0:0.00}", MyArr[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine("{0:0.00}", MyArr[i][MyArr[i].Length - 1]);
            }
        }
        public override void PrintFragmToConsol()
        {
            for (int i = 1; i < s1 + 1; i++)
            {
                for (int j = 2; j < st1 + 1; j++)
                {
                    Console.Write("{0:0.00}", MyArr[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine("{0:0.00}", MyArr[i][st1 + 1]);
            }
        }
        public override void PrintToFile()
        {
            string name;
            Console.WriteLine("Input filename");
            name = Console.ReadLine();
            StreamWriter file = new StreamWriter(name);
            for (int i = 0; i < NumOfLines; i++)
            {
                for (int j = 0; j < MyArr[i].Length - 1; j++)
                    file.Write(MyArr[i][j].ToString() + " ");
                file.WriteLine(MyArr[i][MyArr[i].Length - 1]);
            }
            file.Close();
        }
        public override void ChangeCol(int Col1, int Col2)               //добавить исключ
        {
            double temp;
            if (st1 + 1 < Col1 || st1 + 1 < Col2 || Col2 < 2 || Col1 < 2)
                Console.WriteLine("Too much num of columns for this fragment");
            else
            {
                for (int i = 1; i < s1 + 1; i++)
                {
                    temp = MyArr[i][Col1];
                    MyArr[i][Col1] = MyArr[i][Col2];
                    MyArr[i][Col2] = temp;
                }
            }
        }
        public override void ChangeLine(int Line1, int Line2)               //добавить исключ и дописать как колонки, чтоб работала с фрагментом
        {
            double temp;
            if (Line1 < 1 || Line2 < 1 || Line1 > s1 || Line2 > s1)
                Console.WriteLine("Too much num of columns for this fragment");
            else
            {
                for (int i = 2; i < 2 + st1; i++)
                {
                    temp = MyArr[Line1][i];
                    MyArr[Line1][i] = MyArr[Line2][i];
                    MyArr[Line2][i] = temp;
                }
            }
        }
        public override double[] FindMediana()
        {
            double []res = new double [11];
            double sum = 0;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < MyArr[i].Length; j++)
                    sum += MyArr[i][j];
                sum = sum / NumOfLines;
                res[i] = MyArr[i][0];
                for (int j = 0; j < MyArr[i].Length; j++)
                    if (Math.Abs(sum - MyArr[i][j]) < Math.Abs(sum - res[i]))
                        res[i] = MyArr[i][j];
                sum = 0;
            }
            return res;
        }
        public override double SumOfEvenElem()
        {
            int len = s1;
            double sum = 0;
            if (st1 < len)
                len = st1;
            for (int i = 1; i < len + 1; i += 2)
                sum += MyArr[i][i + 1];
            return sum;
        }
        public override double Average()
        {
            int len = s1;
            double sum = 0, num = 0;
            if (st1 < len)
                len = st1;
            for (int i = s1; i > 0; i--)
            {
                for (int j = 2; j < s1 + 2 - i; j++)
                {
                    sum += MyArr[i][j];
                    num++;
                }
            }
            return sum / num;
        }

    }
}
