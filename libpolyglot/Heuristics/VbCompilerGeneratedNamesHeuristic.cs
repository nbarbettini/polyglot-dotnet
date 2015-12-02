using System.Linq;

namespace libpolyglot.Heuristics
{
    internal sealed class VbCompilerGeneratedNamesHeuristic : AbstractHeuristic
    {
        public override Language ForLanguage => Language.Vb;

        public override bool GetResult(AnalysisData data)
            => this.data.InternalTypeNames.Where(x => x.Contains("VB$")).Any();
    }
}
