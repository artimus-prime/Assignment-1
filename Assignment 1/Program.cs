using System;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 22;
            printSelfDividingNumbers(a, b);

            int n2 = 5;
            printSeries(n2);

            int n3 = 11;
            printTriangle(n3);

            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 1, 2, 2, 3, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);

            int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 5, 7, 8, 9, 10 };
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            printArray(r5);
            

            // Keep the console window open in debug mode.      
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                // loop through the range of numbers provided
                for ( int i = x; i <= y; i++ )
                {
                    // call the isSelfDivinding method and print the number if true is returned
                    if (isSelfDividing(i))
                        Console.Write(i + " ");
                }
                // write a new line at the end
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
        }

        // this is a method to determine if provided Integer is a self-dividing number (return bool)
        public static bool isSelfDividing(int num)
        {
            // define "flag" boolean variable, set to true by default
            bool selfdivisible = true;
            // define temp variable to help with getting digits of num, set equal to num
            int temp = num;
            // try-catch block
            try
            {
                // as long as temp is not zero - while loop through the digits of num
                while (temp != 0)
                {
                    // get the current most-right digit
                    int digit = temp % 10;
                    // if digit is zero or num is not divisible by this digit 
                    // then set flag to false and break out of while loop
                    if (digit == 0 || num % digit != 0)
                    {
                        selfdivisible = false;
                        break;
                    }
                    // otherwise, update temp and keep checking (flag remains true)
                    else
                    {
                        temp /= 10;
                    }
                }
                // method return selfdivisible flag value now
                return selfdivisible;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing isSelfDividing()");
                selfdivisible = false;
                return selfdivisible;
            }
        }

        public static void printSeries(int n)
        {
            // only positive integers are allowed
            if ( n < 0 )
            {
                Console.WriteLine("Only positive integers are accepted by printSeries(n)");
                return;
            }
            else
            {
                try
                {
                    // counter var to keep track of how many times we printed
                    int counter = 0;
                    // this is just an iterator used to print the right number
                    int i = 1;
                    // outer while loop to iterate until we print n times (break inside the loop)
                    while (true)
                    {
                        // now, inner loop will iterate from 1 to i and print i each time
                        for (int j = 1; j <= i; j++)
                        {
                            Console.Write(i + " ");
                            // increment counter
                            counter++;
                            // check if printed n times and need to break
                            if (counter == n)
                            {
                                // write a new line and return
                                Console.WriteLine();
                                return;
                            }
                        }
                        // increment i before next while loop iteration
                        i++;
                    }
                }
                catch
                {
                    Console.WriteLine("Exception occured while computing printSeries()");
                }
            }
        }

        public static void printTriangle(int n)
        {
            try
            {
                for ( int i = n; i >= 0; i-- )
                {
                    // for loop to print spaces to the left
                    // number of spaces needed on each line is total number of lines minus current line (starts from n and goes down)
                    for ( int j = (n-i) ; j > 0 ; j-- )
                        Console.Write(" ");
                    // for loop to print * symbols
                    // on each line need to print Current Line number times two plus one *
                    for ( int k = 0 ; k < (i*2+1) ; k++ )
                        Console.Write("*");

                    // print the new line char
                    Console.WriteLine("");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static int numJewelsInStones(int[] J, int[] S)
        {
            int count = 0;
            try
            {
                // check each element in J
                for  ( int i = 0; i < J.Length; i++ )
                {
                    // go through array S and check if this item is there as well
                    for ( int j = 0; j < S.Length; j++ )
                    {
                        if ( J[i] == S[j] )
                        {
                            // if item in J is in S then increment the count
                            count++;
                        }
                    }
                }

                return count;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
                return 0;
            }
        }

        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            int start = 0;
            int end = 0;

            try
            {
                // Write your code here
                for ( int i = 0; i < a.Length; i++ )
                {
                    for ( int j = 0; j < b.Length; j++ )
                    {
                        if ( a[i] == b[j] )
                        {
                            int temp_start = i;
                            int temp_end = i;
                            int c = 1;

                            while ( (i+c) < a.Length && (j+c) < b.Length && a[i + c] == b[j + c] )
                            {
                                temp_end = i + c;
                                c++;
                            }
                            // at the end revisit
                            if ( temp_end - temp_start >= end - start )
                            {
                                start = temp_start;
                                end = temp_end;
                            }
                        }
                    }
                }

                   
                // create subarray to return

                int[] subArray = new int[end-start+1];
                for ( int i = start, j = 0; i <= end; i++, j++ )
                {
                    subArray[j] = a[i];
                }

                return subArray;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
            }

            return null; // return the actual array
        }

        public static void printArray(int[] a)
        {
            try
            {
                Console.Write("[");
                for ( int i = 0; i < a.Length; i++ )
                {
                    if (i != a.Length - 1)
                        Console.Write(a[i] + ", ");
                    else
                        Console.Write(a[i]);
                }
                Console.WriteLine("]");
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printArray()");
            }
        }

        public static void solvePuzzle()
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
            }
        }
    }

}
