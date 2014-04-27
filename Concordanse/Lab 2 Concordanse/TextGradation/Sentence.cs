using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Concordanse.TextGradation
{
    public class Sentence : Word
    {
        private int _lineNumber;
        private readonly ArrayList _sentence;
        public ArrayList GetSentence
        {
            get
            {
                return _sentence;
            }
        }
        public int LineNumber
        {
            get
            {
                return _lineNumber;
            }
        }
        public Sentence()
        {
            _sentence = new ArrayList();
        }
        public override string ToString()
        {
            var result = "";
            foreach (var a in _sentence)
            {
                result += a.ToString();
            }
            return result;
        }

        public void Create(List<string> list, int numb)
        {
            _lineNumber = numb;
            PunctuationMark p;
            var reg = new Regex(@"\d+\.\d+|\d+\,\d|\d");
            //Разбираем список строк и преобразуем в соответствующий тип данных
            //после чего добавляем результаты в массив объектов, составляющих предложение
            foreach (var item in list)
            {
                if (item == "")
                    continue;
                //Является ли числом?
                if (reg.Match(item).Success)
                {
                    _sentence.Add(item);
                }
                else
                    //Является ли словом
                {
                    Word word;
                    if (item.Length > 1)
                    {
                        word = new Word(item.ToLower());
                        _sentence.Add(word);
                    }
                    else
                    {
                        //Является ли словом из одной буквы
                        if (Char.IsLetter(Convert.ToChar(item)))
                        {
                            word = new Word(item.ToLower());
                            _sentence.Add(word);
                        }
                            //Остальное это знаки препинания
                        else
                        {
                            p = new PunctuationMark(Convert.ToChar(item));
                            _sentence.Add(p);
                        }
                    }
                }
            }
        }
    }
}
