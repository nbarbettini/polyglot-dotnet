namespace libpolyglot.Heuristics
{
    internal sealed class CsharpLibraryReferenceHeuristic : AbstractHeuristic
    {
        public override Language ForLanguage => Language.CSharp;

        public override bool GetResult(AnalysisData data)
            => data.ReferencedAssemblyNames.Contains("Microsoft.CSharp");
    }
}
