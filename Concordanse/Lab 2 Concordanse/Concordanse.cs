using System;
using System.Collections.Generic;
using System.Linq;
using Concordanse.TextGradation;
using System.Xml.Serialization;

namespace Concordanse
{
    [Serializable]
    public class Concordanse
    {
        public List<ConcordanseItem> Items { get; set; }
        public int SybolCount { get; set; }
        public int WordCount { get; set; }
        public int LineCount { get; set; }
        public int SentenseCount { get; set; }

        public int SentensePartCount { get; set; }
        public Concordanse()
        {
            Items = new List<ConcordanseItem>();
        }
        /// <summary>
        /// Метод проверки вхождения строки (слова) в конкордансе
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>

        private bool Contain(string word)
        {
            return Items.Any(p => p.Word.ToString() == word);
        }
        /// <summary>
        /// форматирование для вывода - разбиение по букве
        /// </summary>
        /// <returns></returns>
        public List<string> GetConcordanseResult()
        {
            var list = new List<string>();
            foreach (var a in Items)
            {
                if (list.Count == 0)
                    list.Add("\n" + Char.ToUpper(a.Word.ToString()[0]).ToString() + "\n");
                else
                {
                    if (Char.ToLower(list[list.Count - 1][0]) != Char.ToLower(a.Word.ToString()[0]))
                    {
                        list.Add("\n" + Char.ToUpper(a.Word.ToString()[0]).ToString() + "\n");
                    }
                }
                list.Add(a.ToString());
            }
            return list;
        }

        public void CreateConcordanse(TextContent content, int pageLength)
        {
            SentenseCount = content.List.Count;

            SybolCount = content.SymbolCount;
            LineCount = content.List.Last().LineNumber+1;
           
            var list = content.List;
            //выбираем все "слова" из контента и сортируем их
            var orderList = list.SelectMany(word => word.GetSentence.OfType<Word>(), (count, word) => new { count.LineNumber, word })
                .OrderBy(x => x.word.ToString());

            WordCount = orderList.Count();


            foreach (var item in orderList)
            {
                if (Contain(item.word.ToString()))
                {
                    this.Items[this.Items.Count - 1].IncrementCount = 1;
                    this.Items[this.Items.Count - 1].AddPageNumber = item.LineNumber / pageLength + 1;
                }
                else
                {
                    var line = new ConcordanseItem
                    {
                        IncrementCount = 1,
                        Word = new Word(item.word.ToString()),
                        AddPageNumber = item.LineNumber/pageLength + 1
                    };
                    Items.Add(line);
                }
            }
        }
    }
}
