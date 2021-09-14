
namespace Enigma.Rotors.EnigmaI
{
    public class II : CipherWheel
    {
        public II()
        {
            RotorNumber = "II";
        }
        public override void Initialise(int ringSetting, char startPosition)
        {
            SetRingSetting(ringSetting);
            
            Substitute('A', 'A');
            Substitute('B', 'J');
            Substitute('C', 'D');
            Substitute('D', 'K');
            Substitute('E', 'S');
            Substitute('F', 'I');
            Substitute('G', 'R');
            Substitute('H', 'U');
            Substitute('I', 'X');
            Substitute('J', 'B');
            Substitute('K', 'L');
            Substitute('L', 'H');
            Substitute('M', 'W');
            Substitute('N', 'T');
            Substitute('O', 'M');
            Substitute('P', 'C');
            Substitute('Q', 'Q');
            Substitute('R', 'G');
            Substitute('S', 'Z');
            Substitute('T', 'N');
            Substitute('U', 'P');
            Substitute('V', 'Y');
            Substitute('W', 'F');
            Substitute('X', 'V');
            Substitute('Y', 'O');
            Substitute('Z', 'E');

            SetNotch('M');
            SetStartPosition(startPosition);
        }
    }
}