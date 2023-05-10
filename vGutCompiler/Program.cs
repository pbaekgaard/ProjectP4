using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using ProjectP4;

namespace vGutCompiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string fileName = "";
            string file = "";
            #if DEBUG
            file = "input";
            #else
            if (args.Length != 0)
            {
                if (args[0] == "-i")
                {
                    if (args.Length > 1)
                    {
                        if (args[1] != null)
                        {
                            file = args[1];

                        }
                        else
                        {
                            Console.WriteLine("Invalid file name");
                            return;
                        }
                    } else
                    {
                        Console.WriteLine("No file name given (second arg)");
                        return;
                    }
                } else
                {
                    Console.WriteLine("First arg need to be '-i'");
                    return;
                }
            } else
            {
                Console.WriteLine("Please type your input file (without extension)");
                file = Console.ReadLine();
                if (string.IsNullOrEmpty(file))
                {
                    Console.WriteLine("File name invalid");
                    return;
                }
            }
            if (!File.Exists(String.Format("{0}\\{1}.vGut", Directory.GetCurrentDirectory(), file)))
            {
                Console.WriteLine("File does not exist, try again");
                return;
            }
            #endif
            fileName += string.Format("{0}.vGut",file);
            StreamReader InputFile = new(string.Format("{0}.vGut",file));

            AntlrInputStream inputStream = new AntlrInputStream(InputFile.ReadToEnd());
            //ICharStream stream = CharStreams.fromString(InputFile.ReadToEnd());
            GLexer lexer = new GLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);
            Visitors visitor = new Visitors(fileName);
            visitor.codeG = new(file);

            visitor.Visit(parser.program());
            Console.WriteLine("\n\n");
            Console.WriteLine("INPUT CODE:\n--------------------------\n");
            Console.WriteLine(new StreamReader("./input.vGut").ReadToEnd());
            Console.WriteLine("\n\nOUTPUT CODE:\n--------------------------\n");
            Console.WriteLine(visitor.codeG.Code);
            Console.ReadLine();

            IParseTree tree = parser.program();
            return;
        }
    }
}
