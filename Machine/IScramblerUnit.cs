using Enigma.Rotors;

namespace Enigma.Machine
{
    public interface IScramblerUnit
    {
        public string ModelNumber { get; }
        public IEntryDisk EntryDisk { get; }
        public ICipherWheel FastRotor { get; }
        public ICipherWheel MediumRotor { get; }
        public ICipherWheel SlowRotor { get; }
        public IReflector Reflector { get; }
        public char Encipher(char letter);

    }
}