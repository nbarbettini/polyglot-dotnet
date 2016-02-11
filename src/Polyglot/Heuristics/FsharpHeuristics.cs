// <copyright file="FsharpHeuristics.cs" company="Nate Barbettini">
// Copyright (c) Nate Barbettini. Licensed under MIT.
// </copyright>

namespace Polyglot.Heuristics
{
    using System.Linq;

#pragma warning disable SA1401 // Fields must be private
#pragma warning disable SA1117 // Parameters must be on same line or separate lines

    internal static class FsharpHeuristics
    {
        public static IHeuristic FSharpCoreLibraryReference = new BooleanHeuristic(
            nameof(FSharpCoreLibraryReference),
            Language.FSharp,
            data => data.ReferencedAssemblyNames.Contains("FSharp.Core"));

        public static IHeuristic StartupCodeGeneratedName = new BooleanHeuristic(
            nameof(StartupCodeGeneratedName),
            Language.FSharp,
            data => data.InternalTypeNames.Any(t => t.StartsWith("<StartupCode$")));

        public static IHeuristic AssemblyInfoGeneratedName = new BooleanHeuristic(
            nameof(AssemblyInfoGeneratedName),
            Language.FSharp,
            data => data.InternalTypeNames.Any(t => t.EndsWith(".$AssemblyInfo")));

        public static IHeuristic NETFrameworkTypeReference = new BooleanHeuristic(
            nameof(NETFrameworkTypeReference),
            Language.FSharp,
            data => data.InternalTypeNames.Any(t => t.Contains(".$.NETFramework")));
    }

#pragma warning restore SA1401 // Fields must be private
#pragma warning restore SA1117 // Parameters must be on same line or separate lines

}
