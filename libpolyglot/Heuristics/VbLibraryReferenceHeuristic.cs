using System;

namespace libpolyglot.Heuristics
{
    internal sealed class VbLibraryReferenceHeuristic : AbstractHeuristic
    {
        public override Language ForLanguage => Language.Vb;

        public override bool GetResult(AnalysisData data)
            => this.data.ReferencedAssemblyNames.Contains("Microsoft.VisualBasic");
    }
}
