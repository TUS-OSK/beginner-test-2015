using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //(1)
            //10 と 5 の和
            Console.WriteLine(10 + 5);
            //10 と 5 の差
            Console.WriteLine(10 - 5);
            //10 と 5 の積
            Console.WriteLine(10*5);
            //10 と 5 の商
            Console.WriteLine(10/5);

            //(2)
            /*
            *キャストされて切り捨てられて１
            */

            //(3)
            int x = 5;
            x -= 20;

            //(4)
            int y = 1;
            y++;
            y++;
            y--;

            //(5)
            /*
            *1 ≦ t < 5
            *1<=t && t<5
            *t < -5 , 5 ≦ t
            *t<-5 || 5<=t
            */

            //(6)
            /*
            *(i)true || false
            *true
            *(ii)false && false
            *false
            */

            //(7)
            /*
            *否定
            */

            //(8)
            int a = 3;
            int b = 2;
            Console.WriteLine((double) a/b);

            //(9)
            /*
            *Hello6
            */

        }
    }
}
