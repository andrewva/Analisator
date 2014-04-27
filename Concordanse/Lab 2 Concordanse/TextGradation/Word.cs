using System;

namespace Concordanse.TextGradation
{
    [Serializable]
    public class Word : Symbol
    {
        public string _value;
      
        public Word()
        {
        }

        public Word(string str)
        {
            _value = str ;
        }

        public Word(char [] list)
        {
            _value = new string(list);
        }

        public override string ToString()
        {
            return this._value;
        }
    }
}
