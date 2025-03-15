using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Export
{
    public class TextFileExport : IFileExporterStrategy
    {
        public void Export(StringBuilder texts)
        {
            //Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);
            File.WriteAllText($@"{System.AppDomain.CurrentDomain.BaseDirectory}\output\output.txt", texts.ToString());
        }

        public void Export(string text)
        {
            //Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);
            File.WriteAllText($@"{System.AppDomain.CurrentDomain.BaseDirectory}\output\output.txt", text);
        }
    }
}
