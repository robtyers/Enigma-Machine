namespace Enigma.Rotors
{
    public static class Extensions
    {
        public static int ToInt(this char c)
        {
            return char.ToUpper(c) - 65;
        }

        public static char ToChar(this int i)
        {
            return (char)(i + 65);
        }
    }
}