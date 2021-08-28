using System;
using System.Text;
using System.Text.RegularExpressions;
using Enigma.Machine;
using Enigma.Rotors.EnigmaI;

namespace Enigma
{
    class Program
    {
        static ScramblerUnit _scramblerUnit;

        static void Main(string[] args)
        {
            var entryWheel = new ETW();

            var slowOffset = GetRingSetting("Slow");
            var slowPosition = GetStartPosition("Slow");
            var slowRotor = new I(slowOffset);
            slowRotor.StartPosition(slowPosition);

            var mediumOffset = GetRingSetting("Medium");
            var mediumRotor = new II(mediumOffset);
            var mediumPosition = GetStartPosition("Medium");
            mediumRotor.StartPosition(mediumPosition);

            var fastOffset = GetRingSetting("Fast");
            var fastRotor = new III(fastOffset);
            var fastPosition = GetStartPosition("Fast");
            fastRotor.StartPosition(fastPosition);

            var reflector = new ReflectorB();//UKW();

            var wheelOrder = new WheelOrder(
                    entryWheel, 
                    slowRotor, 
                    mediumRotor, 
                    fastRotor, 
                    reflector);
                    
            _scramblerUnit = new ScramblerUnit(wheelOrder);
            
            WriteLine(_scramblerUnit.ToString());

            var cipherText = new StringBuilder();
            while(true)
            {
                var clearText = ReadClearText();
                var substitute = _scramblerUnit.Encipher(clearText);
                cipherText.Append(substitute);

                WriteLine(_scramblerUnit.ToString());
                WriteCipher(cipherText.ToString());
            }
        }

        static char ReadClearText()
        {
            Write("Input: ");
            var clearText = Console.ReadKey().KeyChar;
                if(!char.IsLetter(clearText))
                    throw new ArgumentOutOfRangeException("Text must be A-Z");

            Console.WriteLine();
            return char.ToUpper(clearText);
        }

        static int GetRingSetting(string rotorName)
        {
            Write($"{rotorName} Ring Setting [1-26]: ");
            var rotorOffset = int.Parse(Console.ReadKey().KeyChar.ToString());
            WriteLine(string.Empty);

            if(rotorOffset < 1 || rotorOffset > 26)
                throw new ArgumentOutOfRangeException("Offset must be between 1 and 26");

            return rotorOffset;
        }

        static char GetStartPosition(string rotorName)
        {
            Write($"{rotorName} Start Position [A-Z]: ");
            var position = char.ToUpper(Console.ReadKey().KeyChar);
            WriteLine(string.Empty);

            if(position < 65 || position > 90)
                throw new ArgumentOutOfRangeException("Position must be between A and Z");

            return position;
        }

        static void Write(string message)
        {
            Console.Write(message);
        }

        static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
        static void WriteCipher(string cipherText)
        {
            Console.WriteLine(Regex.Replace(cipherText, ".{5}", "$0 "));
        }
    }
}
