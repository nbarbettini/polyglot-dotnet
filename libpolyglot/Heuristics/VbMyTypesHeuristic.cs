// <copyright file="VbMyTypesHeuristic.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace libpolyglot.Heuristics
{
    using System.Linq;

    internal sealed class VbMyTypesHeuristic : AbstractHeuristic
    {
        public override Language ForLanguage => Language.Vb;

        public override bool GetResult(AnalysisData data)
            => data.InternalTypeNames.Where(x => x.Contains(".My.My")).Any();
    }
}
