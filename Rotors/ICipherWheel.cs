using System;

namespace Enigma.Rotors
{
    public interface ICipherWheel : IRotor
    {
        public event EventHandler StepNext;
         public char CurrentValue { get; }
         public int RingSetting { get; }
         public void Step(bool trigger = true);
         public void StartPosition(char letter);
    }
}