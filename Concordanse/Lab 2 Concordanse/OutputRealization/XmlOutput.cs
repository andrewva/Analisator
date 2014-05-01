using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Concordanse.Interfases;

namespace Concordanse.OutputRealization
{
    class XmlOutput : IFileOutputResult
    {
        public string Output(Concordanse concordanse,string path)
        {
            //взять из конфигурации
            path = path.Substring(0,path.Length-3)+"xml";
            var pathToXml = path;

            var formatter = new XmlSerializer(typeof(Concordanse));
            using (var fs = new FileStream(pathToXml, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, concordanse);
            }

            // десериализация
         

            //var textWritter = new XmlTextWriter(pathToXml,Encoding.UTF8);
            //textWritter.WriteStartDocument();
            //textWritter.WriteStartElement("head");
            //textWritter.WriteEndElement();
            //textWritter.Close();

            //var document = new XmlDocument();
            //document.Load(pathToXml);

            //XmlNode lineCountNode = document.CreateElement("lineCount");
            //lineCountNode.InnerText = concordanse.LineCount.ToString();
            //document.DocumentElement.AppendChild(lineCountNode);

            //XmlNode sentenseCountNode = document.CreateElement("sentenseCount");
            //sentenseCountNode.InnerText = concordanse.SentenseCount.ToString();
            //document.DocumentElement.AppendChild(sentenseCountNode);

            //XmlNode sentensePartCountNode = document.CreateElement("sentensePartCount");
            //sentensePartCountNode.InnerText = concordanse.SentensePartCount.ToString();
            //document.DocumentElement.AppendChild(sentensePartCountNode);

            //XmlNode symbolCountNode = document.CreateElement("symbolCount");
            //symbolCountNode.InnerText = concordanse.SybolCount.ToString();
            //document.DocumentElement.AppendChild(symbolCountNode);

            //XmlNode wordCountNode = document.CreateElement("wordCount");
            //wordCountNode.InnerText = concordanse.WordCount.ToString();
            //document.DocumentElement.AppendChild(wordCountNode);

            //XmlNode concordanseNode = document.CreateElement("concordense");
            //if (document.DocumentElement != null) document.DocumentElement.AppendChild(concordanseNode); // указываем родителя
            //var attribute = document.CreateAttribute("number"); // создаём атрибут
            //attribute.Value = 1.ToString(CultureInfo.InvariantCulture); // устанавливаем значение атрибута
            //if (concordanseNode.Attributes != null) concordanseNode.Attributes.Append(attribute); // добавляем атрибут

            //foreach (var item in concordanse.Items)
            //{
            //    XmlNode itemNode = document.CreateElement("item");
            //    concordanseNode.AppendChild(itemNode);

            //    XmlNode wordNode = document.CreateElement("word");
            //    wordNode.InnerText = item.Word.ToString();
            //    itemNode.AppendChild(wordNode);

            //    XmlNode countNode = document.CreateElement("count");
            //    countNode.InnerText = item.IncrementCount.ToString();
            //    itemNode.AppendChild(countNode);

            //    XmlNode pagesNode = document.CreateElement("pages"); 
            //    itemNode.AppendChild(pagesNode);
            //    foreach (var page in item.PageList)
            //    {
            //        XmlNode pageNode = document.CreateElement("page");
            //        pageNode.InnerText = page.ToString();
            //        pagesNode.AppendChild(pageNode);
            //    }
            //}

            //document.Save(pathToXml);
            return pathToXml;
        }

        public void Output(List<string> list, string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}
