using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Export
{
    public class FileExporter
    {
        private IFileExporterStrategy strategy;

        public FileExporter(IFileExporterStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(IFileExporterStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ExportText(StringBuilder texts)
        {
            strategy.Export(texts);
        }

        public void ExportText(string text)
        {
            strategy.Export(text);
        }
    }
}
