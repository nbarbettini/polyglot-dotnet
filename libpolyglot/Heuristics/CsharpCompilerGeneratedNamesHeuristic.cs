using System.Linq;

namespace libpolyglot.Heuristics
{
    internal sealed class CsharpCompilerGeneratedNamesHeuristic : AbstractHeuristic
    {
        public override Language ForLanguage => Language.CSharp;

        public override bool GetResult(AnalysisData data)
            => data.InternalTypeNames.Where(x => x.Contains("<>")).Any();
    }
}
