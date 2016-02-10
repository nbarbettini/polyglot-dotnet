using System.Reflection;
using Shouldly;
using Xunit;

namespace libpolyglot.Tests
{
    public class Sanity_tests
    {
        [Fact]
        public void Reports_test_assembly_as_csharp()
        {
            var analyzer = new AssemblyAnalyzer(Assembly.GetExecutingAssembly());

            var result = analyzer.DetectedLanguage;
            result.ShouldBe(Language.CSharp);
        }

        [Fact]
        public void Reports_library_assembly_as_csharp()
        {
            var analyzer = new AssemblyAnalyzer(typeof(AssemblyAnalyzer).Assembly);

            var result = analyzer.DetectedLanguage;
            result.ShouldBe(Language.CSharp);
        }
    }
}
