using System;
#pragma warning disable

namespace Calculator
{
    class Program
    {
        static double Addition(double A, double B)
        {
            return A + B;
        }

        static double Substraction(double A, double B)
        {
            return A - B;
        }

        static double Muliplication(double A, double B)
        {
            return A * B;
        }

        static double Division(double A, double B)
        {
            return A / B;
        }

        static double RunInLoop(double num1)
        {
            double num2 = 0.0, iAns = 0.0;
            char ops = '\0';

            Console.WriteLine("Enter second number : ");
            num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the operation you want to perform : (+, -, *, /) ");
            ops = Console.ReadLine()[0];    // read only first character

            if (ops == '+')
            {
                iAns = Addition(num1, num2);
                Console.WriteLine($"Addition is : {iAns}");
            }
            else if (ops == '-')
            {
                iAns = Substraction(num1, num2);
                Console.WriteLine($"Substraction is : {iAns}");
            }
            else if (ops == '*')
            {
                iAns = Muliplication(num1, num2);
                Console.WriteLine($"Multiplication is : {iAns}");
            }
            else if (ops == '/')
            {
                if (num2 != 0)
                {
                    iAns = Division(num1, num2);
                    Console.WriteLine($"Division is : {iAns}");
                }
                else
                {
                    Console.WriteLine("Can not divide the number by 0");
                }
            }
            else
            {
                Console.WriteLine("Invalid Operation entered ...");
            }

            return iAns;
        }

        static string UserResponse()
        {
            string user_res = "";

            Console.WriteLine("Do you want to continue operations with the current answer : (yes/no) ");
            user_res = Console.ReadLine();

            return user_res;
        }

        static void Main(string[] args)
        {
            double num1 = 0.0;
            double iRet = 0.0;
            string user = "";

            Console.WriteLine("Enter first number : ");
            num1 = Convert.ToDouble(Console.ReadLine());

            iRet = RunInLoop(num1);
            user = UserResponse();

            while (user == "yes" || user == "y")
            {
                num1 = iRet;
                iRet = RunInLoop(num1);
                user = UserResponse();
            }

            Console.WriteLine("Thank you for using the application ...");
        }
    }
}