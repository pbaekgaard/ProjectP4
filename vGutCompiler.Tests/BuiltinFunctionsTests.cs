using Antlr4.Runtime;
using Xunit.Abstractions;
using vGutCompiler;
using ProjectP4;

namespace Unit_Tests
{
    public class BuiltinFunctionsTests
    {
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

            var expectedOutput = "Sub test ()\nDim A2 As Double\nA2 = 10.0\nRange(\"A2\").Value = 10.0\nDim A3 As Double\nA3 = 10.0\nRange(\"A3\").Value = 10.0\nDim A4 As Double\nA4 = 10.0\nRange(\"A4\").Value = 10.0\nDim A6 As Double\nA6 = 0.0\nRange(\"A6\").Value = 0.0\nA6 = WorksheetFunction.Sum(Range(\"A2:A4\"))\nRange(\"A6\").Value = WorksheetFunction.Sum(Range(\"A2:A4\"))\nEnd Sub\n";
            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Fact]
        public void CodeGenerationProducesCorrectMin()
        {
            // ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream("number A2 = 10\nnumber A3 = 10\nnumber A4 = 10\nnumber A6 = 0\nA6 = MIN(A2:A4)"));

            // ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors("test");
            visitor.Visit(parser.program());

            var expectedOutput = "Sub test ()\nDim A2 As Double\nA2 = 10.0\nRange(\"A2\").Value = 10.0\nDim A3 As Double\nA3 = 10.0\nRange(\"A3\").Value = 10.0\nDim A4 As Double\nA4 = 10.0\nRange(\"A4\").Value = 10.0\nDim A6 As Double\nA6 = 0.0\nRange(\"A6\").Value = 0.0\nA6 = WorksheetFunction.Min(Range(\"A2:A4\"))\nRange(\"A6\").Value = WorksheetFunction.Min(Range(\"A2:A4\"))\nEnd Sub\n";
            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void CodeGenerationProducesCorrectMax()
        {
            // ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream("number A2 = 10\nnumber A3 = 10\nnumber A4 = 10\nnumber A6 = 0\nA6 = MAX(A2:A4)"));

            // ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors("test");
            visitor.Visit(parser.program());

            var expectedOutput = "Sub test ()\nDim A2 As Double\nA2 = 10.0\nRange(\"A2\").Value = 10.0\nDim A3 As Double\nA3 = 10.0\nRange(\"A3\").Value = 10.0\nDim A4 As Double\nA4 = 10.0\nRange(\"A4\").Value = 10.0\nDim A6 As Double\nA6 = 0.0\nRange(\"A6\").Value = 0.0\nA6 = WorksheetFunction.Max(Range(\"A2:A4\"))\nRange(\"A6\").Value = WorksheetFunction.Max(Range(\"A2:A4\"))\nEnd Sub\n";
            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void SortCopysTheDataRangeAndSortsTheCopiedAtDestination()
        {
            // ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream(@"number A1 = 0\n number A2 = 1\n number A3 = 3\n number A4 = 2\n SORT(A2:A4, A1, true)\n"));

            // ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            Visitors visitor = new Visitors("test");
            visitor.Visit(parser.program());

            string expectedOutput = "Sub test ()\nDim A1 As Double\nA1 = 0.0\nRange(\"A1\").Value = 0.0\nDim A2 As Double\nA2 = 1.0\nRange(\"A2\").Value = 1.0\nDim A3 As Double\nA3 = 3.0\nRange(\"A3\").Value = 3.0\nDim A4 As Double\nA4 = 2.0\nRange(\"A4\").Value = 2.0\nRange(\"A2:A4\").Copy Destination:=Range(\"A1\")\nRange(\"A1:A3\").Sort Key1:=Range(\"A1\"), Order1:=xlAscending, Header:=xlNo\nEnd Sub\n";
            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }


        [Fact]
        public void CountProducesTheCorrectCountForVBA()
        {
            // ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream(@"number A1 = 0\n number A2 = 1\n number A3 = 3\n number A4 = 2\n number A5 = COUNT(A2:A4)\n"));

            // ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            Visitors visitor = new Visitors("test");
            visitor.Visit(parser.program());

            string expectedOutput = "Sub test ()\nDim A1 As Double\nA1 = 0.0\nRange(\"A1\").Value = 0.0\nDim A2 As Double\nA2 = 1.0\nRange(\"A2\").Value = 1.0\nDim A3 As Double\nA3 = 3.0\nRange(\"A3\").Value = 3.0\nDim A4 As Double\nA4 = 2.0\nRange(\"A4\").Value = 2.0\nDim A5 As Double\nA5 = WorksheetFunction.Count(Range(\"A2:A4\"))\nRange(\"A5\").Value = WorksheetFunction.Count(Range(\"A2:A4\"))\nEnd Sub\n";
            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void CountIfProducesTheCorrectCountIfForVBA()
        {
            // ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream(@"number A1 = 0\n number A2 = 1\n number A3 = 3\n number A4 = 2\n number A5 = COUNT(A1:A3, 2)\n"));

            // ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            Visitors visitor = new Visitors("test");
            visitor.Visit(parser.program());

            string expectedOutput = "Sub test ()\nDim A1 As Double\nA1 = 0.0\nRange(\"A1\").Value = 0.0\nDim A2 As Double\nA2 = 1.0\nRange(\"A2\").Value = 1.0\nDim A3 As Double\nA3 = 3.0\nRange(\"A3\").Value = 3.0\nDim A4 As Double\nA4 = 2.0\nRange(\"A4\").Value = 2.0\nDim A5 As Double\nA5 = WorksheetFunction.CountIf(Range(\"A1:A3\"), 2)\nRange(\"A5\").Value = WorksheetFunction.CountIf(Range(\"A1:A3\"), 2)\nEnd Sub\n";
            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }


    }
}
