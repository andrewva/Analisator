using System;
using System.Collections.Generic;
using System.IO;
using Concordanse.Interfases;

namespace Concordanse.OutputRealization
{
    class TxtOutput : IFileOutputResult
    {
        public void Output(List<string> content, string fileName)
        {
            StreamWriter writer;
            try
            {
                writer = new StreamWriter(fileName + ".txt");
            }
            catch
            {
                Console.WriteLine("Cannot open file for write");
                return;
            }
            foreach (var item in content)
                writer.WriteLine(item);
            writer.Close();
        }
    }
}
