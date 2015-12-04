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
            yield return new object[] { "EmptyVB.dll", Language.Vb };
            yield return new object[] { "EmptyCS.dll", Language.CSharp };
            yield return new object[] { "AnonymousAsyncVB.dll", Language.Vb };
            yield return new object[] { "AnonymousAsyncCS.dll", Language.CSharp };
            yield return new object[] { "DynamicCS.dll", Language.CSharp };
            yield return new object[] { "EmptyFSharp.dll", Language.FSharp };
        }

        [Theory]
        [MemberData(nameof(TestAssemblies))]
        public void When_analyzing(string file, Language expected)
        {
            var assembly = Assembly.LoadFrom($"TestAssemblies{Path.DirectorySeparatorChar}{file}");
            var analyzer = new AssemblyAnalyzer(assembly);

            analyzer.DetectedLanguage.ShouldBe(expected);
        }
    }
}
