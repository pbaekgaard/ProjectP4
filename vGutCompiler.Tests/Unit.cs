using Antlr4.Runtime;
using Xunit.Abstractions;
using vGutCompiler;

namespace Unit_Tests
{
    public class Unit
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
    }
}