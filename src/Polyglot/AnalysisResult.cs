// <copyright file="AnalysisResult.cs" company="Nate Barbettini">
// Copyright (c) Nate Barbettini. Licensed under MIT.
// </copyright>

namespace Polyglot
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents the results of an assembly analysis.
    /// </summary>
    public class AnalysisResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalysisResult"/> class.
        /// </summary>
        /// <param name="langauge">The language.</param>
        /// <param name="matches">The matching heuristics, if any.</param>
        /// <param name="score">The overall score.</param>
        public AnalysisResult(Language langauge, IEnumerable<string> matches, double score)
        {
            this.Language = langauge;
            this.MatchingHeuristics = matches?.ToList() ?? Enumerable.Empty<string>().ToList();
            this.Score = score;
        }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Gets the matching heuristics, if any.
        /// </summary>
        public IList<string> MatchingHeuristics { get; private set; }

        /// <summary>
        /// Gets the score.
        /// </summary>
        public double Score { get; private set; }
    }
}
