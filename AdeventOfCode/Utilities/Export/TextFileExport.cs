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
        string filePath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\output.txt";

        public void Export(StringBuilder texts)
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();
            else
            {
                File.Delete(filePath);
                File.Create(filePath).Close();
            }


            File.AppendAllText(filePath, texts.ToString());
        }

        public void Export(string text)
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();
            else
            {
                File.Delete(filePath);
                File.Create(filePath).Close();
            }

            File.AppendAllText(filePath, text);
        }
    }
}
