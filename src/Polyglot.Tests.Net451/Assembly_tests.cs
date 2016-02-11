// <copyright file="Assembly_tests.cs" company="Nate Barbettini">
// Copyright (c) 2015 Nate Barbettini. Licensed under MIT.
// </copyright>

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using FluentAssertions;
using Xunit;

namespace libpolyglot.Tests
{
    public class Assembly_tests
    {
        public static IEnumerable<object[]> TestAssemblies()
        {
            // Sadly, not enough heuristic data to properly guess on these (yet).
            yield return new object[] { "EmptyCS.dll", "EmptyCS", null };
            yield return new object[] { "EmptyCSMono.dll", "EmptyCS", null };

            // VB.NET - not currently working!
            //yield return new object[] { "EmptyVB.dll", "EmptyVB", Language.Vb };
            //yield return new object[] { "AnonymousAsyncVB.dll", "AnonymousAsyncVB", Language.Vb };

            // C#
            yield return new object[] { "AnonymousAsyncCS.dll", "AnonymousAsyncCS", Language.CSharp };
            yield return new object[] { "AnonymousAsyncCSMono.dll", "AnonymousAsyncCS", Language.CSharp };
            yield return new object[] { "DynamicCS.dll", "DynamicCS", Language.CSharp };
            yield return new object[] { "DynamicCSMono.dll", "DynamicCS", Language.CSharp };

            // F#
            yield return new object[] { "EmptyFSharp.dll", "EmptyFSharp", Language.FSharp };
        }

        [Theory]
        [MemberData(nameof(TestAssemblies))]
        public void When_analyzing(string fileName, string assemblyName, Language? expected)
        {
            var context = new SingleTestLoadContext(fileName);
            var assembly = context.LoadFromAssemblyName(new AssemblyName(assemblyName));

            var analyzer = new AssemblyAnalyzer(assembly);

            analyzer.DetectedLanguage.Should().Be(expected);
        }

        public class SingleTestLoadContext : AssemblyLoadContext
        {
            private readonly string fileName;

            public SingleTestLoadContext(string fileName)
            {
                this.fileName = fileName;
            }

            protected override Assembly Load(AssemblyName assemblyName)
            {
                string assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\SampleTestAssemblies", fileName);
                return LoadFromAssemblyPath(assemblyPath);
            }
        }
    }
}
