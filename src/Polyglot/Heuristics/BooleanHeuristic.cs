// <copyright file="BooleanHeuristic.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace libpolyglot.Heuristics
{
    using System;

    internal sealed class BooleanHeuristic : IHeuristic
    {
        private readonly string name;
        private readonly Language language;
        private readonly Func<AnalysisData, bool> analysisFunc;

        public BooleanHeuristic(string name, Language forLanguage, Func<AnalysisData, bool> analysisFunc)
        {
            this.name = name;
            this.language = forLanguage;
            this.analysisFunc = analysisFunc;
        }

        public string Name => this.name;

        public Language Language => this.language;

        public bool GetResult(AnalysisData data) => this.analysisFunc(data);
    }
}
