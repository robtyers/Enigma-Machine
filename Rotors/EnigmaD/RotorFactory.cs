using System;
using System.Collections.Generic;

namespace Enigma.Rotors.EnigmaD
{
    public class RotorFactory : IRotorFactory
    {
        public IEntryDisk GetEntryDisk =>  new ETW();

        public IReflector GetReflector =>  new UKW();

        public IList<ICipherWheel> Rotors => new List<ICipherWheel> { new I(), new II(), new III() };
    }
}