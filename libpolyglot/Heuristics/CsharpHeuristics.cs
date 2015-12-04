// <copyright file="CsharpHeuristics.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace libpolyglot.Heuristics
{
    using System.Linq;

#pragma warning disable SA1401 // Fields must be private
#pragma warning disable SA1117 // Parameters must be on same line or separate lines

    internal static class CsharpHeuristics
    {
        public static IHeuristic MicrosoftCSharpLibraryReference =
            new BooleanHeuristic(nameof(MicrosoftCSharpLibraryReference), Language.CSharp,
                data => data.ReferencedAssemblyNames.Contains("Microsoft.CSharp"));

        public static IHeuristic AnonymousTypeCompilerName =
            new BooleanHeuristic(nameof(AnonymousTypeCompilerName), Language.CSharp,
                data => data.InternalTypeNames.Any(t => t.Contains("<>f__")));

        public static IHeuristic StateMachineCompilerName =
            new BooleanHeuristic(nameof(StateMachineCompilerName), Language.CSharp,
                data => data.InternalTypeNames.Any(t => t.Contains("+<") && t.Contains(">d__")));
    }

#pragma warning restore SA1401 // Fields must be private
#pragma warning restore SA1117 // Parameters must be on same line or separate lines

}
