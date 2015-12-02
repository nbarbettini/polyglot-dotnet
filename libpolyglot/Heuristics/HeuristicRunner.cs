// <copyright file="HeuristicRunner.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace libpolyglot.Heuristics
{
    using System.Collections.Generic;
    using System.Linq;

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

            var supportedLanguages = this.heuristics
                .GroupBy(h => h.ForLanguage);
            foreach (var lang in supportedLanguages)
            {
                double trueCount = this.Run(lang, data);
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
