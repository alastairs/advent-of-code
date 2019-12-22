using System;
using System.IO;

namespace Intcode
{
    class Program
    {
        private const string Usage = @"Usage:
Execute a program directly:
  Intcode ""1,0,0,0,99""

Execute a file from input:
  Intcode path/to/program.txt";

        static void Main(string[] args)
        {
            if (args.Length != 1 && args.Length != 3)
            {
                Console.WriteLine(Usage);
                return;
            }

            if (File.Exists(args[0]))
            {
                ExecuteProgram(ParseProgram(File.ReadAllText(args[0])));
                return;
            }

            ExecuteProgram(ParseProgram(args[0]));
        }

        private static IntcodeProgram ParseProgram(string input)
        {
            Console.WriteLine($"Input: {input}");

            var parser = new IntcodeParser();
            return parser.Parse(input);
        }

        private static void ExecuteProgram(IntcodeProgram program)
        {
            program.Execute();
            Console.WriteLine($"Result: {program.Memory.At(0)}");
        }
    }
}
