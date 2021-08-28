using System.Collections;
using System.Collections.Generic;

namespace Enigma.Rotors
{
    public class LetterRing : IList<Letter>
    {
        List<Letter> _letters = new List<Letter>();

        public Letter this[int index]  
        {  
            get { return _letters[index]; }  
            set { _letters.Insert(index, value); }  
        }

        public int Count => _letters.Count;

        public bool IsReadOnly => true;

        public void Add(Letter item)
        {
            _letters.Add(item);
        }

        public void Clear()
        {
            _letters.Clear();
        }

        public bool Contains(Letter item)
        {
            return _letters.Contains(item);
        }

        public void CopyTo(Letter[] array, int arrayIndex)
        {
             _letters.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Letter> GetEnumerator()
        {
            //return new CircularEnumerator<Letter>(_offSets.GetEnumerator());
            return _letters.GetEnumerator();
        }

        public int IndexOf(Letter item)
        {
            return _letters.IndexOf(item);
        }

        public void Insert(int index, Letter item)
        {
            _letters.Insert(index, item);
        }

        public bool Remove(Letter item)
        {
            return _letters.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _letters.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //return new CircularEnumerator<Letter>(this.GetEnumerator());
            return this.GetEnumerator();
        }
    }
}