using System.Collections.Generic;

namespace Enigma.Rotors
{
    public interface IRotor
    {
         public string RotorNumber { get; }
         public LetterRing LetterRing { get; }
         public int RightToLeft(int rightSide);
         public int LeftToRight(int leftSide);
    }
}