// <copyright file="AbstractHeuristic.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

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
