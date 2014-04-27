using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace XMLParser
{
    public class Parser
    {
        public AnaliseModel Parse(string pathToXml)
        {
            var formatter = new XmlSerializer(typeof(Concordanse.Concordanse));

            Concordanse.Concordanse conc;
            using (var fs = new FileStream(pathToXml, FileMode.OpenOrCreate))
            {
                conc = (Concordanse.Concordanse)formatter.Deserialize(fs);
            }
            var frequencies = new List<SymbolFrequency>();


            var wordGroups = conc.Items.GroupBy(m=>m.Word.ToString()[0]).ToList();

            foreach (var word in wordGroups)
            {
                var n = word.Sum(concordanseItem => concordanseItem.Count);
                frequencies.Add(new SymbolFrequency(){Symbol = word.Key.ToString() ,Frequency = n});
            }

            //foreach (var item in conc.Items)
            //{
            //    frequencies.Add(new SymbolFrequency() { Symbol = item.Word.ToString(), Frequency = item.Count });
            //}

            var model = new AnaliseModel
            {
                DictionaryWordCount = conc.Items.Count,
                FileName = pathToXml,
                LineCount = conc.LineCount,
                MaxWord = conc.Items.Select(x => x.Word.ToString()).OrderBy(m => m.ToString().Length).FirstOrDefault(),
                MinWord =
                    conc.Items.Select(x => x.Word.ToString())
                        .OrderByDescending(m => m.ToString().Length)
                        .FirstOrDefault(),
                SentenseCount = conc.SentenseCount,
                SentensePartCount = conc.SentensePartCount,
                SymbolCount = conc.SybolCount,
                UnoqueWordCount = conc.Items.Where(m => m.Count == 1).ToList().Count(),
                WordCount = conc.WordCount,
               Frequencies = frequencies
            };
          
            return model;
        }
    }
}
