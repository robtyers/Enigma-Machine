
namespace Enigma.Rotors.EnigmaD
{
    public class III : CipherWheel
    {
        public III()
        {
            RotorNumber = "III";
        }
        public override void Initialise(int ringSetting, char startPosition)
        {
            SetRingSetting(ringSetting);
            
            Substitute('A', 'C');
            Substitute('B', 'J');
            Substitute('C', 'G');
            Substitute('D', 'D');
            Substitute('E', 'P');
            Substitute('F', 'S');
            Substitute('G', 'H');
            Substitute('H', 'K');
            Substitute('I', 'T');
            Substitute('J', 'U');
            Substitute('K', 'R');
            Substitute('L', 'A');
            Substitute('M', 'W');
            Substitute('N', 'Z');
            Substitute('O', 'X');
            Substitute('P', 'F');
            Substitute('Q', 'M');
            Substitute('R', 'Y');
            Substitute('S', 'N');
            Substitute('T', 'Q');
            Substitute('U', 'O');
            Substitute('V', 'B');
            Substitute('W', 'V');
            Substitute('X', 'L');
            Substitute('Y', 'I');
            Substitute('Z', 'E');

            SetNotch('V');
            SetStartPosition(startPosition);
        }
    }
}