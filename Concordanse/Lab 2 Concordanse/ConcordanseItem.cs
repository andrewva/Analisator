using System;
using System.Collections.Generic;
using System.Linq;
using Concordanse.TextGradation;

namespace Concordanse
{
    [Serializable]
    public class ConcordanseItem
    {
        public int Count;
        public List<int> PageList;
        public Word Word;

        public ConcordanseItem()
        {
            PageList = new List<int>();
        }
        public override string ToString()
        {
            var result = PageList.Aggregate("", (current, t) => current + (t + " "));
            return Word.ToString().ToLower() + " ............... " + Count + ": " + result;
        }

   

        public int IncrementCount
        {
            get
            {
                return Count;
            }
            set
            {
                Count += value;
            }
        }
        public int AddPageNumber
        {
            set
            {
                if (PageList.All(x => x != value))
                    PageList.Add(value);
            }
        }

    }
}
