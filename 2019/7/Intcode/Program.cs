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
  Intcode path/to/program.txt

Solve for a specific output:
  Intcode solve 19690720 path/to/program.txt";

        static void Main(string[] args)
        {
            if (args.Length != 1 && args.Length != 3)
            {
                Console.WriteLine(Usage);
                return;
            }

            if (args[0] == "solve")
            {
                if (!int.TryParse(args[1], out var target))
                {
                    Console.WriteLine(Usage);
                    return;
                }

                var input = File.ReadAllText(args[2]);
                Console.WriteLine($"Input: {input}");
                var program = new IntcodeParser().Parse(input);

                var solved = false;
                for (var i = 0; i < 100 && !solved; i++)
                {
                    for (var j = 0; j < 100; j++)
                    {
                        Console.WriteLine($"Running with test values: {i} {j}");
                        var test = program.Copy();
                        test.Memory.Set(1, i);
                        test.Memory.Set(2, j);

                        test.Execute();

                        if (test.Memory.At(0) == target)
                        {
                            Console.WriteLine($"Inputs {test.Memory.At(1)} and {test.Memory.At(2)} produce output {target}");
                            solved = true;
                            break;
                        }
                    }
                }

                return;
            }

            if (File.Exists(args[0]))
            {
                ExecuteProgram(ParseInput(File.ReadAllText(args[0])));
                return;
            }

            ExecuteProgram(ParseInput(args[0]));
        }

        private static IntcodeProgram ParseInput(string input)
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
