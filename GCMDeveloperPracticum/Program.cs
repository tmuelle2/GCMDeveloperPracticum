using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMDeveloperPracticum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("Input  -  meal, x...  -  where meal is morning or night and x is comma delimited list of dishes (1-4)");
            Console.WriteLine("Input  -   exit  -  to exit the program");
            Console.WriteLine();

            var input = "";
            while(input != "exit") 
            {
                Console.WriteLine();
                Console.Write("Input: ");
                input = Console.ReadLine();
                try
                {
                    var meal = new Meal(input);
                    Console.WriteLine("Output: " + meal.ToString());
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Output: " + ex.Message);
                }
            }               
        }
    }
}
