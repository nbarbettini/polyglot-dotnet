namespace libpolyglot.Heuristics
{
    internal sealed class CsharpBiasedHeuristic : AbstractHeuristic
    {
        public override Language ForLanguage => Language.CSharp;

        public override bool GetResult(AnalysisData data) => true;
    }
}
