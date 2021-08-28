
using System;
using System.Linq;
using System.Text;
using Enigma.Rotors;

namespace Enigma.Machine
{
    public class ScramblerUnit
    {
        public IEntryDisk EntryDisk;
        public ICipherWheel FastRotor;
        public ICipherWheel MediumRotor;
        public ICipherWheel SlowRotor;
        public IReflector Reflector;

        public ScramblerUnit(WheelOrder wheelOrder)
        {
            EntryDisk = wheelOrder.EntryDisk;
            SlowRotor = wheelOrder.Slow;
            MediumRotor = wheelOrder.Medium;
            FastRotor = wheelOrder.Fast;
            Reflector = wheelOrder.Reflector;

            FastRotor.StepNext += MediumStep;
            MediumRotor.StepNext += SlowStep;
        }

        public char Encipher(char letter)
        {
            FastStep();
            
            var position = letter.ToInt();
            Console.WriteLine(Explain(EntryDisk, position));
            position = EntryDisk.RightToLeft(position);

            Console.WriteLine(Explain(FastRotor, position));
            position = FastRotor.RightToLeft(position);

            Console.WriteLine(Explain(MediumRotor, position));
            position = MediumRotor.RightToLeft(position);

            Console.WriteLine(Explain(SlowRotor, position));
            position = SlowRotor.RightToLeft(position);

            Console.WriteLine(Explain(Reflector, position));
            position = Reflector.RightToLeft(position);

            Console.WriteLine(Explain(SlowRotor, position, true));
            position = SlowRotor.LeftToRight(position);

            Console.WriteLine(Explain(MediumRotor, position, true));
            position = MediumRotor.LeftToRight(position);

            Console.WriteLine(Explain(FastRotor, position, true));
            position = FastRotor.LeftToRight(position);

            Console.WriteLine(Explain(EntryDisk, position, true));
            position = EntryDisk.LeftToRight(position);

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