namespace libpolyglot.Heuristics
{
    internal abstract class AbstractHeuristic
    {
        protected readonly AnalysisData data;

        public AbstractHeuristic()
        {
        }

        public abstract Language ForLanguage { get; }

        public abstract bool GetResult(AnalysisData data);
    }
}
