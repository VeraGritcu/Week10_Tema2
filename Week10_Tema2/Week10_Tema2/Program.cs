using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10_Tema2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var myMatrix = new Matrix<int>(2, 2);
            //myMatrix[0, 0] = 1;
            //myMatrix[0, 1] = 2;
            //myMatrix[1, 0] = 3;
            //myMatrix[1, 1] = 4;

            //Console.Write(myMatrix.ToString());

            //Console.WriteLine(myMatrix[0,1]);
            //var secondMatrix = new Matrix<int>(2, 3);
            //secondMatrix[0, 0] = 1;
            //secondMatrix[0, 1] = 2;
            //secondMatrix[0, 2] = 3;
            //secondMatrix[1, 0] = 4;
            //secondMatrix[1, 1] = 5;
            //secondMatrix[1, 2] = 6;


            //var thirdMatrix = myMatrix * secondMatrix;

            //Console.WriteLine(thirdMatrix.ToString());

            //thirdMatrix.CheckNonZero();
            //var myString = "ab-cd";
            //var reversed = ReverseString(myString);
            //Console.WriteLine(reversed);

            //var myString = "a-bC-dEf-ghIj";
            //var reversed = ReverseString(myString);
            //Console.WriteLine(reversed);


            var myString = "Test1ng-Leet=code-Q!";
            var reversed = ReverseString(myString);
            Console.WriteLine(reversed);

            Console.ReadKey();
        }

        public static string ReverseString(string str)
        {
            if (str == "")
            {
                throw new ArgumentException("Oups, your string is empty");
            }
            char[] array = str.ToCharArray();
            int r = array.Length - 1, l = 0;

            while (l < r)
            {
                if (!char.IsLetter(array[l]))
                    l++;
                else if (!char.IsLetter(str[r]))
                    r--;

                else
                {
                    char tmp = array[l];
                    array[l] = array[r];
                    array[r] = tmp;
                    l++;
                    r--;
                }
            }
            string reversed = null;
            foreach (var item in array)
            {
                reversed += item.ToString();
            }

            return reversed;
        }

    }
}
