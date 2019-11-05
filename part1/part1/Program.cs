//eliora bloch 206343501
//leil orenstein 209220730
using System;

/*this is a program that fiils up to arrays (size 20) with random numbers from 18 to 122, and fills up a third array with the
 * sub of each two numbers from the arrays.*/
namespace part1
{

    class Program
    {
        static Random r= new Random();

        static void Main(string[] args)
        {
            int[] A = new int[20];
            int[] B = new int[20];
            int[] C= new int[20];
            for (int i = 0; i < 20; i++)
            {
                A[i] = r.Next(18, 122); //filling array with random numbers
            }
            for (int i = 0; i < 20; i++)
            {
               B[i] = r.Next(18, 122);
            }
            for (int i = 0; i < 20; i++)
            {
                if (A[i] > B[i])
                {
                    C[i] = (A[i] - B[i]);
                }

                if (A[i] < B[i])
                {
                    C[i] = (B[i] - A[i]);
                }

                if (A[i]==B[i])
                {
                    C[i] = 0;
                }
                
            }
            for (int i = 0; i < 20; i++)  // these itrations make the spaces between the numbers
            {
                Console.Write("{0,-5}",A[i]);
            }
            Console.WriteLine("");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,-5}", B[i]);
            }
            Console.WriteLine("");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0,-5}", C[i]);
            }
            Console.WriteLine("");



            Console.ReadKey();
           

        }
    }
}
