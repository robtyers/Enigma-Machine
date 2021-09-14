
using System.Collections.Generic;

namespace Enigma.Rotors.EnigmaI
{
    public class RotorFactory : IRotorFactory
    {
        public IEntryDisk GetEntryDisk =>  new ETW();

        public IReflector GetReflector =>  new ReflectorB();

        public IList<ICipherWheel> Rotors => new List<ICipherWheel> { new I(), new II(), new III() };
    }
}