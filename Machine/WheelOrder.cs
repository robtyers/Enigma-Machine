using Enigma.Rotors;

namespace Enigma.Machine
{
    public class WheelOrder
    {
        public WheelOrder(IEntryDisk entryDisk, ICipherWheel slow, ICipherWheel medium, ICipherWheel fast, IReflector reflector)
        {
            EntryDisk = entryDisk;
            Slow = slow;
            Medium = medium;
            Fast = fast;
            Reflector = reflector;
        }
        
        public IEntryDisk EntryDisk { get; }
        public ICipherWheel Slow { get; }
        public ICipherWheel Medium { get; }
        public ICipherWheel Fast { get; }
        public IReflector Reflector { get;}
    }
}