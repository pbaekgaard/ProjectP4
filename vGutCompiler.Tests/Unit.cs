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
            string expected = "WorksheetFunction.VLOOKUP(10, Range(\"A1:B4\"), 2, False)";

            // ACT
            CodeGen.VLookUpFunction(10, "A1", "B4", 2, false);
            string actual = CodeGen.Code;

            // ASSERT
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CodeGeneration_GeneratesCorrectSORT()
        {
            //ARRANGE
            CodeGenerator CodeGen = new();
            string expected = "Range(\"A1:A4\").Copy Destination:=Range(\"B2\")\nRange(\"B2:B5\").Sort Key1:=Range(\"B2\"), Order1:=xlAscending, Header:=xlNo\n";
            
            // ACT
            CodeGen.SortFunction("A1", "A4", "B2", "true");
            string actual = CodeGen.Code;

            // ASSERT
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenStartSub(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "Sub Test ()\n";

            //Act
            CodeGen.startSub("Test");
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenEndSub(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "End Sub\n";

            //Act
            CodeGen.endSub();
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenAssignVariable(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "Range(\"TestVariable\").Value = ";

            //Act
            CodeGen.AssignVariable("TestVariable");
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenUpdateVariable(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "Range(\"TestVariable\").Value = ";

            //Act
            CodeGen.UpdateVariable("TestVariable");
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenValueTestInt(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "10.0 ";
            int testValue = 10;

            //Act
            CodeGen.Value(testValue);
            string actual = CodeGen.Code;
            
            //Assert
            Assert.Equal(expected, actual);
        }

        // Test fejler fordi codeGen fjerner kommatallet fra double
        [Fact]
        public void CodeGenValueTestDouble(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "10.0 ";
            double testValue = 10.0;

            //Act
            CodeGen.Value(testValue);
            string actual = CodeGen.Code;
            
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenVariable(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "Range(\"Foo\").Value ";

            //Act
            CodeGen.Variable("Foo");
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenWhileStmtStart(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "While ";

            //Act
            CodeGen.WhilestmtStart();
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenWhileStmtEnd(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "Wend\n";

            //Act
            CodeGen.WhilestmtEnd();
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenIfStart(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "If ";

            //Act
            CodeGen.IfStart();
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenIfThen(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "Then\n";

            //Act
            CodeGen.IfThen();
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenElseStatement(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "Else\n";

            //Act
            CodeGen.elseStatement();
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenEndIf(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "End If\n";

            //Act
            CodeGen.endIf();
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenNewLine(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "\n";

            //Act
            CodeGen.NewLine();
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenSum(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "WorksheetFunction.Sum(Range(\"A1:A2\"))";
            string TestStartValue = "A1";
            string TestEndValue = "A2";

            //Act
            CodeGen.sum(TestStartValue, TestEndValue);
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenAverage(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "WorksheetFunction.AVERAGE(Range(\"A1:A2\"))"; 
            string TestStartValue = "A1";
            string TestEndValue = "A2";

            //Act
            CodeGen.average(TestStartValue, TestEndValue);
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenMaxFunction(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "WorksheetFunction.Max(Range(\"A1:A2\"))";
            string TestStartValue = "A1";
            string TestEndValue = "A2";

            //Act
            CodeGen.MaxFunction(TestStartValue, TestEndValue);
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenMinFunction(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "WorksheetFunction.Min(Range(\"A1:A2\"))";
            string TestStartValue = "A1";
            string TestEndValue = "A2";

            //Act
            CodeGen.MinFunction(TestStartValue, TestEndValue);
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenCount(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "WorksheetFunction.Count(Range(\"A1:A2\"))"; 
            string TestStartValue = "A1";
            string TestEndValue = "A2";

            //Act
            CodeGen.Count(TestStartValue, TestEndValue);
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CodeGenCountSpecific(){
            //Arrange
            CodeGenerator CodeGen = new();
            string expected = "WorksheetFunction.CountIf(Range(\"A1:A2\"), 3)";
            string TestStartValue = "A1";
            string TestEndValue = "A2";
            int specificValue = 3;

            //Act
            CodeGen.Count(TestStartValue, TestEndValue, specificValue);
            string actual = CodeGen.Code;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
