using System.Collections.Generic;
using System.Linq;

namespace libpolyglot.Heuristics
{
    internal sealed class HeuristicRunner
    {
        private readonly List<AbstractHeuristic> heuristics;

        public HeuristicRunner(IEnumerable<AbstractHeuristic> heuristics)
        {
            this.heuristics = heuristics.ToList();
        }

        public IDictionary<Language, double> GetResult(AnalysisData data)
        {
            var results = new Dictionary<Language, double>();

            var supportedLanguages = heuristics
                .GroupBy(h => h.ForLanguage);
            foreach (var lang in supportedLanguages)
            {
                double trueCount = Run(lang, data);
                results.Add(lang.Key, trueCount / lang.Count());
            }

            return results;
        }

        private int Run(IEnumerable<AbstractHeuristic> heuristics, AnalysisData data)
            => heuristics
                .Select(h => h.GetResult(data))
                .Count(r => r == true);
    }
}
