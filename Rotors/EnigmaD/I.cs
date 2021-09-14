
namespace Enigma.Rotors.EnigmaD
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
            
            Substitute('A', 'L');
            Substitute('B', 'P');
            Substitute('C', 'G');
            Substitute('D', 'S');
            Substitute('E', 'Z');
            Substitute('F', 'M');
            Substitute('G', 'H');
            Substitute('H', 'A');
            Substitute('I', 'E');
            Substitute('J', 'O');
            Substitute('K', 'Q');
            Substitute('L', 'K');
            Substitute('M', 'V');
            Substitute('N', 'X');
            Substitute('O', 'R');
            Substitute('P', 'F');
            Substitute('Q', 'Y');
            Substitute('R', 'B');
            Substitute('S', 'U');
            Substitute('T', 'T');
            Substitute('U', 'N');
            Substitute('V', 'I');
            Substitute('W', 'C');
            Substitute('X', 'J');
            Substitute('Y', 'D');
            Substitute('Z', 'W');

            SetNotch('G');
            SetStartPosition(startPosition);
        }
    }
}