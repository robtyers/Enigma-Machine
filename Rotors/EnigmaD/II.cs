
namespace Enigma.Rotors.EnigmaD
{
    public class II : CipherWheel
    {
        public II(int rotorOffset = 1) : base(rotorOffset)
        {
            RotorNumber = "II";
            
            Substitute('A', 'S');
            Substitute('B', 'L');
            Substitute('C', 'V');
            Substitute('D', 'G');
            Substitute('E', 'B');
            Substitute('F', 'T');
            Substitute('G', 'F');
            Substitute('H', 'X');
            Substitute('I', 'J');
            Substitute('J', 'Q');
            Substitute('K', 'O');
            Substitute('L', 'H');
            Substitute('M', 'E');
            Substitute('N', 'W');
            Substitute('O', 'I');
            Substitute('P', 'R');
            Substitute('Q', 'Z');
            Substitute('R', 'Y');
            Substitute('S', 'A');
            Substitute('T', 'M');
            Substitute('U', 'K');
            Substitute('V', 'P');
            Substitute('W', 'C');
            Substitute('X', 'N');
            Substitute('Y', 'D');
            Substitute('Z', 'U');

            SetNotch('M');
        }
    }
}