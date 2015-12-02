namespace libpolyglot.Heuristics
{
    internal abstract class AbstractHeuristic
    {
        public AbstractHeuristic()
        {
        }

        public abstract Language ForLanguage { get; }

        public abstract bool GetResult(AnalysisData data);
    }
}
