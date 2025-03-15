using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Export
{
    public interface IFileExporterStrategy
    {
        void Export(StringBuilder texts);
        void Export(string text);
    }
}
