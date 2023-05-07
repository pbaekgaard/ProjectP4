using Antlr4.Runtime;
using Xunit.Abstractions;
using vGutCompiler;
using ProjectP4;

namespace Unit_Tests
{
    public class CodeGenerationOutputsVBA
    {
        private readonly ITestOutputHelper output;
        public CodeGenerationOutputsVBA(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void CodeGeneratorOutputsCorrectVBA()
        {
            //ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream(@"number A2 = 10\n bool A3 = A2 < 20"));
            //ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors();
            visitor.Visit(parser.program());

            var exceptedOutput = "Dim A2 As Double\nA2 = 10.0\nDim A3 As Boolean\nA3 = True\n";
            string actualOutput = visitor.codeG.Code;
            //ASSERT
            Assert.Equal(exceptedOutput, actualOutput);
        }
    }
}