using Concordanse.OutputRealization;
using Concordanse.ParseRealization;

namespace Concordanse
{
    public class Parse
    {
        public string ParseFile(string path)
        {
            var parser = new TxtParser();
            var content = parser.ParseFile(path);

            if (content == null)
            {
                return string.Empty;
            }

            var concordance = new Concordanse();
            const int count = 50;
            concordance.CreateConcordanse(content, count);
            var pathOutput = path;
            //var output = new TxtOutput();
            //output.Output(concordance.GetConcordanseResult(), pathOutput);
            var output = new XmlOutput();
            return output.Output(concordance);
        }
    }
}
