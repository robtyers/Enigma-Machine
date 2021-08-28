

using System.Linq;
using System.Text;

namespace Enigma.Rotors
{
    public abstract class Rotor : IRotor
    {
        public string RotorNumber { get; protected set; }

        public LetterRing LetterRing { get; }


        public Rotor()
        {
            LetterRing = new LetterRing();

            LetterRing.Add(new Letter('A'));
            LetterRing.Add(new Letter('B'));
            LetterRing.Add(new Letter('C'));
            LetterRing.Add(new Letter('D'));
            LetterRing.Add(new Letter('E'));
            LetterRing.Add(new Letter('F'));
            LetterRing.Add(new Letter('G'));
            LetterRing.Add(new Letter('H'));
            LetterRing.Add(new Letter('I'));
            LetterRing.Add(new Letter('J'));
            LetterRing.Add(new Letter('K'));
            LetterRing.Add(new Letter('L'));
            LetterRing.Add(new Letter('M'));
            LetterRing.Add(new Letter('N'));
            LetterRing.Add(new Letter('O'));
            LetterRing.Add(new Letter('P'));
            LetterRing.Add(new Letter('Q'));
            LetterRing.Add(new Letter('R'));
            LetterRing.Add(new Letter('S'));
            LetterRing.Add(new Letter('T'));
            LetterRing.Add(new Letter('U'));
            LetterRing.Add(new Letter('V'));
            LetterRing.Add(new Letter('W'));
            LetterRing.Add(new Letter('X'));
            LetterRing.Add(new Letter('Y'));
            LetterRing.Add(new Letter('Z'));
        }

        protected void Substitute(char right, char left)
        {
            LetterRing.Single(l => l.Value == right).Left = left;
            LetterRing.Single(l => l.Value == left).Right = right;
            LetterRing.Single(l => l.Value == right).RightToLeft = left.ToInt() - right.ToInt();
            LetterRing.Single(l => l.Value == left).LeftToRight = right.ToInt() - left.ToInt();
        }

        public int RightToLeft(int position) 
        {
            var offset = LetterRing[position].RightToLeft;
            var newPosition = ToPosition(position + offset);

            return newPosition;
        }

        public int LeftToRight(int position) 
        {
            var offset = LetterRing[position].LeftToRight;
            var newPosition = ToPosition(position + offset);

            return newPosition;
        }

        int ToPosition(int position)
        {
            switch (position)
            {
                case int n when n > 25:
                    return position - 26;

                case int n when n < 0:
                    return position + 26;

                default:
                    return position;
            }
        }
        
        public override string ToString()
        {
            var value = new StringBuilder();
            var right = new StringBuilder();
            var offset = new StringBuilder();
            var left = new StringBuilder();

            foreach(var letter in LetterRing)
            {
                value.Append($"{letter.Value.ToString().PadLeft(3, ' ')} ");
                right.Append($"{letter.Right.ToString().PadLeft(3, ' ')} ");
                offset.Append($"{letter.RightToLeft.ToString().PadLeft(3, ' ')} ");
                left.Append($"{letter.Left.ToString().PadLeft(3, ' ')} ");
            }

            value.Append('\n');
            right.Append('\n');
            offset.Append('\n');
            
            return value.ToString() + right.ToString() + offset.ToString() + left.ToString();
        }
    }
}