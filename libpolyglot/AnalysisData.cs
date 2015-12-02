using System.Collections.Generic;
using System.Linq;

namespace libpolyglot
{
    internal sealed class AnalysisData
    {
        private readonly IList<string> referencedAssemblyNames;
        private readonly IList<string> internalTypeNames;

        public AnalysisData(IEnumerable<string> referencedAssemblyNames, IEnumerable<string> internalTypeNames)
        {
            this.referencedAssemblyNames = referencedAssemblyNames.ToList();
            this.internalTypeNames = internalTypeNames.ToList();
        }

        public IList<string> ReferencedAssemblyNames
            => this.referencedAssemblyNames;

        public IList<string> InternalTypeNames
            => this.internalTypeNames;
    }
}
