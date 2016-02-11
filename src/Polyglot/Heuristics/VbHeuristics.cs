// <copyright file="VbHeuristics.cs" company="Nate Barbettini">
// Copyright (c) Nate Barbettini. Licensed under MIT.
// </copyright>

namespace Polyglot.Heuristics
{
    using System.Linq;

#pragma warning disable SA1401 // Fields must be private
#pragma warning disable SA1117 // Parameters must be on same line or separate lines

    internal static class VbHeuristics
    {
        public static IHeuristic MicrosoftVisualBasicLibraryReference =
            new BooleanHeuristic(nameof(MicrosoftVisualBasicLibraryReference), Language.Vb,
                data => data.ReferencedAssemblyNames.Contains("Microsoft.VisualBasic"));

        public static IHeuristic AnonymousTypeCompilerName =
            new BooleanHeuristic(nameof(AnonymousTypeCompilerName), Language.Vb,
                data => data.InternalTypeNames.Any(t => t.Contains("VB$AnonymousType_")));

        public static IHeuristic VBStateMachineCompilerName =
            new BooleanHeuristic(nameof(VBStateMachineCompilerName), Language.Vb,
                data => data.InternalTypeNames.Any(t => t.Contains("+VB$StateMachine_")));

        public static IHeuristic ThreadSafeObjectProviderPresent =
            new BooleanHeuristic(nameof(ThreadSafeObjectProviderPresent), Language.Vb,
                data => data.InternalTypeNames.Any(t => t.Contains("My.MyProject+ThreadSafeObjectProvider")));

        public static IHeuristic MyResourcesDotResources =
            new BooleanHeuristic(nameof(MyResourcesDotResources), Language.Vb,
                data => data.InternalTypeNames.Any(t => t.Contains("My.Resources.Resources")));

        public static IHeuristic MySettings =
            new BooleanHeuristic(nameof(MySettings), Language.Vb,
                data => data.InternalTypeNames.Any(t => t.Contains("My.MySettings")));

        public static IHeuristic MySettingsProperty =
            new BooleanHeuristic(nameof(MySettingsProperty), Language.Vb,
                data => data.InternalTypeNames.Any(t => t.Contains("My.MySettingsProperty")));

        public static IHeuristic MyApplication =
            new BooleanHeuristic(nameof(MyApplication), Language.Vb,
                data => data.InternalTypeNames.Any(t => t.Contains("My.MyApplication")));

        public static IHeuristic MyComputer =
            new BooleanHeuristic(nameof(MyComputer), Language.Vb,
                data => data.InternalTypeNames.Any(t => t.Contains("My.MyComputer")));

        public static IHeuristic MyProject =
            new BooleanHeuristic(nameof(MyProject), Language.Vb,
                data => data.InternalTypeNames.Any(t => t.Contains("My.MyProject")));

        public static IHeuristic MyProjectMyWebServices =
            new BooleanHeuristic(nameof(MyProjectMyWebServices), Language.Vb,
                data => data.InternalTypeNames.Any(t => t.Contains("My.MyProject+MyWebServices")));
    }

#pragma warning restore SA1401 // Fields must be private
#pragma warning restore SA1117 // Parameters must be on same line or separate lines

}
