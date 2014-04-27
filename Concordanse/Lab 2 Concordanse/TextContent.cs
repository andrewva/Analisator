using System.Collections.Generic;
using System.Linq;
using Concordanse.TextGradation;

namespace Concordanse
{
    public class TextContent
    {
        private readonly List<Sentence> _list;

        public int SymbolCount { get; set; }

        public List<Sentence> List
        {
            get
            {
                return _list;
            }
        }

        public TextContent()
        {
            _list = new List<Sentence>();
        }

        public void Add(Sentence sentence)
        {
            _list.Add(sentence);
        }

        public void Add(List<Sentence> sentenceList)
        {
            _list.AddRange(sentenceList);
        }

        public List<string> GetContent()
        {
            var ls = new List<string>(_list.Select(x => x.ToString()));
            return ls;
        }

    }
}
