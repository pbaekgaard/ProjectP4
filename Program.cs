using System;
using System.IO;
using System.Text.RegularExpressions;

namespace vBadCompiler
{
    public class UnknownTypeException : Exception
    {
        private string? message;
        public UnknownTypeException()
        {

        }
        public UnknownTypeException(string message)
        {
            this.message = message;
        }
    }
    public class Token
    {
        public TokenType? Type { get; set; }
        public string? Value { get; set; }
        public Token(TokenType? type, string? val)
        {
            this.Type = type;
            this.Value = val;
        }
        public Token()
        {

        }
    }

    public enum TokenType
    {
        NUMBER,
        LETTER,
        WHITESPACE,
        NUMBERDCL,
        TEXTDCL,
        BOOLEANDCL,
        BOOLEAN,
        TEXT,
        IF,
        THEN,
        ELSE,
        ENDIF,
        WHILE,
        ENDWHILE,
        DO,
        ASSIGN,
        LT,
        GT,
        CE,
        LE,
        GE,
        NE,
        PLUS,
        MINUS,
        MULTIPLICATION,
        DIVISION,
        LPAREN,
        RPAREN,
        COMMENT,
        EOF
    }

    public class Scanner
    {
        private StreamReader inputStream;

        public Scanner(StreamReader input)
        {
            inputStream = input;
        }

        public Token Scan()
        {
            Token scannedToken = new();
            while (inputStream.Peek() == ' ' || inputStream.Peek() == '\n' || inputStream.Peek() == '\r' || inputStream.Peek() == '\t')
            {
                inputStream.Read();
            }
            if (inputStream.Peek() == -1)
            {
                inputStream.Read();
                scannedToken = new(TokenType.EOF, "$");
            }
            else
            {
                switch ((char)inputStream.Peek())
                {
                    case ('1'):
                    case ('2'):
                    case ('3'):
                    case ('4'):
                    case ('5'):
                    case ('6'):
                    case ('7'):
                    case ('8'):
                    case ('9'):
                        scannedToken.Value += (char)inputStream.Read();
                        while (char.IsDigit((char)inputStream.Peek()) || (char)inputStream.Peek() == '.')
                        {
                            scannedToken.Value += (char)inputStream.Read();
                        }
                        scannedToken.Type = TokenType.NUMBER;
                        break;
                    case '\'':
                        scannedToken.Value += (char)inputStream.Read();
                        while ((char)inputStream.Peek() != '\'')
                        {
                            scannedToken.Value += (char)inputStream.Read();
                        }
                        scannedToken.Value += (char)inputStream.Read();
                        scannedToken.Type = TokenType.TEXT;
                        break;
                    case '\"':
                        scannedToken.Value += (char)inputStream.Read();
                        while ((char)inputStream.Peek() != '\"')
                        {
                            scannedToken.Value += (char)inputStream.Read();
                        }
                        scannedToken.Value += (char)inputStream.Read();
                        scannedToken.Type = TokenType.TEXT;
                        break;
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E':
                    case 'F':
                    case 'G':
                    case 'H':
                    case 'I':
                    case 'J':
                    case 'K':
                    case 'L':
                    case 'M':
                    case 'O':
                    case 'P':
                    case 'Q':
                    case 'R':
                    case 'S':
                    case 'U':
                    case 'V':
                    case 'W':
                    case 'X':
                    case 'Y':
                    case 'Z':
                        break;
                    case 'N':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 'u')
                        {
                            scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'm')
                                scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'b')
                                scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'e')
                                scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'r')
                                scannedToken.Value += (char)inputStream.Read();
                            if (char.IsWhiteSpace((char)inputStream.Peek()))
                            {
                                scannedToken.Type = TokenType.NUMBERDCL;
                                break;
                            }
                            throw new UnknownTypeException();
                        }
                        throw new Exception();
                    case 'T':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 'e')
                            scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 'x')
                            scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 't')
                            scannedToken.Value += (char)inputStream.Read();
                        if (char.IsWhiteSpace((char)inputStream.Peek()))
                        {
                            scannedToken.Type = TokenType.TEXTDCL;
                            break;
                        }
                        throw new UnknownTypeException();

                    case '\n':
                    case '\r':
                    case '\t':
                    case ' ':
                        break;
                    default:
                        throw new UnknownTypeException();
                }
            }
            return scannedToken;
        }
        public static void Main(string[] args)
        {
            StreamReader InputFile = new("input.txt");
            Scanner scanner = new(InputFile);
            Token testToken;
            do
            {
                testToken = scanner.Scan();
                Console.WriteLine("TokenType: " + testToken.Type + "\n" + "TokenValue: " + testToken.Value);
            } while (testToken.Type != TokenType.EOF);
        }
    }
}
