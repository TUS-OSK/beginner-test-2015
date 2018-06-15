using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_4
{
    class Program
    {
        //(1)
        static void PrintOskConsciousness(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("I am a member of OSK.");
            }
        }

        //(2)
        /*
        *(i)返値の型
        *void
        *(ii)引数の型
        *int
        */

        //(3)戻り値がない

        //(4)
        static bool CheckNullOrEmpty(string a)
        {
            if (a == null || a == "")
            {
                return true;
            }
            return false;
        }

        //(5)
        static int GetMax3(int a, int b, int c)
        {
            if (a >= b && a >= c) return a;
            if (b >= c) return b;
            return c;
        }

        //(6)
        static int GetMinArray(int[] array)
        {
            int max = 0;
            for (int i = 0; i < array.length; i++)
            {
                if (max > array[i]) max = array[i];
            }
            return max;
        }

        static void Main(string[] args)
        {
          //上で書いたコードを試したいときはここに書いて実行する
        }
    }
}
