using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Concordanse.Interfases;
using Concordanse.TextGradation;

namespace Concordanse.ParseRealization
{
    class TxtParser : IFileParser
    {
        /// <summary>
        /// Разделение предложения на составные элементы - слова, знаки препинания, числа
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static List<string> ParseToWord(string line)
        {
            const string reg = @"(-*\d+\.\d+|-*\d+\,\d|[^\w\b])";
            return  new List<string>(Regex.Split(line, reg));
        }
        /// <summary>
        /// Парсинг файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public TextContent ParseFile(string path)
        {
            var content = new TextContent();
            const string reg = @"((?sx-m)[^\r\n].*?(?:(?:\.|\?|!)\s))";
            StreamReader reader;

            try
            {
                reader = new StreamReader(path, Encoding.GetEncoding(1251));
            }
            catch
            {
                Console.WriteLine("Cannot read the file");
                return null;
            }

            var i = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != null)
                {
                    content.SymbolCount += line.Length;
                    //список предложений, полученных со строки, прочтённой из файла
                    
                        var sentences = new List<string>(Regex.Split(line, reg));
                        foreach (var pr in sentences)
                        {
                            if (String.IsNullOrEmpty(pr)) 
                                continue;
                            var sentence = new Sentence();
                            //Создаём объект типа "предложение" и передаём ему список слов, знаков препинания и чисел
                            //в строковом формате
                            sentence.Create(ParseToWord(pr), i);
                            content.Add(sentence);
                        }
                    
                }
                i++;
            }
            reader.Close();
            return content;
        }
    }
}
