// <copyright file="HeuristicProvider.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

namespace libpolyglot.Heuristics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class HeuristicProvider
    {
        private static readonly Lazy<List<IHeuristic>> DiscoveredHeuristics =
            new Lazy<List<IHeuristic>>(() =>
            {
                return new Type[]
                {
                    typeof(VbHeuristics),
                    typeof(CsharpHeuristics),
                    typeof(FsharpHeuristics),
                }
                .SelectMany(t => t.GetFields(BindingFlags.Public | BindingFlags.Static))
                .Select(f => (IHeuristic)f.GetValue(null))
                .ToList();
            });

        public static IEnumerable<IHeuristic> GetAll() => DiscoveredHeuristics.Value;
    }
}
