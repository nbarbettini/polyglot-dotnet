// <copyright file="Sanity_tests.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

using System.Reflection;
using FluentAssertions;
using Xunit;

namespace Polyglot.Tests
{
    public class Sanity_tests
    {
        [Fact]
        public void Reports_test_assembly_as_csharp()
        {
            var analyzer = new AssemblyAnalyzer(typeof(Sanity_tests).GetTypeInfo().Assembly);

            var result = analyzer.DetectedLanguage;
            result.Should().Be(Language.CSharp);
        }

        [Fact]
        public void Reports_library_assembly_as_csharp()
        {
            var analyzer = new AssemblyAnalyzer(typeof(AssemblyAnalyzer).GetTypeInfo().Assembly);

            var result = analyzer.DetectedLanguage;
            result.Should().Be(Language.CSharp);
        }
    }
}
