using System;
using System.IO;

namespace Brainfuck {


    class Program {
        static void Main(string[] args) {
            var code = File.ReadAllText("C:\\bottles.txt");
            Console.WriteLine(code);
            var interpreter = new Interpreter(code);
            interpreter.Run();
        }
    }
}