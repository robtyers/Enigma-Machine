using System.Collections;
using System.Collections.Generic;

namespace Enigma.Rotors
{
    // https://stackoverflow.com/a/54713298
    
    public class CircularEnumerator<T> : IEnumerator<T>
    {
        private readonly IEnumerator _enumerator;

        public CircularEnumerator(IEnumerator enumerator)
        {
            this._enumerator = enumerator;
        }

        public object Current => _enumerator.Current;

        T IEnumerator<T>.Current =>  (T)Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (!_enumerator.MoveNext())
            {
                _enumerator.Reset();
                return _enumerator.MoveNext();
            }
            return true;
        }

        public void Reset()
        {
            _enumerator.Reset();
        }
    }
}