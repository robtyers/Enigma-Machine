namespace Enigma.Rotors.EnigmaD
{
    public class UKW : Reflector
    {
        public UKW()
        {
            RotorNumber = "UKW";

            Substitute('A', 'I');
            Substitute('B', 'M');
            Substitute('C', 'E');
            Substitute('D', 'T');
            Substitute('E', 'C');
            Substitute('F', 'G');
            Substitute('G', 'F');
            Substitute('H', 'R');
            Substitute('I', 'A');
            Substitute('J', 'Y');
            Substitute('K', 'S');
            Substitute('L', 'Q');
            Substitute('M', 'B');
            Substitute('N', 'Z');
            Substitute('O', 'X');
            Substitute('P', 'W');
            Substitute('Q', 'L');
            Substitute('R', 'H');
            Substitute('S', 'K');
            Substitute('T', 'D');
            Substitute('U', 'V');
            Substitute('V', 'U');
            Substitute('W', 'P');
            Substitute('X', 'O');
            Substitute('Y', 'J');
            Substitute('Z', 'N');
        }
    }
}