namespace Enigma.Rotors
{
    // public class Letter
    // {
    //     public bool Notch { get; set; }
    //     public char Value { get; }
    //     public char Left { get; }
    //     public char Right { get; }
    //     public int RightToLeft => _offset;
    //     public int LeftToRight => _offset * -1;
    //     int _offset;

    //     public Letter(char value, char right, char left)
    //     {
    //         Value = value;
    //         Left = left;
    //         Right = right;

    //         _offset = left.ToInt() - right.ToInt();
    //     }
    // }

    public class Letter
    {
        public bool Notch { get; set; }
        public char Value { get; }
        public char Left { get; set; }
        public char Right { get; set; }
        public int RightToLeft { get; set; }//=> _offset;
        public int LeftToRight { get; set; }// => _offset * -1;
        int _offset;

        public Letter(char value, char right, char left)
        {
            Value = value;
            Left = left;
            Right = right;

            _offset = left.ToInt() - right.ToInt();
        }

        public Letter(char value)
        {
            Value = value;
        }
    }
}