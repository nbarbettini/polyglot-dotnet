// <copyright file="CsharpBiasedHeuristic.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace libpolyglot.Heuristics
{
    internal sealed class CsharpBiasedHeuristic : AbstractHeuristic
    {
        public override Language ForLanguage => Language.CSharp;

        public override bool GetResult(AnalysisData data) => true;
    }
}
