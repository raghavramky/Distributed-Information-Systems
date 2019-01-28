using System;

namespace Assignment1_S19
{
    class Program
    {
        public static void Main()
        {
            int a = 5, b = 15;
            Console.Write("The Prime numbers between " + a + " and " + b + " are : ");
            printPrimeNumbers(a, b);
            Console.Write("\n" + "\n");
            
            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("The sum of the series is: " + r1);
            Console.Write("\n");

            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);
            Console.Write("\n");
            
            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);
            Console.Write("\n");

            int n4 = 5;            
            Console.Write("A Triangle for " + n4 + " lines is displayed below :" +"\n");
            Console.Write("\n");

            printTriangle(n4);
            
            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);

            Console.WriteLine(" End of Output, Press Enter to Exit :)");
            Console.ReadKey();

            //################################################################################
            // Learnt a lot with Visual Studio on how to create a breakpoint for a program,  #
            // how to check the values of the variable during the runtime of the program.    #
            // With a coding background in Python programming I always had a missconception  #
            // that IDE's are a ram hoggers, but this was really useful interms of debugging #
            //################################################################################
        }

        public static void printPrimeNumbers(int x, int y)
        {
            // Variables in the scope of this method
            int i ,j;
            bool isPrime = true;
            
            try
            {
                for (i = x; i <= y; i++)
                {
                    for (j = 2; j <= y; j++)
                    {
                        if (i != j && i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                       
                        Console.Write(i + ", ");
                    }
                    isPrime = true;
                }                       
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }
        }

        public static double getSeriesResult(int n)
        {
            try
            {
                // Variables in the scope of this method
                int i; 
                double x, sum; // declaring the term and the sum of the series
                x = 1; // initializing the 1st term
                sum = 0; //initial sum of the series is 0
                for (i = 1; i <= n; i++)
                {
                    double tmp = (get_factorial(i)) * x;
                    sum += tmp / (i + 1);
                    x = x * (-1);
                }
                return Math.Round(sum, 2);
            }
            
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }

            return 0;
        }

        public static int get_factorial(int n)
        {
            int result = n;

            for (int i = 1; i < n; i++)
            {
                result = result * i;
            }
            return result;
        }

        public static long decimalToBinary(long n)
        {
            try
            {
                long remainder;
                string output = "";

                while(n > 0)
                {
                    remainder = n % 2;
                    n = n / 2;
                    output = remainder.ToString() + output;
                }
                return Convert.ToInt64(output);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }

            return 0;
        }
        
        public static long binaryToDecimal(long n)
        {
            try
            {
                //Variables in the scope of this method
                string x = n.ToString();
                int len = x.Length;
                //Console.Write(len);
                double sum = 0;
                double unit;

                for(int i = 0; i < len; i++)
                {
                    unit = get_power(2, i);
                    sum = sum + unit;
                }

                return Convert.ToInt64(sum);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }

            return 0;
        }

        public static int get_power(int x, int y)
        {
            int temp;
            if (y == 0)
            {
                return 1; // return 1 if raised to the power 0
            }
            temp = get_power(x, y / 2);
            if (y % 2 == 0) //stop when remainder is 0
            {
                return temp * temp;
            }
            else
            {
                return x * temp * temp;
            }
        }

    public static void printTriangle(int n)
        {
            try
            {   
                //Variables in the scope of this method
                int i, j, k;
                int s = n - 1; //spaces

                for (i = 1; i <= n; i++) //Loop for the line
                {
                    //loop for the space, start from (n-1) and gradually decrease one per line
                    for (s = 1; s <= (n - i); s++) 
                    {
                        Console.Write(" ");
                    }

                    //loop for the 1st set of stars's
                    for (j = 1; j <= i; j++) 
                    {
                        Console.Write("*");
                    }

                    //loop for the 2nd set of star's
                    for (k = (i - 1); k >= 1; k--) 
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine(" ");
                }
                Console.WriteLine("\n");
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }
        
        public static void computeFrequency(int[] a)
        {
            try
            {   //int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
                //Variables in the scope of this method
                int i, j, k, counter;
                int length = a.Length;
                int []element = new int[length];
                int []frequency = new int[length];

                for (i = 0; i < length; i++)
                {
                    element[i] = a[i];
                    frequency[i] = -1;
                }

                //Loop for every element in the array
                for (i = 0; i < length; i++)
                {
                    counter = 1; //Fush counter for every element  
                    for (j = i + 1; j < length; j++)
                    {
                        
                        int x = a[i];
                        int y = a[j];
                        if (x == y)
                        {
                            counter++;
                            frequency[j] = 0;
                        }
                    }
                    if(frequency[i] != 0)
                    {
                        frequency[i] = counter;
                    }
                }
                Console.Write("Number" + "\t" + "Frequency" + "\n");
                Console.Write("-------" + "\t" + "---------" + "\n");
                for (k = 0; k < length; k++)
                {
                    if(frequency[k] != 1 )
                    {
                        Console.Write(element[k] + "\t" + frequency[k] + "\n");
                    }  
                }
                Console.Write("\n");
            }
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }
        
    }
}
