using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswersForAdvancedProblems
{
    class AnswerForAdvanecd1
    {
        static void Main(string[] args)
        {
            collatz(5);
            Debug.log(2);
            ;
        }

        public static void collatz(int n)
        {
            int b = n;
            while (n != 1)
            {
                if (n%2 == 0) Debug.log(n = n/2);
                else Debug.log(n = 3*n + 1);

            }
        }
    }
}
