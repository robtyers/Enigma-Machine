
namespace Enigma.Rotors.EnigmaI
{
    public class III : CipherWheel
    {
        public III(int rotorOffset = 1) : base(rotorOffset)
        {
            RotorNumber = "III";
            
            Substitute('A', 'B');
            Substitute('B', 'D');
            Substitute('C', 'F');
            Substitute('D', 'H');
            Substitute('E', 'J');
            Substitute('F', 'L');
            Substitute('G', 'C');
            Substitute('H', 'P');
            Substitute('I', 'R');
            Substitute('J', 'T');
            Substitute('K', 'X');
            Substitute('L', 'V');
            Substitute('M', 'Z');
            Substitute('N', 'N');
            Substitute('O', 'Y');
            Substitute('P', 'E');
            Substitute('Q', 'I');
            Substitute('R', 'W');
            Substitute('S', 'G');
            Substitute('T', 'A');
            Substitute('U', 'K');
            Substitute('V', 'M');
            Substitute('W', 'U');
            Substitute('X', 'S');
            Substitute('Y', 'Q');
            Substitute('Z', 'O');

            SetNotch('V');
        }
    }
}