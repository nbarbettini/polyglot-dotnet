// <copyright file="VbLibraryReferenceHeuristic.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace libpolyglot.Heuristics
{
    using System;

    internal sealed class VbLibraryReferenceHeuristic : AbstractHeuristic
    {
        public override Language ForLanguage => Language.Vb;

        public override bool GetResult(AnalysisData data)
            => data.ReferencedAssemblyNames.Contains("Microsoft.VisualBasic");
    }
}
