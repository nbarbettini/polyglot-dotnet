// <copyright file="CsharpHeuristics.cs" company="Nate Barbettini">
// Copyright (c) Nate Barbettini. Licensed under MIT.
// </copyright>

namespace Polyglot.Heuristics
{
    using System.Linq;
    using System.Text.RegularExpressions;

#pragma warning disable SA1401 // Fields must be private
#pragma warning disable SA1117 // Parameters must be on same line or separate lines
#pragma warning disable SA1202 // Public members must come before private members

    internal static class CsharpHeuristics
    {
        public static IHeuristic MicrosoftCSharpLibraryReference =
            new BooleanHeuristic(nameof(MicrosoftCSharpLibraryReference), Language.CSharp,
                data => data.ReferencedAssemblyNames.Contains("Microsoft.CSharp"));

        // <>__AnonType0`2
        private static readonly Regex CompilerGeneratedTypeName
            = new Regex("<>.*__", RegexOptions.Compiled);

        public static IHeuristic CompilerGeneratedType =
            new BooleanHeuristic(nameof(CompilerGeneratedType), Language.CSharp,
                data => data.InternalTypeNames.Any(t => CompilerGeneratedTypeName.IsMatch(t)));

        // EmptyCS.Program+<WaitAsync>c__async0
        private static readonly Regex StateMachineGeneratedTypeName
            = new Regex(".*\\+<.*>.__", RegexOptions.Compiled);

        public static IHeuristic StateMachineGeneratedType =
            new BooleanHeuristic(nameof(StateMachineGeneratedType), Language.CSharp,
                data => data.InternalTypeNames.Any(t => StateMachineGeneratedTypeName.IsMatch(t)));
    }

#pragma warning restore SA1401 // Fields must be private
#pragma warning restore SA1117 // Parameters must be on same line or separate lines
#pragma warning restore SA1202 // Public members must come before private members
}
