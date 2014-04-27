using System.Collections.Generic;

namespace XMLParser
{
    public class AnaliseModel
    {
        public string FileName { get; set; }
        public int SymbolCount { get; set; }
        public int WordCount { get; set; }
        public int DictionaryWordCount { get; set; }
        public int UnoqueWordCount { get; set; }
        public List<string> TopWord { get; set; }
        public string MaxWord { get; set; }
        public string MinWord{get;set;}
        public int LineCount { get; set; }
        public int SentenseCount { get; set; }
        public int SentensePartCount { get; set; }
        public List<SymbolFrequency> Frequencies { get; set; }
    }
}
