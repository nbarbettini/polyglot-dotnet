using System.Linq;

namespace libpolyglot.Heuristics
{
    internal sealed class VbMyTypesHeuristic : AbstractHeuristic
    {
        public override Language ForLanguage => Language.Vb;

        public override bool GetResult(AnalysisData data)
            => this.data.InternalTypeNames.Where(x => x.Contains(".My.My")).Any();
    }
}
