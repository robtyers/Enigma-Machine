using System;
using System.Linq;

namespace Enigma.Rotors
{
    public abstract class CipherWheel : Rotor, ICipherWheel
    {
        public event EventHandler StepNext;
    
        Letter CurrentLetter => LetterRing[0];

        public char CurrentValue => CurrentLetter.Value;

        public int RingSetting { get; }

        protected virtual void OnStep(EventArgs e)
        {
            EventHandler handler = StepNext;
            handler?.Invoke(this, e);
        }

        public CipherWheel(int ringSetting)
        {
            if(ringSetting < 1 || ringSetting > 26)
                throw new ArgumentOutOfRangeException("Ring setting must be between 1 and 26");

            RingSetting = ringSetting;
        }

        public void Step(bool trigger = false)
        {
            if(CurrentLetter.Notch && trigger)
                OnStep( new EventArgs() );
            
            MoveNext();
        }

        void MoveNext()
        {
            var currentLetter = CurrentLetter;
            LetterRing.RemoveAt(0);
            LetterRing.Add(currentLetter);
        }

        public void StartPosition(char letter)
        {
            letter = Char.ToUpper(letter);
            
            if(!LetterRing.Any(l => l.Value == letter))
                throw new MissingMemberException($"{RotorNumber}: {letter} not found.");
            
            do
            {
                MoveNext();
                
                if(CurrentLetter.Value == letter)
                    break;
            } while(true);
        }

        protected char ApplyRingSetting(char value)
        {
            var val = value.ToInt() + (RingSetting - 1);
            var newVal = val < 26 ? val : val - 26;
            
            return newVal.ToChar();
        }

        new protected void Substitute(char right, char left)
        {
            LetterRing.Single(l => l.Value == ApplyRingSetting(right)).Left = left;
            LetterRing.Single(l => l.Value == ApplyRingSetting(left)).Right = right;
            LetterRing.Single(l => l.Value == ApplyRingSetting(right)).RightToLeft = left.ToInt() - right.ToInt();
            LetterRing.Single(l => l.Value == ApplyRingSetting(left)).LeftToRight = right.ToInt() - left.ToInt();
        }

        protected void SetNotch(char value)
        {
            LetterRing.Single(l => l.Value == value).Notch = true;
        }
    }
}