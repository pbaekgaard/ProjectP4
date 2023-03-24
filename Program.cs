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
        LESSTHAN,
        GREATERTHAN,
        COMPAREEQUAL,
        LESSEQUAL,
        GREATEREQUAL,
        NOTEQUAL,
        PLUS,
        MINUS,
        MULTIPLICATION,
        DIVISION,
        LPAREN,
        RPAREN,
        COMMENT,
        CELL,
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
                    case 'f':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 'a') {
                            scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'l') {
                                scannedToken.Value += (char)inputStream.Read();
                                if ((char)inputStream.Peek() == 's') {
                                    scannedToken.Value += (char)inputStream.Read();
                                    if ((char)inputStream.Peek() == 'e') {
                                        scannedToken.Value += (char)inputStream.Read();
                                        scannedToken.Type = TokenType.BOOLEAN;
                                        break;
                                    }
                                }
                            }
                        }
                        throw new UnknownTypeException();
                    case 't':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 'r') {
                            scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'u') {
                                scannedToken.Value += (char)inputStream.Read();
                                if ((char)inputStream.Peek() == 'e') {
                                    scannedToken.Value += (char)inputStream.Read();
                                    scannedToken.Type = TokenType.BOOLEAN;
                                    break;
                                }
                            }
                        }
                        else if ((char)inputStream.Peek() == 'h') {
                            scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'e') {
                                scannedToken.Value += (char)inputStream.Read();
                                if ((char)inputStream.Peek() == 'n') {
                                    scannedToken.Value += (char)inputStream.Read();
                                    scannedToken.Type = TokenType.BOOLEAN;
                                    break;
                                }
                            }
                        }
                        throw new UnknownTypeException();
                    case 'i':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 'f') {
                            scannedToken.Value += (char)inputStream.Read();
                            scannedToken.Type = TokenType.IF;
                            break;
                        }
                        throw new UnknownTypeException();
                    case 'e':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 'l')
                        {
                            scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 's')
                                scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'e')
                                scannedToken.Value += (char)inputStream.Read();
                                scannedToken.Type = TokenType.ELSE;
                                break;
                        }
                        if ((char)inputStream.Peek() == 'n')
                        {
                            scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'd'){
                                scannedToken.Value += (char)inputStream.Read();
                                if((char)inputStream.Peek() == 'i'){
                                    scannedToken.Value += (char)inputStream.Read();
                                    if ((char)inputStream.Peek() == 'f')
                                        scannedToken.Value += (char)inputStream.Read();
                                        scannedToken.Type = TokenType.ENDIF;
                                        break;
                                }
                                if((char)inputStream.Peek() == 'w'){
                                    scannedToken.Value += (char)inputStream.Read();
                                    if ((char)inputStream.Peek() == 'h')
                                        scannedToken.Value += (char)inputStream.Read();
                                    if ((char)inputStream.Peek() == 'i')
                                        scannedToken.Value += (char)inputStream.Read();
                                    if ((char)inputStream.Peek() == 'l')
                                        scannedToken.Value += (char)inputStream.Read();
                                    if ((char)inputStream.Peek() == 'e')
                                        scannedToken.Value += (char)inputStream.Read();
                                        scannedToken.Type = TokenType.ENDWHILE;
                                        break;
                                }
                            }
                        }
                        throw new UnknownTypeException();
                    case 'w':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 'h') {
                            scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'i') {
                                scannedToken.Value += (char)inputStream.Read();
                                if ((char)inputStream.Peek() == 'l') {
                                    scannedToken.Value += (char)inputStream.Read();
                                    if ((char)inputStream.Peek() == 'e') {
                                        scannedToken.Value += (char)inputStream.Read();
                                        scannedToken.Type = TokenType.WHILE;
                                        break;
                                    }
                                }
                            }
                        }
                        throw new UnknownTypeException();
                    case 'd':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 'o') {
                            scannedToken.Value += (char)inputStream.Read();
                            scannedToken.Type = TokenType.DO;
                            break;

                        }
                        throw new UnknownTypeException();
                    case 'A':
                    case 'B':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 'o')
                        {
                            scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'o')
                            {
                                scannedToken.Value += (char)inputStream.Read();
                                if ((char)inputStream.Peek() == 'l')
                                {
                                    scannedToken.Value += (char)inputStream.Read();
                                    if ((char)inputStream.Peek() == 'e')
                                    {
                                        scannedToken.Value += (char)inputStream.Read();
                                        if ((char)inputStream.Peek() == 'a')
                                        {
                                            scannedToken.Value += (char)inputStream.Read();
                                            if ((char)inputStream.Peek() == 'n')
                                            {
                                                scannedToken.Value += (char)inputStream.Read();
                                                if (char.IsWhiteSpace((char)inputStream.Peek()))
                                                {
                                                    scannedToken.Type = TokenType.BOOLEANDCL;
                                                    break;
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        } else if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                            scannedToken.Value += (char)inputStream.Read();
                            while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(1)) <= 104857) {
                                if (Int32.Parse(scannedToken.Value.Substring(1)) == 104857) {
                                    if ((char)inputStream.Peek() <= '6') {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                    else {
                                        throw new UnknownTypeException();
                                    }
                                }
                                else {
                                    scannedToken.Value += (char)inputStream.Read();
                                }
                            }
                            if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                throw new UnknownTypeException();
                            }
                            scannedToken.Type = TokenType.CELL;
                            break;
                        }
                        else if (char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek())) {
                            scannedToken.Value += (char)inputStream.Read();
                            if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                scannedToken.Value += (char)inputStream.Read();
                                while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(2)) <= 104857) {
                                    if (Int32.Parse(scannedToken.Value.Substring(2)) == 104857) {
                                        if ((char)inputStream.Peek() <= '6') {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                        else {
                                            throw new UnknownTypeException();
                                        }
                                    }
                                    else {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                }
                                if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                    throw new UnknownTypeException();
                                }
                                scannedToken.Type = TokenType.CELL;
                                break;
                            }
                            else if (char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek())) {
                                scannedToken.Value += (char)inputStream.Read();
                                if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                    scannedToken.Value += (char)inputStream.Read();
                                    while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(3)) <= 104857) {
                                        if (Int32.Parse(scannedToken.Value.Substring(3)) == 104857) {
                                            if ((char)inputStream.Peek() <= '6') {
                                                scannedToken.Value += (char)inputStream.Read();
                                            }
                                            else {
                                                throw new UnknownTypeException();
                                            }
                                        }
                                        else {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                    }
                                    if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                        throw new UnknownTypeException();
                                    }
                                    scannedToken.Type = TokenType.CELL;
                                    break;
                                }
                            }
                        }
                        throw new UnknownTypeException();
                    case 'C':
                    case 'D':
                    case 'E':
                    case 'F':
                        scannedToken.Value += (char)inputStream.Read();
                        if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                            scannedToken.Value += (char)inputStream.Read();
                            while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(1)) <= 104857) {
                                if (Int32.Parse(scannedToken.Value.Substring(1)) == 104857) {
                                    if ((char)inputStream.Peek() <= '6') {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                    else {
                                        throw new UnknownTypeException();
                                    }
                                }
                                else {
                                    scannedToken.Value += (char)inputStream.Read();
                                }
                            }
                            if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                throw new UnknownTypeException();
                            }
                            scannedToken.Type = TokenType.CELL;
                            break;
                        }
                        else if (char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek())) {
                            scannedToken.Value += (char)inputStream.Read();
                            if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                scannedToken.Value += (char)inputStream.Read();
                                while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(2)) <= 104857) {
                                    if (Int32.Parse(scannedToken.Value.Substring(2)) == 104857) {
                                        if ((char)inputStream.Peek() <= '6') {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                        else {
                                            throw new UnknownTypeException();
                                        }
                                    }
                                    else {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                }
                                if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                    throw new UnknownTypeException();
                                }
                                scannedToken.Type = TokenType.CELL;
                                break;
                            }
                            else if (char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek())) {
                                scannedToken.Value += (char)inputStream.Read();
                                if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                    scannedToken.Value += (char)inputStream.Read();
                                    while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(3)) <= 104857) {
                                        if (Int32.Parse(scannedToken.Value.Substring(3)) == 104857) {
                                            if ((char)inputStream.Peek() <= '6') {
                                                scannedToken.Value += (char)inputStream.Read();
                                            }
                                            else {
                                                throw new UnknownTypeException();
                                            }
                                        }
                                        else {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                    }
                                    if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                        throw new UnknownTypeException();
                                    }
                                    scannedToken.Type = TokenType.CELL;
                                    break;
                                }
                            }
                        }
                        throw new UnknownTypeException();
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
                        scannedToken.Value += (char)inputStream.Read();
                        if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                            scannedToken.Value += (char)inputStream.Read();
                            while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(1)) <= 104857) {
                                if (Int32.Parse(scannedToken.Value.Substring(1)) == 104857) {
                                    if ((char)inputStream.Peek() <= '6') {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                    else {
                                        throw new UnknownTypeException();
                                    }
                                }
                                else {
                                    scannedToken.Value += (char)inputStream.Read();
                                }
                            }
                            if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                throw new UnknownTypeException();
                            }
                            scannedToken.Type = TokenType.CELL;
                            break;
                        }
                        else if (char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek())) {
                            scannedToken.Value += (char)inputStream.Read();
                            if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                scannedToken.Value += (char)inputStream.Read();
                                while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(2)) <= 104857) {
                                    if (Int32.Parse(scannedToken.Value.Substring(2)) == 104857) {
                                        if ((char)inputStream.Peek() <= '6') {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                        else {
                                            throw new UnknownTypeException();
                                        }
                                    }
                                    else {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                }
                                if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                    throw new UnknownTypeException();
                                }
                                scannedToken.Type = TokenType.CELL;
                                break;
                            }
                            else if (char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek())) {
                                scannedToken.Value += (char)inputStream.Read();
                                if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                    scannedToken.Value += (char)inputStream.Read();
                                    while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(3)) <= 104857) {
                                        if (Int32.Parse(scannedToken.Value.Substring(3)) == 104857) {
                                            if ((char)inputStream.Peek() <= '6') {
                                                scannedToken.Value += (char)inputStream.Read();
                                            }
                                            else {
                                                throw new UnknownTypeException();
                                            }
                                        }
                                        else {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                    }
                                    if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                        throw new UnknownTypeException();
                                    }
                                    scannedToken.Type = TokenType.CELL;
                                    break;
                                }
                            }
                        }
                        throw new UnknownTypeException();
                    case 'X':
                        scannedToken.Value += (char)inputStream.Read();
                        if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                            scannedToken.Value += (char)inputStream.Read();
                            while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(1)) <= 104857) {
                                if (Int32.Parse(scannedToken.Value.Substring(1)) == 104857) {
                                    if ((char)inputStream.Peek() <= '6') {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                    else {
                                        throw new UnknownTypeException();
                                    }
                                }
                                else {
                                    scannedToken.Value += (char)inputStream.Read();
                                }
                            }
                            if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                throw new UnknownTypeException();
                            }
                            scannedToken.Type = TokenType.CELL;
                            break;
                        } else if(char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek())) {
                            scannedToken.Value += (char)inputStream.Read();
                            if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                scannedToken.Value += (char)inputStream.Read();
                                while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(2)) <= 104857) {
                                    if (Int32.Parse(scannedToken.Value.Substring(2)) == 104857) {
                                        if ((char)inputStream.Peek() <= '6') {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                        else {
                                            throw new UnknownTypeException();
                                        }
                                    }
                                    else {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                }
                                if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                    throw new UnknownTypeException();
                                }
                                scannedToken.Type = TokenType.CELL;
                                break;
                            }
                            else if (char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek()) && (char)scannedToken.Value[1] <= 'F' && (char)inputStream.Peek() <= 'D') {
                                scannedToken.Value += (char)inputStream.Read();
                                if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                    scannedToken.Value += (char)inputStream.Read();
                                    while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(3)) <= 104857) {
                                        if (Int32.Parse(scannedToken.Value.Substring(3)) == 104857) {
                                            if ((char)inputStream.Peek() <= '6') {
                                                scannedToken.Value += (char)inputStream.Read();
                                            }
                                            else {
                                                throw new UnknownTypeException();
                                            }
                                        }
                                        else {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                    }
                                    if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                        throw new UnknownTypeException();
                                    }
                                    scannedToken.Type = TokenType.CELL;
                                    break;
                                }
                            }
                        }
                        throw new UnknownTypeException();
                    case 'Y':
                    case 'Z':
                        scannedToken.Value += (char)inputStream.Read();
                        if (char.IsUpper((char)inputStream.Peek()) && char.IsLetter((char)inputStream.Peek()))
                        {
                            scannedToken.Value += (char)inputStream.Read();
                            if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0')
                            {
                                scannedToken.Value += (char)inputStream.Read();
                            } else {
                                throw new Exception();
                            }
                            while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(2)) <= 104857)
                            {
                                if (Int32.Parse(scannedToken.Value.Substring(2)) == 104857)
                                {
                                    if ((char)inputStream.Peek() <= '6')
                                    {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                    else
                                    {
                                        throw new UnknownTypeException();
                                    }
                                }
                                else
                                {
                                    scannedToken.Value += (char)inputStream.Read();
                                }
                            }
                            if (!char.IsWhiteSpace((char)inputStream.Peek()))
                            {
                                throw new UnknownTypeException();
                            }
                            scannedToken.Type = TokenType.CELL;
                            break;
                        }
                        else if (char.IsDigit((char)inputStream.Peek()))
                        {
                            scannedToken.Value += (char)inputStream.Read();
                            while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(1)) <= 104857)
                            {
                                if (Int32.Parse(scannedToken.Value.Substring(1)) == 104857)
                                {
                                    if ((char)inputStream.Peek() <= '6')
                                    {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                    else
                                    {
                                        throw new UnknownTypeException();
                                    }
                                }
                                else
                                {
                                    scannedToken.Value += (char)inputStream.Read();
                                }
                            }
                            if (!char.IsWhiteSpace((char)inputStream.Peek()))
                            {
                                throw new UnknownTypeException();
                            }
                            scannedToken.Type = TokenType.CELL;
                            break;
                        }
                        throw new UnknownTypeException();

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
                        else if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                            scannedToken.Value += (char)inputStream.Read();
                            while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(1)) <= 104857) {
                                if (Int32.Parse(scannedToken.Value.Substring(1)) == 104857) {
                                    if ((char)inputStream.Peek() <= '6') {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                    else {
                                        throw new UnknownTypeException();
                                    }
                                }
                                else {
                                    scannedToken.Value += (char)inputStream.Read();
                                }
                            }
                            if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                throw new UnknownTypeException();
                            }
                            scannedToken.Type = TokenType.CELL;
                            break;
                        }
                        else if (char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek())) {
                            scannedToken.Value += (char)inputStream.Read();
                            if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                scannedToken.Value += (char)inputStream.Read();
                                while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(2)) <= 104857) {
                                    if (Int32.Parse(scannedToken.Value.Substring(2)) == 104857) {
                                        if ((char)inputStream.Peek() <= '6') {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                        else {
                                            throw new UnknownTypeException();
                                        }
                                    }
                                    else {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                }
                                if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                    throw new UnknownTypeException();
                                }
                                scannedToken.Type = TokenType.CELL;
                                break;
                            }
                            else if (char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek())) {
                                scannedToken.Value += (char)inputStream.Read();
                                if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                    scannedToken.Value += (char)inputStream.Read();
                                    while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(3)) <= 104857) {
                                        if (Int32.Parse(scannedToken.Value.Substring(3)) == 104857) {
                                            if ((char)inputStream.Peek() <= '6') {
                                                scannedToken.Value += (char)inputStream.Read();
                                            }
                                            else {
                                                throw new UnknownTypeException();
                                            }
                                        }
                                        else {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                    }
                                    if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                        throw new UnknownTypeException();
                                    }
                                    scannedToken.Type = TokenType.CELL;
                                    break;
                                }
                            }
                        }
                        throw new Exception();
                    case 'T':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == 'e') {
                            scannedToken.Value += (char)inputStream.Read();
                            if ((char)inputStream.Peek() == 'x') {
                                scannedToken.Value += (char)inputStream.Read();
                                if ((char)inputStream.Peek() == 't') {
                                    scannedToken.Value += (char)inputStream.Read();
                                    if (char.IsWhiteSpace((char)inputStream.Peek())) {
                                        scannedToken.Type = TokenType.TEXTDCL;
                                        break;
                                    }
                                }
                            }
                        }
                        else if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                            scannedToken.Value += (char)inputStream.Read();
                            while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(1)) <= 104857) {
                                if (Int32.Parse(scannedToken.Value.Substring(1)) == 104857) {
                                    if ((char)inputStream.Peek() <= '6') {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                    else {
                                        throw new UnknownTypeException();
                                    }
                                }
                                else {
                                    scannedToken.Value += (char)inputStream.Read();
                                }
                            }
                            if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                throw new UnknownTypeException();
                            }
                            scannedToken.Type = TokenType.CELL;
                            break;
                        }
                        else if (char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek())) {
                            scannedToken.Value += (char)inputStream.Read();
                            if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                scannedToken.Value += (char)inputStream.Read();
                                while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(2)) <= 104857) {
                                    if (Int32.Parse(scannedToken.Value.Substring(2)) == 104857) {
                                        if ((char)inputStream.Peek() <= '6') {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                        else {
                                            throw new UnknownTypeException();
                                        }
                                    }
                                    else {
                                        scannedToken.Value += (char)inputStream.Read();
                                    }
                                }
                                if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                    throw new UnknownTypeException();
                                }
                                scannedToken.Type = TokenType.CELL;
                                break;
                            }
                            else if (char.IsLetter((char)inputStream.Peek()) && char.IsUpper((char)inputStream.Peek())) {
                                scannedToken.Value += (char)inputStream.Read();
                                if (char.IsDigit((char)inputStream.Peek()) && (char)inputStream.Peek() > '0') {
                                    scannedToken.Value += (char)inputStream.Read();
                                    while (char.IsDigit((char)inputStream.Peek()) && Int32.Parse(scannedToken.Value.Substring(3)) <= 104857) {
                                        if (Int32.Parse(scannedToken.Value.Substring(3)) == 104857) {
                                            if ((char)inputStream.Peek() <= '6') {
                                                scannedToken.Value += (char)inputStream.Read();
                                            }
                                            else {
                                                throw new UnknownTypeException();
                                            }
                                        }
                                        else {
                                            scannedToken.Value += (char)inputStream.Read();
                                        }
                                    }
                                    if (!char.IsWhiteSpace((char)inputStream.Peek())) {
                                        throw new UnknownTypeException();
                                    }
                                    scannedToken.Type = TokenType.CELL;
                                    break;
                                }
                            }
                        }
                        throw new UnknownTypeException();
                    case '(':
                        scannedToken.Value += (char)inputStream.Read();
                        scannedToken.Type = TokenType.LPAREN;
                        break;
                    case ')':
                        scannedToken.Value += (char)inputStream.Read();
                        scannedToken.Type = TokenType.RPAREN;
                        break;
                    case '!':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() == '=')
                        {
                            scannedToken.Value += (char)inputStream.Read();
                            scannedToken.Type = TokenType.NOTEQUAL;
                        }
                        else
                        {
                            throw new UnknownTypeException();
                        }
                        break;
                    case '=':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() != '=')
                        {
                            scannedToken.Type = TokenType.ASSIGN;
                        }
                        else
                        {
                            scannedToken.Value += (char)inputStream.Read();
                            scannedToken.Type = TokenType.COMPAREEQUAL;
                        }
                        break;
                    case '<':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() != '=')
                        {
                            scannedToken.Type = TokenType.LESSTHAN;
                        }
                        else
                        {
                            scannedToken.Value += (char)inputStream.Read();
                            scannedToken.Type = TokenType.LESSEQUAL;
                        }
                        break;
                    case '>':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() != '=')
                        {
                            scannedToken.Type = TokenType.GREATERTHAN;
                        }
                        else
                        {
                            scannedToken.Value += (char)inputStream.Read();
                            scannedToken.Type = TokenType.GREATEREQUAL;
                        }
                        break;
                    case '*':
                        scannedToken.Value += (char)inputStream.Read();
                        scannedToken.Type = TokenType.MULTIPLICATION;
                        break;
                    case '/':
                        scannedToken.Value += (char)inputStream.Read();
                        if ((char)inputStream.Peek() != '*')
                        {
                            scannedToken.Type = TokenType.DIVISION;
                        }
                        else
                        {
                            scannedToken.Value += (char)inputStream.Read();
                            bool commentEnd = false;
                            while (commentEnd != true)
                            {
                                scannedToken.Value += (char)inputStream.Read();
                                if (scannedToken.Value[scannedToken.Value.Length - 1] == '*' && (char)inputStream.Peek() == '/')
                                {
                                    scannedToken.Value += (char)inputStream.Read();
                                    commentEnd = true;
                                }
                            }
                            scannedToken.Type = TokenType.COMMENT;
                        }
                        break;
                    case '+':
                        scannedToken.Value += (char)inputStream.Read();
                        scannedToken.Type = TokenType.PLUS;
                        break;
                    case '-':
                        scannedToken.Value += (char)inputStream.Read();
                        scannedToken.Type = TokenType.MINUS;
                        break;
                    case '\n':
                    case '\r':
                    case '\t':
                    case ' ':
                        scannedToken.Value += (char)inputStream.Read();
                        scannedToken.Type = TokenType.WHITESPACE;
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

            while (scanner.inputStream.Peek() == ' ' || scanner.inputStream.Peek() == '\n' || scanner.inputStream.Peek() == '\r' || scanner.inputStream.Peek() == '\t')
            {
                scanner.inputStream.Read();
            }

            do
            {
                testToken = scanner.Scan();
                Console.WriteLine("TokenType: " + testToken.Type + "\n" + "TokenValue: " + testToken.Value);
            } while (testToken.Type != TokenType.EOF);
        }
    }
}
