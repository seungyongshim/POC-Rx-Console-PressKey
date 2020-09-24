using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Rx_Console_PressKey_POC
{


    class Program
    {
        static void Main(string[] args)
        {
            var keys = KeyPresses().ToObservable();

            keys.Throttle(TimeSpan.FromMilliseconds(100))
                .Subscribe(key => Console.WriteLine("Pressed: {0}", key.Key));


        }

        static IEnumerable<ConsoleKeyInfo> KeyPresses()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
                yield return key;
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
