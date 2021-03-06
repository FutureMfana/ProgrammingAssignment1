using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingAssignment1
{
    class Program
    { 
        //catering for odd numbers
        private static int[] odd = new int[2];
        //catering for odd numbers
        private static int[] even = new int[2];
        //for tracking number of order numbers and even numbers
        private static int count_odd = -1, count_even = -1;

        static void Main(string[] args)
        {
            Program obj = new Program();
            int[] squares = new int[20];
            squares = obj.getSquares();

	    //I noticed the waste of memory on my arrays, but I noticed after runnig. I didn't know that even and odd
	    // number will be flipping evenly.

            
            Console.WriteLine("First 20 square numbers: ");
            for (int i = 0; i < 20; ++i )
            {
                if (obj.isEven(squares[i]))
                {
                    if (count_even == even.Length - 1){
                        obj.extendEvenArr();
                    }
                    even[++count_even] = squares[i];
                }
                else
                {
                    if (count_odd == odd.Length - 1) {
                        obj.extendOddArr();
                    }
                    odd[++count_odd] = squares[i];
                }
                Console.WriteLine(squares[i]);
            }
            Console.WriteLine("");

            //notice: when count_odd and count_even variables passed to the fucntion I add one hence they are reffering indeces
            Console.WriteLine("Amount of odd numbers is " + (count_odd + 1));
            Console.WriteLine("Amonut of even numbers is "+ (count_even + 1) + "\n");
            Console.WriteLine("Total produced by odd numbers: " + obj.sumOdd(odd, count_odd + 1));
            Console.WriteLine("Total produced by even numbers: " + obj.sumEven(even, count_even + 1) + "\n");
            Console.WriteLine("Average of odd numbers is "+(obj.sumOdd(odd, count_odd)/(count_odd + 1)));
            Console.WriteLine("Average of even numbers is " + (obj.sumEven(even, count_even) / (count_even + 1)) + "\n");
            Console.WriteLine("The Maximun odd number is "+ obj.getMaxOdd(odd, count_odd));
            Console.WriteLine("The Maximun even number is " + obj.getMaxEven(even, count_even));
            Console.ReadLine();
        }
        //gets the max odd number
        private int getMaxOdd(int []odd, int x) {
            int max = odd[x--];
            while (x >= 1) {
                if (max < odd[x]) { 
                    max = odd[x];
                }
                x--;
            }
            return max;
        }
        //gets the max even number
        private int getMaxEven(int[] even, int x)
        {
            int max = even[x--];
            while (x >= 1)
            {
                if (max < even[x])
                {
                    max = even[x];
                }
                x--;
            }
            return max;
        }
        //produces the sum of odd numbers
        private int sumOdd(int[] odds, int x)
        {
            int sum = 0;
            while (x >= 0){
                sum += odds[x--];
            }
            return sum;
        }

        //produces the sum of even numbers
        private int sumEven(int[] even, int x) {
            int sum = 0;
            while (x >= 0){
                sum += even[x--];
            }
            return sum;
        }

        //determines whether a number in array is even or not
        public bool isEven(int x) { return (x % 2 == 0);}

        //get the first 20 square numbers
        public int[] getSquares()
        {
            int[] n_squares = new int[20];
            for (int i = 1; i <= 20; ++i) 
            {
                n_squares[i-1] = i*i;
            }
            return n_squares;
        }
        private void extendEvenArr() { 
            int []newEvenArr = new int[even.Length * 2];
            for (int i = 0; i < even.Length; ++i) {
                newEvenArr[i] = even[i];
            }
            even = newEvenArr;
        }
        private void extendOddArr() { 
            int []newOddArr = new int[odd.Length * 2];
            for (int i = 0; i < odd.Length; ++i ) {
                newOddArr[i] = odd[i];
            }
            odd = newOddArr;
        }
    }
}
