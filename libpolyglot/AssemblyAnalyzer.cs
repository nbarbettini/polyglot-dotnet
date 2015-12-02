using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using libpolyglot.Heuristics;

namespace libpolyglot
{
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

        public AssemblyAnalyzer(Assembly assemblyToAnalyze)
        {
            this.results = Analyze(assemblyToAnalyze);
        }

        public IDictionary<Language, double> AllResults
            => new Dictionary<Language, double>(this.results);

        public Language? DetectedLanguage
        {
            get
            {
                if (!results.Any())
                    return null;

                return KeyByMaxValue(results);
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
