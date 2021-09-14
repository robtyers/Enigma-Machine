
using System;
using System.Linq;
using System.Text;
using Enigma.Rotors;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Enigma.Machine.EnigmaB
{
    public class ScramblerUnit : IScramblerUnit
    {
        public string ModelNumber { get; }
        readonly RotorSettings _rotorSettings;
        readonly ILogger<ScramblerUnit> _logger;
        public IEntryDisk EntryDisk { get; }
        public ICipherWheel FastRotor { get; }
        public ICipherWheel MediumRotor { get; }
        public ICipherWheel SlowRotor { get; }
        public IReflector Reflector { get; }

        public ScramblerUnit(IOptions<RotorSettings> rotorSettings, ILogger<ScramblerUnit> logger, IRotorFactory rotorFactory)
        {
            ModelNumber = "A27";

            _rotorSettings = rotorSettings.Value;
            _logger = logger;

            EntryDisk = rotorFactory.GetEntryDisk;
            Reflector = rotorFactory.GetReflector;
            SlowRotor = rotorFactory.Rotors.Single(r => r.RotorNumber == _rotorSettings.SlowRotor);
            MediumRotor = rotorFactory.Rotors.Single(r => r.RotorNumber == _rotorSettings.MediumRotor);
            FastRotor = rotorFactory.Rotors.Single(r => r.RotorNumber == _rotorSettings.FastRotor);

            FastRotor.StepNext += MediumStep;
            MediumRotor.StepNext += SlowStep;
        }

        public char Encipher(char letter)
        {
            var sb = new StringBuilder();

            FastStep();

            var position = letter.ToInt();
            sb.AppendLine(Explain(EntryDisk, position));
            position = EntryDisk.RightToLeft(position);

            sb.AppendLine(Explain(FastRotor, position));
            position = FastRotor.RightToLeft(position);

            sb.AppendLine(Explain(MediumRotor, position));
            position = MediumRotor.RightToLeft(position);

            sb.AppendLine(Explain(SlowRotor, position));
            position = SlowRotor.RightToLeft(position);

            sb.AppendLine(Explain(Reflector, position));
            position = Reflector.RightToLeft(position);

            sb.AppendLine(Explain(SlowRotor, position, true));
            position = SlowRotor.LeftToRight(position);

            sb.AppendLine(Explain(MediumRotor, position, true));
            position = MediumRotor.LeftToRight(position);

            sb.AppendLine(Explain(FastRotor, position, true));
            position = FastRotor.LeftToRight(position);

            sb.AppendLine(Explain(EntryDisk, position, true));
            position = EntryDisk.LeftToRight(position);

            _logger.LogDebug(sb.ToString());

            return position.ToChar();
        }

        string Explain(IRotor rotor, int position, bool inverse = false)
        {
            var sb = new StringBuilder();
            var i = 0;

            switch(inverse)
            {
                case true:
                    foreach(var letter in rotor.LetterRing)
                    {
                        sb.Append(i == position ? $"({letter.Right.ToString()})" : letter.Right.ToString());
                        i++;
                    }
                    break;

                case false:
                    foreach(var letter in rotor.LetterRing)
                    {
                        sb.Append(i == position ? $"({letter.Left.ToString()})" : letter.Left.ToString());
                        i++;
                    }
                    break;
            }

            return $"{sb.ToString()}\t{rotor.RotorNumber}\t{position}";
        }

        void FastStep()
        {
            FastRotor.Step();
        }

        void MediumStep(object sender, EventArgs e)
        {
            MediumRotor.Step();
            FastRotor.Step(false); // double step
        }

        void SlowStep(object sender, EventArgs e)
        {
            SlowRotor.Step();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append($"{EntryDisk.LetterRing[0].Value}\t{EntryDisk.RotorNumber}\n");
            result.Append($"{FastRotor.LetterRing[0].Value}\t{FastRotor.RotorNumber}\n");
            result.Append($"{MediumRotor.LetterRing[0].Value}\t{MediumRotor.RotorNumber}\n");
            result.Append($"{SlowRotor.LetterRing[0].Value}\t{SlowRotor.RotorNumber}\n");
            result.Append($"{Reflector.LetterRing[0].Value}\t{Reflector.RotorNumber}\n");

            return result.ToString();
        }
    }
}