// <copyright file="AssemblyAnalyzer.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace libpolyglot
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Heuristics;

    /// <inheritdoc/>
    public sealed class AssemblyAnalyzer : IAssemblyAnalyzer
    {
        private static readonly AbstractHeuristic[] DefaultHeuristics =
        {
            new CsharpBiasedHeuristic(),
            new CsharpCompilerGeneratedNamesHeuristic(),
            new CsharpLibraryReferenceHeuristic(),
            new VbCompilerGeneratedNamesHeuristic(),
            new VbLibraryReferenceHeuristic(),
            new VbMyTypesHeuristic()
        };

        private readonly IDictionary<Language, double> results;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyAnalyzer"/> class based on the given assembly.
        /// </summary>
        /// <param name="assemblyToAnalyze">The assembly to analyze.</param>
        public AssemblyAnalyzer(Assembly assemblyToAnalyze)
        {
            this.results = Analyze(assemblyToAnalyze);
        }

        /// <inheritdoc/>
        public IDictionary<Language, double> AllResults
            => new Dictionary<Language, double>(this.results);

        /// <inheritdoc/>
        public Language? DetectedLanguage
        {
            get
            {
                if (!this.results.Any())
                {
                    return null;
                }

                return KeyByMaxValue(this.results);
            }
        }

        private static Language KeyByMaxValue(IDictionary<Language, double> source)
            => source.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        private static IDictionary<Language, double> Analyze(Assembly assembly)
        {
            var analysisData = new AnalysisData(
                assembly.GetReferencedAssemblies().Select(x => x.Name),
                assembly.GetTypes().Select(t => t.FullName));

            var runner = new HeuristicRunner(DefaultHeuristics);
            return runner.GetResult(analysisData);
        }
    }
}
