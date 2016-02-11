// <copyright file="IHeuristic.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace Polyglot.Heuristics
{
    /// <summary>
    /// Represents a heuristic that analyzes indicators for a specific language.
    /// </summary>
    internal interface IHeuristic
    {
        /// <summary>
        /// Gets the heuristic name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the language the heuristic reports.
        /// </summary>
        Language Language { get; }

        /// <summary>
        /// Executes the heuristic against a set of input data.
        /// </summary>
        /// <param name="data">The data to analyze.</param>
        /// <returns><see langword="true"/> if the data matches the target language; <see langword="false"/> otherwise.</returns>
        bool GetResult(AnalysisData data);
    }
}
