// -----------------------------------------------------------------------
// <copyright company="Web Illumination Ltd." file="Program.cs">
//     Web Illumination Ltd. All rights reserved.
// </copyright>
// <author>
//      Adam Stacey, Solution Architect
//      me@adamstacey.co.uk
// </author>
// -----------------------------------------------------------------------
namespace AdamStacey.DemoCalculator
{
    #region Usings
    using System;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Test program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator!");

            RunCalculation();
        }

        /// <summary>
        /// Runs the calculation.
        /// </summary>
        static void RunCalculation()
        {
            CalculatorRepository calculatorRepository = new CalculatorRepository("http://www.dneonline.com/calculator.asmx", 1000);

            Console.WriteLine("#####################################");
            Console.WriteLine("What calculation would you like to perform:");
            Console.WriteLine("  1. Addition");
            Console.WriteLine("  2. Subtraction");
            Console.WriteLine("  3. Multiplication");
            Console.WriteLine("  4. Division");

            Console.WriteLine("Enter the number of your decision:");
            int decision = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your first number:");
            int intA = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your second number:");
            int intB = Convert.ToInt32(Console.ReadLine());

            Task<int> calculation;

            switch (decision)
            {
                case 1:
                    calculation = calculatorRepository.AddAsync(intA, intB);
                    calculation.Wait();
                    Console.WriteLine($"{intA} + {intB} = {calculation.Result}");
                    break;

                case 2:
                    calculation = calculatorRepository.SubtractAsync(intA, intB);
                    calculation.Wait();
                    Console.WriteLine($"{intA} - {intB} = {calculation.Result}");
                    break;

                case 3:
                    calculation = calculatorRepository.MultiplyAsync(intA, intB);
                    calculation.Wait();
                    Console.WriteLine($"{intA} × {intB} = {calculation.Result}");
                    break;

                case 4:
                    if (intB == 0)
                    {
                        Console.WriteLine("Error: You cannot divide a number by 0!");
                    }
                    else
                    {
                        calculation = calculatorRepository.DivideAsync(intA, intB);
                        calculation.Wait();
                        Console.WriteLine($"{intA} ÷ {intB} = {calculation.Result}");
                    }

                    break;

                default:
                    Console.WriteLine("Error: You must enter a number between 1 and 4!");
                    break;
            }

            Console.WriteLine("Would you like to do another calculation? Enter Y for yes and anything else for no:");

            if (Console.ReadLine() == "Y")
            {
                RunCalculation();
            }
            else
            {
                Console.WriteLine("#####################################");
                Console.WriteLine("Thank you for using the calculator!");
            }
        }
    }
}