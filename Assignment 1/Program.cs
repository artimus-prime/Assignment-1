using System;
using System.Collections.Generic;

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

            int n3 = 5;
            printTriangle(n3);

            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);

            int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 5, 7, 8, 9, 10 };
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            printArray(r5);

            solvePuzzle();

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
                    // call the isSelfDivinding() method and print the number if true is returned
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
            // define temp variable to help with getting digits of num, at the beginning set equal to num
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
                // method returns selfdivisible flag value now
                return selfdivisible;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing isSelfDividing()");
                // return false
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
                    // outer while loop to iterate until we print n times (return is inside the loop)
                    while (true)
                    {
                        // now, inner loop will iterate from 1 to i and print i each time
                        for (int j = 1; j <= i; j++)
                        {
                            // print the number to the screen
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
                // Triangle has to have n lines. loop from n to 0 (start with the longest line of * chars)
                for ( int i = n; i >= 0; i-- )
                {
                    // this for loop is to print spaces to the left
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
            // variable to keep count of how many Jewels are found in the set of Stones
            int count = 0;
            try
            {
                // check each element in J (jewels array)
                for  ( int i = 0; i < J.Length; i++ )
                {
                    // go through array S (stones array) and check if this item is there as well
                    for ( int j = 0; j < S.Length; j++ )
                    {
                        // if item in J is in S then increment the count
                        if ( J[i] == S[j] )
                            count++;
                    }
                }
                // at the end, return the count of Jewels
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
            // define two variables, to keep track of indexes of the largest subarray
            // note that we will keep track of where the subarray starts and ends in input array a
            int start = 0;
            int end = 0;

            try
            {
                // outer for loop is to iterate through the first array - a
                for ( int i = 0; i < a.Length; i++ )
                {
                    // inner loop iterates through the second array - b
                    for ( int j = 0; j < b.Length; j++ )
                    {
                        // check if value in a matches corresponding value in b
                        if ( a[i] == b[j] )
                        {
                            // temp variables - in case there was a match, start keeping track of where the subarray starts and ends.
                            int temp_start = i;
                            int temp_end = i;
                            // c is the counter var to keep track of how many values have matches for the current subarray
                            int c = 1;
                            // loop through the values at indexes that follow the matched ones (a[i + c] == b[j + c])
                            // also, make sure that indexes don't go out of bounds
                            while ( (i+c) < a.Length && (j+c) < b.Length && a[i + c] == b[j + c] )
                            {
                                // if the next values match as well then update temp end index value and increment counter
                                temp_end = i + c;
                                c++;
                            }
                            // after the series of matches ended
                            // check if its length is greater or equal the length the previous subarray at start and end indexes
                            if ( temp_end - temp_start >= end - start )
                            {
                                // if that's the case then update start and end indexes
                                start = temp_start;
                                end = temp_end;
                            }
                        }
                    }
                }
                   
                // create subarray to return, it's length defined by start and end indexes
                int[] subArray = new int[end-start+1];
                // populate values 
                for ( int i = start, j = 0; i <= end; i++, j++ )
                {
                    subArray[j] = a[i];
                }
                // return
                return subArray;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
                return null;
            }
        }

        // this method takes in Integer array and nicely prints it out...
        public static void printArray(int[] a)
        {
            try
            {
                // open square bracket - aka array start
                Console.Write("[");
                // go through the array and print its values
                for ( int i = 0; i < a.Length; i++ )
                {
                    // print a comma and a space for each element except the last one
                    if (i != a.Length - 1)
                        Console.Write(a[i] + ", ");
                    else
                        Console.Write(a[i]);
                }
                // close square bracket - aka array end
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
                // number of solutions found (to be updated later if solution(s) is/are found)
                int solutionCount = 0;

                // call method to get user input - it will be stored as IList 
                // create IList var and let method populate it
                IList<string> puzzleInput = getPuzzleInput();

                // next step is to analyze the input strings and get all unique chars from them
                // create IList var to store the unique chars and call the method to populate it
                IList<char> uniqueChars = identifyUniqueChars(puzzleInput);

                // now let's set up a Dictionary to keep track of Char -> Digit assignments
                // I'm using Unsigned Long instead of Int in order to minimize the number of times I need to cast to ulong
                Dictionary<char, ulong> puzzleDictionary = new Dictionary<char, ulong>();

                // here we initialize Dictionary - set each char value to 0 at first
                for (int j = 0; j < uniqueChars.Count; j++)
                    puzzleDictionary[uniqueChars[j]] = 0;

                // need to try all possible digit assignment to the list of Unique Chars
                // I'm using a for loop to loof from zero to 10 to the power of (Number of Unique Chars)
                // this is the approach I use to iterate through all possible digit assignments
                // it's not flawless since Ulong (Unsigned 64-bit integer) is capped at 18,446,744,073,709,551,615 
                // meaning that this code can brute force up to 19 Unique Chars. That's why I check the number of Unique Chars (stop if too many)

                if (uniqueChars.Count > 19)
                {
                    Console.WriteLine("solvePuzzle() cannot brute force more than 19 Unique Chars...  :(");
                    return;
                }
                else
                {
                    // loop from 0 to 10 to the power of (Number of Unique Chars)
                    for (ulong i = 0; i < (ulong)Math.Pow(10, uniqueChars.Count); i++)
                    {
                        // try to solve the puzzle using current dictionary

                        // update dictionary
                        updatePuzzleDictionary(ref puzzleDictionary, uniqueChars, i);

                        // attempt to solve the puzzle given this dictionary, call isPuzzleSolved that will return true/false
                        if ( isPuzzleSolved(puzzleDictionary, uniqueChars, puzzleInput) )
                        {
                            // if problem was solved then isPuzzleSolved already printed out the solution
                            // just increment the solution count
                            solutionCount++;
                        }

                    }
                }

                // at the very end, print how many solutions were found (if any)
                if (solutionCount == 0)
                    Console.WriteLine("This puzzle has no solutions!");
                else
                    Console.WriteLine("This puzzle has " + solutionCount + " solutions!");
            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
            }
        }

        // this method actually attempts to solve the puzzle for the given input using current dictionary of char => digit assignments
        // it will return true and print the char => digit assignments that solve the puzzle, otherwise it returns false
        public static bool isPuzzleSolved(Dictionary<char, ulong> puzzleDictionary, IList<char> uniqueChars, IList<string> puzzleInput)
        {
            try
            {
                // there's three strings that need to be converted to number and then we test if str1 + str2 = str3
                // initialize three ulong variables and set to 0
                ulong str1 = 0, str2 = 0, str3 = 0;

                // convert each puzzle input string to a number based on Dictionary digit assignments
                // use counter to keep track of which string is being handled - start with str1
                int counter = 1;
                foreach ( string str in puzzleInput )
                {
                    // this boolean var (false by default) is to check if anhy string has a leading 0 (reject such solution)
                    bool leadingZeroDetected = false;
                    // convert this string to char array
                    char[] stringChars = str.ToCharArray();
                    // temp var to assist with calculations (0 at the beginning)
                    ulong temp = 0;
                    // iterate through characters of this string and convert it to a number
                    for (int k = 0; k < stringChars.Length; k++)
                    {
                        // need to make sure that leading character is not zero for strings longer than 1 char
                        if (k == 0 && stringChars.Length > 1 && puzzleDictionary[stringChars[k]] == 0)
                            leadingZeroDetected = true;

                        temp += puzzleDictionary[stringChars[k]] * (ulong)Math.Pow(10, stringChars.Length - 1 - k);
                    }

                    // if this string has a leading zero then puzzle is not solved - you can return false now
                    if (leadingZeroDetected)
                        return false;

                    // assign value now
                    if (counter == 1)
                        str1 = temp;
                    else if (counter == 2)
                        str2 = temp;
                    else
                        str3 = temp;

                    // update counter here
                    counter++;
                }

                // now if code execution reached here, test if str1 + str2 = str3
                if ( str1 + str2 == str3 )
                {
                    // we found a solution!
                    // print current dictionary
                    foreach (KeyValuePair<char, ulong> item in puzzleDictionary)
                        Console.Write("Key: {0} => Value: {1}; ", item.Key, item.Value);
                    Console.WriteLine();
                    // also print the sum that worked
                    Console.WriteLine(str1 + " + " + str2 + " = " + str3);

                    // return true - puzzle was solved!
                    return true;
                }
                else
                {
                    // puzzle not solved - return false
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing isPuzzleSolved()");
                return false;
            }

            

            
        }

        // this method update puzzle dictionary using a number to generate char => digit assignments
        // uniqueChars List is used to reference indexes in the dictionary
        public static void updatePuzzleDictionary(ref Dictionary<char, ulong> puzzleDictionary, IList<char> uniqueChars, ulong number)
        {
            try
            {
                // use temp var - set to ulong number passed to this method
                ulong temp = number;
                for (int j = 0; j < uniqueChars.Count; j++)
                {
                    // get the right-most digit of temp
                    puzzleDictionary[uniqueChars[j]] = temp % 10;
                    // divide temp by ten to get to the next digit
                    // it also makes sure that 0 is assigned if there's not enough digits for all chars in the number yet
                    temp /= 10;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing updatePuzzleDictionary()");
            }
        }

        // this method takes in a List with input strings, identifies unique chars, and returns the List with these chars
        public static IList<char> identifyUniqueChars(IList<string> inputStrings)
        {
            try
            {
                // create a List of chars to gather all unique chars from the input strings
                IList<char> uniqueChars = new List<char>();
                // go through the List of input strings and identify Unique Characters:
                foreach (string str in inputStrings)
                {
                    // temp array to hold chars of this string
                    char[] tempArray = str.ToCharArray();
                    // loop through the chars and add to the Unique Char List if it's not there yet
                    foreach (char ch in tempArray)
                    {
                        if (!uniqueChars.Contains(ch))
                            uniqueChars.Add(ch);
                    }
                }
                // after scanning through the input - return Unique Chars list
                return uniqueChars;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing identifyUniqueChars()");
                return null;
            }
        }

        // this method gets input strings from the user and returns them as List
        // to keep things uniform - all string will be converted to lower case
        public static IList<string> getPuzzleInput()
        {
            try
            {
                Console.WriteLine("Let's solve an uber-cool puzzle now!");
                // initiate the list of strings that will be returned 
                IList<string> inputStrings = new List<string>();
                // temp var to hold user's input
                string temp = "";
                // prompt user to enter first string, then read it and add to the List - make sure it's not blank
                do
                {
                    Console.Write("Enter First String: ");
                    temp = Console.ReadLine().ToLower();
                    inputStrings.Add(Convert.ToString(temp));
                } while (temp.Length == 0);
                // prompt user to enter second string, then read it and add to the List - make sure it's not blank
                do
                {
                    Console.Write("Enter Second String: ");
                    temp = Console.ReadLine().ToLower();
                    inputStrings.Add(Convert.ToString(temp));
                } while (temp.Length == 0);
                // prompt user to enter third string, then read it and add to the List - make sure it's not blank
                do
                {
                    Console.Write("Enter Result String: ");
                    temp = Console.ReadLine().ToLower();
                    inputStrings.Add(Convert.ToString(temp));
                } while (temp.Length == 0);
                // return the list of strings
                return inputStrings;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getPuzzleInput()");
                return null;
            }
        }
    }
}
