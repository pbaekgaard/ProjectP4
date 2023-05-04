using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using ProjectP4;
namespace vGutCompiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StreamReader InputFile = new("input.txt");
            AntlrInputStream inputStream = new AntlrInputStream(InputFile.ReadToEnd());

            //ICharStream stream = CharStreams.fromString(InputFile.ReadToEnd());
            GLexer lexer = new GLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
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
            Console.WriteLine("\n\n");
            Console.WriteLine("INPUT CODE:\n--------------------------\n");
            Console.WriteLine(new StreamReader("input.txt").ReadToEnd());
            Console.WriteLine("\n\nOUTPUT CODE:\n--------------------------\n");
            Console.WriteLine(visitor.codeG.Code);
            Console.ReadLine();

            IParseTree tree = parser.program();

        }
    }
}
