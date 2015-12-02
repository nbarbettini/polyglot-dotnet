using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libpolyglot
{
    public interface IAssemblyAnalyzer
    {
        Language? DetectedLanguage { get; }

        IDictionary<Language, double> AllResults { get; }
    }
}
