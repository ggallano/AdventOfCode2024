using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Export
{
    public class TextFileExport : IFileExporterStrategy
    {
        public void Export(StringBuilder texts)
        {
            Console.WriteLine("Exporting text to a text file...");
        }
    }
}
