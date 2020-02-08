using System;
using System.Collections.Generic;

namespace Brainfuck {
    public class Interpreter {
        private readonly string _code;
        private readonly byte[] _array;
        private int _pointer;
        private int _stringPointer;

        private readonly Stack<int> _whileStack;

        public Interpreter(string code) {
            _code = code;
            _array = new byte[100000];
            _pointer = 0;
            _stringPointer = 0;
            _whileStack = new Stack<int>();
        }

        public void Run() {
            while (_code.Length > _stringPointer) {
                var c = _code[_stringPointer];
                
                _stringPointer++;

                switch (c) {
                    case '>':
                        _pointer++;
                        if (_pointer == _array.Length)
                            _pointer = 0;
                        break;
                    case '<':
                        _pointer--;
                        if (_pointer < 0)
                            _pointer = _array.Length - 1;
                        break;
                    case '+':
                        _array[_pointer]++;
                        break;
                    case '-':
                        _array[_pointer]--;
                        break;
                    case '.':
                        Console.Write((char) _array[_pointer]);
                        break;
                    case ',':
                        int r;
                        do {
                            r = Console.Read();
                        } while (r < 32 && r != 13);
                        _array[_pointer] = (byte) r;
                        break;
                    case '[':
                        if (_array[_pointer] == 0) {
                            var counter = 1;
                            while (counter > 0 && _stringPointer < _code.Length) {
                                c = _code[_stringPointer];
                                if (c == '[')
                                    counter++;
                                else if (c == ']')
                                    counter--;
                                _stringPointer++;
                            }
                        }
                        else _whileStack.Push(_stringPointer - 1);

                        break;
                    case ']':
                        _stringPointer = _whileStack.Pop();
                        break;
                }
            }
        }
    }
}