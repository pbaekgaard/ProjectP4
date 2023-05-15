using Antlr4.Runtime;
using Xunit.Abstractions;
using vGutCompiler;
using ProjectP4;

namespace Unit_Tests
{
    public class IntegrationTests
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
        [Fact]
        public void CodeGenerationProducesCorrectVLOOKUP()
        {
            // ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream("number A2 = 10\nnumber A3 = 10\nnumber A4 = 10\nnumber A6 = 0\nA6 = VLOOKUP(10, A2:A4, 1, false)"));

            // ACT
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors("test");
            visitor.Visit(parser.program());

            var expectedOutput = "Sub test ()\nRange(\"A2\").Value = 10.0 \nRange(\"A3\").Value = 10.0 \nRange(\"A4\").Value = 10.0 \nRange(\"A6\").Value = 0.0 \nRange(\"A6\").Value = WorksheetFunction.VLOOKUP(Range(\"A2:A4\"))\nEnd Sub\n";
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

            var expectedOutput = "Sub test ()\nRange(\"A2\").Value = 10.0 \nRange(\"A3\").Value = 10.0 \nRange(\"A4\").Value = 10.0 \nRange(\"A6\").Value = 0.0 \nRange(\"A6\").Value = WorksheetFunction.Min(Range(\"A2:A4\"))\nEnd Sub\n";
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

            var expectedOutput = "Sub test ()\nRange(\"A2\").Value = 10.0 \nRange(\"A3\").Value = 10.0 \nRange(\"A4\").Value = 10.0 \nRange(\"A6\").Value = 0.0 \nRange(\"A6\").Value = WorksheetFunction.Max(Range(\"A2:A4\"))\nEnd Sub\n";
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

            string expectedOutput = "Sub test ()\nRange(\"A1\").Value = 0.0 \nRange(\"A2\").Value = 1.0 \nRange(\"A3\").Value = 3.0 \nRange(\"A4\").Value = 2.0 \nRange(\"A2:A4\").Copy Destination:=Range(\"A1\")\nRange(\"A1:A3\").Sort Key1:=Range(\"A1\"), Order1:=xlAscending, Header:=xlNo\nEnd Sub\n";
            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }


        [Fact]
        public void CodeGenAverage()
        {
            //Arrange
            GLexer lexer = new GLexer(new AntlrInputStream(@"number B2 = 2\n number B3 = 6\n number A2 = AVERAGE(B2:B3)"));

            //Act
            CommonTokenStream Tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(Tokens);
            var visitor = new Visitors("test");
            visitor.Visit(parser.program());

            string expected = "Sub test ()\nRange(\"B2\").Value = 2.0 \nRange(\"B3\").Value = 6.0 \nRange(\"A2\").Value = WorksheetFunction.AVERAGE(Range(\"B2:B3\"))\nEnd Sub\n";
            string actual = visitor.codeG.Code;

            //Assert
            Assert.Equal(expected, actual);
        }
        // [Fact]
        // public void CodeGenerationProducesCorrectWhileLoops()
        // {
        //     GLexer lexer = new GLexer(new AntlrInputStream(@"number A2 = 10\n while A2 == 10\n A2 = 11 endwhile"));


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

            string expectedOutput = "Sub test ()\nRange(\"A1\").Value = 0.0 \nRange(\"A2\").Value = 1.0 \nRange(\"A3\").Value = 3.0 \nRange(\"A4\").Value = 2.0 \nRange(\"A5\").Value = WorksheetFunction.Count(Range(\"A2:A4\"))\nEnd Sub\n";
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

            string expectedOutput = "Sub test ()\nRange(\"A1\").Value = 0.0 \nRange(\"A2\").Value = 1.0 \nRange(\"A3\").Value = 3.0 \nRange(\"A4\").Value = 2.0 \nRange(\"A5\").Value = WorksheetFunction.CountIf(Range(\"A1:A3\"), 2)\nEnd Sub\n";
            string actualOutput = visitor.codeG.Code;

            //ASSERT
            Assert.Equal(expectedOutput, actualOutput);
        }


    }
}
