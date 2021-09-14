using System;
using System.Text;
using System.Text.RegularExpressions;
using Enigma.Machine;
using Enigma.Rotors;
using Microsoft.Extensions.Logging;

namespace Enigma
{
    public class ConsoleApplication
    {
        readonly IScramblerUnit _scramblerUnit;
        readonly ILogger<ConsoleApplication> _logger;

        public ConsoleApplication(ILogger<ConsoleApplication> logger, IRotorFactory rotorFactory, IScramblerUnit scramblerUnit)
        {
            _logger = logger;
            _scramblerUnit = scramblerUnit;
        }

        public void Run()
        {
            try
            {
                var slowOffset = GetRingSetting("Slow");
                var slowPosition = GetStartPosition("Slow");
                _scramblerUnit.SlowRotor.Initialise(slowOffset, slowPosition);

                var mediumOffset = GetRingSetting("Medium");
                var mediumPosition = GetStartPosition("Medium");
                _scramblerUnit.MediumRotor.Initialise(mediumOffset, mediumPosition);

                var fastOffset = GetRingSetting("Fast");
                var fastPosition = GetStartPosition("Fast");
                _scramblerUnit.FastRotor.Initialise(fastOffset, fastPosition);
                
                _logger.LogDebug(_scramblerUnit.ToString());
                
                var cipherText = new StringBuilder();
                while(true)
                {
                    var clearText = ReadClearText();
                    var substitute = _scramblerUnit.Encipher(clearText);
                    
                    _logger.LogDebug(_scramblerUnit.ToString());

                    // Separate ciphertext into blocks of five chars
                    cipherText.Append(substitute);
                    Console.WriteLine(Regex.Replace(cipherText.ToString(), ".{5}", "$0 "));
                }   
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }

        static char ReadClearText()
        {
            Console.Write("Input: ");
            var clearText = Console.ReadKey().KeyChar;

            if(!char.IsLetter(clearText))
                throw new ArgumentOutOfRangeException("Text must be A-Z");

            Console.WriteLine();
            return char.ToUpper(clearText);
        }

        static int GetRingSetting(string rotorName)
        {
            Console.Write($"{rotorName} Ring Setting [1-26]: ");
            var rotorOffset = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();

            if(rotorOffset < 1 || rotorOffset > 26)
                throw new ArgumentOutOfRangeException("Offset must be between 1 and 26");

            return rotorOffset;
        }

        static char GetStartPosition(string rotorName)
        {
            Console.Write($"{rotorName} Start Position [A-Z]: ");
            var position = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if(position < 65 || position > 90)
                throw new ArgumentOutOfRangeException("Position must be between A and Z");

            return position;
        }
    }
}