// <copyright file="VbCompilerGeneratedNamesHeuristic.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace libpolyglot.Heuristics
{
    using System.Linq;

    internal sealed class VbCompilerGeneratedNamesHeuristic : AbstractHeuristic
    {
        public override Language ForLanguage => Language.Vb;

        public override bool GetResult(AnalysisData data)
            => data.InternalTypeNames.Where(x => x.Contains("VB$")).Any();
    }
}
