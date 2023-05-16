using Antlr4.Runtime;
using Xunit.Abstractions;
using vGutCompiler;
using ProjectP4;
using Moq;
using Antlr4.Runtime.Tree;
using System.Reflection.Metadata.Ecma335;
using Xunit.Sdk;

namespace Unit
{
    public class Tests
    {
        [Fact]
        public void TokensAreCorrect()
        {
            //ARRANGE
            GLexer lexer = new GLexer(new AntlrInputStream(@"number A2 = 10\n bool A3 = A2 < 20"));
            //ACT
            var tokens = lexer.GetAllTokens();

            var expectedTokens = new List<int>
            {
                GLexer.NUMBERDCL,
                GLexer.VAR,
                GLexer.ASSIGN,
                GLexer.INTEGER,
                GLexer.BOOLDCL,
                GLexer.VAR,
                GLexer.ASSIGN,
                GLexer.VAR,
                GLexer.LESSTHAN,
                GLexer.INTEGER
            };

            var actualTokens = tokens.Select(x => x.Type).ToList();
            //ASSERT
            Assert.Equal(expectedTokens, actualTokens);
        }
        [Fact]
        public void SymbolTableCorrectlyAddstoSymbolTable()
        {
            //ARRANGE
            SymTable SymbolTable = new SymTable();
            //ACT
            Symbol testSymbol = new();
            testSymbol.value = "testValue";
            testSymbol.type = Symbol.symbolType.text;
            SymbolTable.addSymbol("TestSymbol", testSymbol);
            //ASSERT
            Assert.Equal(testSymbol.value, SymbolTable.getSymbol("TestSymbol").value);
        }
        [Fact]
        public void SymbolTableCorrectlyUpdatesSymbol()
        {
            // ARRANGE
            SymTable SymbolTable = new();
            Symbol testSymbol = new();
            testSymbol.value = "startValue";
            testSymbol.type = Symbol.symbolType.text;
            SymbolTable.addSymbol("test", testSymbol);
            // ACT
            testSymbol.value = "endValue";
            SymbolTable.updateSymbol("test", testSymbol);

            // ASSERT
            Assert.Equal("endValue", SymbolTable.getSymbol("test").value);

        }
        [Fact]
        public void SymbolTableCorrectlyThrowsErrorOnMissingSymbol()
        {
            // ARRANGE
            SymTable SymbolTable = new();

            // ACT
            Symbol testSymbol = new();
            testSymbol.value = "startValue";
            testSymbol.type = Symbol.symbolType.text;
            SymbolTable.addSymbol("existingSymbol", testSymbol);

            // ASSERT
            var exceptionUpdate = Assert.Throws<Exception>(() => SymbolTable.updateSymbol("MissingSymbol", testSymbol));
            Assert.Equal(exceptionUpdate.Message, "MissingSymbol is not declared");
        }

        [Fact]
        public void CodeGeneration_GeneratesCorrectVLOOKUP()
        {
            //ARRANGE
            CodeGenerator CodeGen = new();

            // ACT
            CodeGen.VLookUpFunction(10, "A1", "B4", 2, false);
            string actual = CodeGen.Code;

            string expected = "WorksheetFunction.VLOOKUP(10, Range(\"A1:B4\"), 2, False)";
            // ASSERT
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CodeGeneration_GeneratesCorrectSORT()
        {
            //ARRANGE
            CodeGenerator CodeGen = new();

            // ACT
            CodeGen.SortFunction("A1", "A4", "B2", "true");
            string actual = CodeGen.Code;

            string expected = "Range(\"A1:A4\").Copy Destination:=Range(\"B2\")\nRange(\"B2:B5\").Sort Key1:=Range(\"B2\"), Order1:=xlAscending, Header:=xlNo\n";
            // ASSERT
            Assert.Equal(expected, actual);
        }
    }
}