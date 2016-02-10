using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Shouldly;
using Xunit;

namespace libpolyglot.Tests
{
    public class Assembly_tests
    {
        public static IEnumerable<object[]> TestAssemblies()
        {
            // Sadly, not enough heuristic data to properly guess on these (yet).
            yield return new object[] { "EmptyCS.dll", null };
            yield return new object[] { "EmptyCSMono.dll", null };

            // VB.NET
            yield return new object[] { "EmptyVB.dll", Language.Vb };
            yield return new object[] { "AnonymousAsyncVB.dll", Language.Vb };

            // C#
            yield return new object[] { "AnonymousAsyncCS.dll", Language.CSharp };
            yield return new object[] { "AnonymousAsyncCSMono.dll", Language.CSharp };
            yield return new object[] { "DynamicCS.dll", Language.CSharp };
            yield return new object[] { "DynamicCSMono.dll", Language.CSharp };

            // F#
            yield return new object[] { "EmptyFSharp.dll", Language.FSharp };
        }

        [Theory]
        [MemberData(nameof(TestAssemblies))]
        public void When_analyzing(string file, Language? expected)
        {
            var assembly = Assembly.LoadFrom($"TestAssemblies{Path.DirectorySeparatorChar}{file}");
            var analyzer = new AssemblyAnalyzer(assembly);

            analyzer.DetectedLanguage.ShouldBe(expected);
        }
    }
}
