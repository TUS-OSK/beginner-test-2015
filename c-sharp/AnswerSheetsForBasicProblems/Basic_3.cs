using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_3
{
    class Program
    {
        static void Main(string[] args)
        {
          //(1)
            int x = 1000;
            if (x => 100)
            {
                Console.WriteLine("xの値は100以上です");
            }

            //(2)
            int x = 1000;
            if (x => 100)
            {
                Console.WriteLine("xの値は100以上です");
            }
            else
            {
                Console.WriteLine("xの値は100以上です");
            }

            //(3)
            int month = 3;
            switch (month)
            {
                case 1:
                    Console.WriteLine("Jan");
                case 2:
                    Console.WriteLine("Feb");
                case 3:
                    Console.WriteLine("Mar");
                case 4:
                    Console.WriteLine("Apr");
                case 5:
                    Console.WriteLine("May");
                case 6:
                    Console.WriteLine("Jun");
                case 7:
                    Console.WriteLine("Jul");
                case 8:
                    Console.WriteLine("Aug");
                case 9:
                    Console.WriteLine("Sep");
                case 10:
                    Console.WriteLine("Oct");
                case 11:
                    Console.WriteLine("Nov");
                case 12:
                    Console.WriteLine("Dec");
            }

            //(4)
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }

            //(5)
            int y = 0;
            for (int i = 1; i < 100; i++)
            {
                y++;
            }

            //(6)
            Random random = new Random();
            while (true)
            {
                if (random.Next(1000) == 645) break;
            }
            Console.WriteLine("645が出ました");

            //(7)
            int[] intArray = new int[]{43,624,73,278,24,82,278,16,25,72,8};
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }
        }
    }
}
