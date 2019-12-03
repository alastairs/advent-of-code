using System;
using System.IO;

namespace Intcode
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine(@"Usage:
Execute a program directly:
  Intcode ""1,0,0,0,99""

Execute a file from input:
  Intcode path/to/program.txt");
                return;
            }

            if (File.Exists(args[0]))
            {
                RunForInput(File.ReadAllText(args[0]));
                return;
            }

            RunForInput(args[0]);
        }

        private static void RunForInput(string input)
        {
            Console.WriteLine($"Input: {input}");

            var parser = new IntcodeParser();
            var program = parser.Parse(input);
            Console.WriteLine($"Output: {program.Execute()}");
        }
    }
}
