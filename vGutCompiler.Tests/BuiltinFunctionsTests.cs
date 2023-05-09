using Antlr4.Runtime;
using Xunit.Abstractions;
using vGutCompiler;
using ProjectP4;

namespace Unit_Tests
{
    public class BuiltinFunctionsTests
    {
        [Fact]
        public void MinProducesTheCorrectMinForVBA()
        {
            //ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream(@"number A2 = 10\n bool A3 = A2 < 20"));
            //ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors();
            visitor.Visit(parser.program());

            var expectedOutput = "Dim A2 As Double\nA2 = 10\nRange(\"A2\").Value = 10\nDim A3 As Boolean\nA3 = True\nRange(\"A3\").Value = True\n";
            string actualOutput = visitor.codeG.Code;
            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void MaxProducesTheCorrectMaxForVBA()
        {
            // ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream(@"number A2 = 10\n number A1 = 5\n if A2 > A1 then A2 = 20 endif"));

            // ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors();
            visitor.Visit(parser.program());

            var expectedOutput = "Dim A2 As Double\nA2 = 10\nRange(\"A2\").Value = 10\nDim A1 As Double\nA1 = 5\nRange(\"A1\").Value = 5\nIf A2 > A1 Then\nRange(\"A2\").Value = 20\nEnd If";
            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }

        // [Fact]
        // public void CodeGenerationProducesCorrectWhileLoops()
        // {
        //     GLexer lexer = new GLexer(new AntlrInputStream(@"number A2 = 10\n while A2 == 10\n A2 = 11 endwhile"));

        //     // ACT
        //     CommonTokenStream tokens = new CommonTokenStream(lexer);
        //     GrammarParser parser = new GrammarParser(tokens);
        //     var visitor = new Visitors();
        //     visitor.Visit(parser.program());

        //     var expectedOutput = "Dim A2 As Double\nA2 = 10\nDo While A2 == 10\nA2 = 11\nLoop";
        //     string actualOutput = visitor.codeG.Code;

        //     //ASSERT
        //     Assert.Equal(expectedOutput, actualOutput);
        // }
    }
}
