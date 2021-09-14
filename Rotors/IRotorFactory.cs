using System.Collections.Generic;

namespace Enigma.Rotors
{
    public interface IRotorFactory
    {
        public IEntryDisk GetEntryDisk { get; }
        public IReflector GetReflector { get; }
        IList<ICipherWheel> Rotors { get; }
    }
}