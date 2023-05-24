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
            if (!File.Exists(String.Format("{0}\\{1}.SLE", Directory.GetCurrentDirectory(), file)))
            {
                Console.WriteLine("File does not exist, try again");
                return;
            }
            #endif
            fileName += string.Format("{0}.SLE",file);
            StreamReader InputFile = new(fileName);

            AntlrInputStream inputStream = new AntlrInputStream(InputFile.ReadToEnd());
            GLexer lexer = new GLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokens);

            Visitors visitor = new Visitors(fileName);

            visitor.Visit(parser.program());

            using (StreamWriter output = new StreamWriter(string.Format("{0}.bas",file)))
            {
                output.WriteLine(visitor.codeG.Code);
            }
            Console.WriteLine(string.Format("Script has been compiled, output file is: {0}.bas",file));
            IParseTree tree = parser.program();
            return;
        }
    }
}
