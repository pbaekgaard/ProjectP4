using System;
using System.IO;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
//using vBadCompiler.CustomParser;
using ProjectP4;
namespace vBadCompiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StreamReader InputFile = new("input.txt");
            ICharStream stream = CharStreams.fromString(InputFile.ReadToEnd());
            ITokenSource lexer = new GrammarLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            var visitor = new Visitors();
            visitor.Visit(parser.program());
            foreach (var scope in visitor.symbolTable.scopedSymbolTable)
            {
                foreach (var symbol in scope)
                {
                    Console.WriteLine("Symbol: {0} - Type: {1} - Value: {2}", symbol.Key.ToString(), symbol.Value.type.ToString(), symbol.Value.value.ToString());
                }
            }
            Console.ReadLine();

            IParseTree tree = parser.program();
        }
    }
}
