// <copyright file="CsharpCompilerGeneratedNamesHeuristic.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace libpolyglot.Heuristics
{
    using System.Linq;

    internal sealed class CsharpCompilerGeneratedNamesHeuristic : AbstractHeuristic
    {
        public override Language ForLanguage => Language.CSharp;

        public override bool GetResult(AnalysisData data)
            => data.InternalTypeNames.Where(x => x.Contains("<>")).Any();
    }
}
