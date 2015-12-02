using System.Reflection;
using Shouldly;
using Xunit;

namespace libpolyglot.Tests
{
    public class Sanity_tests
    {
        [Fact]
        public void Self_reports_as_csharp()
        {
            var analyzer = new AssemblyAnalyzer(Assembly.GetExecutingAssembly());

            var result = analyzer.DetectedLanguage;
            result.ShouldBe(Language.CSharp);
        }
    }
}
