
namespace Enigma.Rotors.EnigmaI
{
    public class I : CipherWheel
    {
        public I()
        {
            RotorNumber = "I";
        }
        public override void Initialise(int ringSetting, char startPosition)
        {
            SetRingSetting(ringSetting);
            
            Substitute('A', 'E');
            Substitute('B', 'K');
            Substitute('C', 'M');
            Substitute('D', 'F');
            Substitute('E', 'L');
            Substitute('F', 'G');
            Substitute('G', 'D');
            Substitute('H', 'Q');
            Substitute('I', 'V');
            Substitute('J', 'Z');
            Substitute('K', 'N');
            Substitute('L', 'T');
            Substitute('M', 'O');
            Substitute('N', 'W');
            Substitute('O', 'Y');
            Substitute('P', 'H');
            Substitute('Q', 'X');
            Substitute('R', 'U');
            Substitute('S', 'S');
            Substitute('T', 'P');
            Substitute('U', 'A');
            Substitute('V', 'I');
            Substitute('W', 'B');
            Substitute('X', 'R');
            Substitute('Y', 'C');
            Substitute('Z', 'J');

            SetNotch('G');
            SetStartPosition(startPosition);
        }
    }
}