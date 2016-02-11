// <copyright file="HeuristicRunner.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace Polyglot.Heuristics
{
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class HeuristicRunner
    {
        private readonly List<IHeuristic> heuristics;

        public HeuristicRunner(IEnumerable<IHeuristic> heuristics)
        {
            this.heuristics = heuristics.ToList();
        }

        public IEnumerable<AnalysisResult> GetResults(AnalysisData data)
        {
            return this.heuristics
                .GroupBy(h => h.Language)
                .Select(group => new { language = group.Key, matches = Run(group, data), groupCount = group.Count() })
                .Select(x => new AnalysisResult(x.language, x.matches, CalculateScore(this.heuristics.Count, x.groupCount, x.matches.Count())));
        }

        private static IEnumerable<string> Run(IEnumerable<IHeuristic> heuristics, AnalysisData data)
            => heuristics
                .Where(x => x.GetResult(data) == true)
                .Select(x => x.Name);

        private static double CalculateScore(int totalHeuristics, int groupHeuristics, int matches)
            => matches / (double)groupHeuristics;
    }
}
