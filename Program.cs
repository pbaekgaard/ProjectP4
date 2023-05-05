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
