using Antlr4.Runtime;
using Xunit.Abstractions;
using vGutCompiler;
using ProjectP4;

namespace Unit_Tests
{
    public class CodeGenerationOutputsVBA
    {
        [Fact]
        public void CodeGeneratorOutputsCorrectProgram()
        {
            //ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream(@"number A2 = 1"));
            //ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors("test");
            visitor.Visit(parser.program());

            var expectedOutput = "Sub test ()\nRange(\"A2\").Value = 1.0 \nEnd Sub\n";

            string actualOutput = visitor.codeG.Code;
            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void CodeGeneratorOutputsCorrectVBA()
        {
            //ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream(@"number A2 = 10\n"));
            //ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors("test");
            visitor.Visit(parser.program());

            var expectedOutput = "Sub test ()\nRange(\"A2\").Value = 10.0 \nEnd Sub\n";

            string actualOutput = visitor.codeG.Code;
            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void CodeGenerationProducesCorrectIfStatements()
        {
            // ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream(@"number A2 = 10\n number A1 = 5\n if A2 > A1 AND A2 == 10 then A2 = 20 endif\n"));

            // ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors("test");
            visitor.Visit(parser.program());

            var expectedOutput = "Sub test ()\nRange(\"A2\").Value = 10.0 \nRange(\"A1\").Value = 5.0 \nIf Range(\"A2\").Value > Range(\"A1\").Value And Range(\"A2\").Value == 10.0 Then\nRange(\"A2\").Value = 20.0 \nEnd If\nEnd Sub\n";

            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void CodeGenerationProducesCorrectWhileLoops()
        {
            GLexer lexer = new GLexer(new AntlrInputStream(@"number A2 = 10\n while A2 == 10\n do A2 = 11 endwhile"));

            // ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors("test");
            visitor.Visit(parser.program());

            var expectedOutput = "Sub test ()\nRange(\"A2\").Value = 10.0 \nWhile Range(\"A2\").Value == 10.0 \nRange(\"A2\").Value = 11.0 \nWend\nEnd Sub\n";

            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void CodeGenerationProducesCorrectSum()
        {
            // ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream("number A2 = 10\nnumber A3 = 10\nnumber A4 = 10\nnumber A6 = 0\nA6 = SUM(A2:A4)"));

            // ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors("test");
            visitor.Visit(parser.program());

            var expectedOutput = "Sub test ()\nRange(\"A2\").Value = 10.0 \nRange(\"A3\").Value = 10.0 \nRange(\"A4\").Value = 10.0 \nRange(\"A6\").Value = 0.0 \nRange(\"A6\").Value = WorksheetFunction.Sum(Range(\"A2:A4\"))\nEnd Sub\n";
            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
