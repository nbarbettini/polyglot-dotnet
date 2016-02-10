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
        private readonly bool failSilently;
        private readonly List<AnalysisResult> results;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyAnalyzer"/> class based on the given assembly.
        /// </summary>
        /// <param name="assemblyToAnalyze">The assembly to analyze.</param>
        public AssemblyAnalyzer(Assembly assemblyToAnalyze, bool failSilently = true)
        {
            this.failSilently = failSilently;
            this.results = Analyze(assemblyToAnalyze).ToList();
        }

        /// <inheritdoc/>
        public IReadOnlyList<AnalysisResult> AllResults => this.results;

        /// <inheritdoc/>
        public Language? DetectedLanguage => TopScore(this.results);

        private static Language? TopScore(IList<AnalysisResult> source)
        {
            if (source.All(x => x.Score == 0))
            {
                return null;
            }

            return source?.Aggregate((l, r) => l.Score > r.Score ? l : r).Language;
        }

        private IEnumerable<AnalysisResult> Analyze(Assembly assembly)
        {
            try
            {
                var internalTypeNames = assembly.DefinedTypes.Select(t => t.FullName);

#if NET451
                var referencedAssemblyNames = assembly.GetReferencedAssemblies().Select(x => x.Name);
#else
                var referencedAssemblyNames = Enumerable.Empty<string>(); // not currently supported :(
#endif

                var analysisData = new AnalysisData(referencedAssemblyNames, internalTypeNames);

                var runner = new HeuristicRunner(HeuristicProvider.GetAll());
                return runner.GetResults(analysisData);
            }
            catch
            {
                if (this.failSilently)
                {
                    return null;
                }

                throw;
            }
        }
    }
}
