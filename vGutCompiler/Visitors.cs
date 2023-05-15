using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Globalization;
using System.Text.RegularExpressions;
using vGutCompiler;

namespace ProjectP4
{
    public class Visitors : GrammarBaseVisitor<object?>
    {
        public SymTable symbolTable = new();
        public CodeGenerator codeG = new();
        public string fileName { get; set; }

        public Visitors(string FileName)
        {
            fileName = FileName;
        }

        public override object VisitProgram([NotNull] GrammarParser.ProgramContext context)
        {
            string sourceName = this.fileName;
            codeG.startSub(sourceName);
            VisitChildren(context);
            codeG.endSub();
            return null;
        }

        public override object VisitAssignnew([NotNull] GrammarParser.AssignnewContext context)
        {
            var name = context.VAR().GetText();

            var type = context.types().GetText();

            codeG.AssignVariable(name);

            dynamic value = Visit(context.conditionalexpression());

            codeG.NewLine();

            switch (type)
            {
                case "number":
                    if (value is int)
                    {
                        break;
                    }
                    else if (value is float)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception(String.Format("{0} is not a number", name));
                    }
                case "text":
                    if (value is string)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception(String.Format("{0} is not a text (remember \" around the text", name));
                    }
                case "bool":
                    if (value is bool)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception(String.Format("{0} is not a boolean", name));
                    }
                default:
                    break;
            }

            if (value is string s)
            {
                if (s.Contains('"'))
                {
                    value = s.Trim(new char[] { '"' });
                }
                else
                {
                    value = symbolTable.getSymbol(s).value;
                }
            }

            Symbol symbol = new();

            bool result = Enum.TryParse(type, out Symbol.symbolType sym);

            if (result)
            {
                symbol.type = sym;
                symbol.value = value;
                symbolTable.addSymbol(name, symbol);
            }
            else
            {
                throw new Exception("type is not valid");
            }

            return null;
        }
        public override object VisitAssigndec([NotNull] GrammarParser.AssigndecContext context)
        {

            dynamic varname = context.VAR().GetText();

            codeG.UpdateVariable(varname);

            dynamic value = Visit(context.conditionalexpression());

            codeG.NewLine();

            if (value is string s)
            {
                if (s.Contains('"'))
                {
                    value = s.Trim(new char[] { '"' });
                }
                else
                {
                    value = symbolTable.getSymbol(s).value;
                }
            }

            Symbol var = symbolTable.getSymbol(varname);

            var.value = value;

            symbolTable.updateSymbol(varname, var);

            return null;
        }
        public override object? VisitConstant([NotNull] GrammarParser.ConstantContext context)
        {

            if (context.INTEGER() != null)
            {
                codeG.Value(int.Parse(context.INTEGER().GetText()));
                return int.Parse(context.INTEGER().GetText());
            }
            if (context.FLOAT() != null)
            {
                codeG.Value(float.Parse(context.FLOAT().GetText(), CultureInfo.InvariantCulture));
                return float.Parse(context.FLOAT().GetText(), CultureInfo.InvariantCulture);
            }
            if (context.BOOL() != null)
            {
                codeG.Value(bool.Parse(context.BOOL().GetText()));
                return bool.Parse(context.BOOL().GetText());
            }
            if (context.STRING() != null)
            {
                codeG.Value(context.STRING().GetText());
                var input = context.STRING().GetText();
                return input;
            }
            return null;
        }

        public override object VisitArithExpr([NotNull] GrammarParser.ArithExprContext context)
        {

            dynamic leftValue = Visit(context.conditionalexpression(0));

            if (leftValue is string s)
            {
                if (s.Contains('"'))
                {
                    leftValue = s.Trim(new char[] { '"' });
                }
                else
                {
                    leftValue = symbolTable.getSymbol(s).value;
                }
            }

            codeG.Value(context.op.Text);

            dynamic rightValue = Visit(context.conditionalexpression(1));

            if (rightValue is string s1)
            {
                if (s1.Contains('"'))
                {
                    rightValue = s1.Trim(new char[] { '"' });
                }
                else
                {
                    rightValue = symbolTable.getSymbol(s1).value;
                }
            }

            switch (context.op.Type)
            {
                case GrammarParser.MULTIPLICATION:
                    return leftValue * rightValue;
                case GrammarParser.MINUS:
                    return leftValue - rightValue;
                case GrammarParser.PLUS:
                    return leftValue + rightValue;
                case GrammarParser.DIVISION:
                    return leftValue / rightValue;
                case GrammarParser.MODULO:
                    return leftValue % rightValue;
                default:
                    throw new Exception("Operator not found");
            }

        }
        public override object VisitRelatExpr([NotNull] GrammarParser.RelatExprContext context)
        {
            dynamic leftValue = Visit(context.conditionalexpression(0));

            if (leftValue is string s)
            {
                if (s.Contains('"'))
                {
                    leftValue = s.Trim(new char[] { '"' });
                }
                else
                {
                    leftValue = symbolTable.getSymbol(s).value;
                }
            }

            codeG.Value(context.op.Text);

            dynamic rightValue = Visit(context.conditionalexpression(1));

            if (rightValue is string s1)
            {
                if (s1.Contains('"'))
                {
                    rightValue = s1.Trim(new char[] { '"' });
                }
                else
                {
                    rightValue = symbolTable.getSymbol(s1).value;
                }
            }

            switch (context.op.Type)
            {
                case GrammarParser.LESSTHAN:
                    return leftValue < rightValue;
                case GrammarParser.GREATERTHAN:
                    return leftValue > rightValue;
                case GrammarParser.GREATEREQUAL:
                    return leftValue >= rightValue;
                case GrammarParser.LESSEQUAL:
                    return leftValue <= rightValue;
                default:
                    throw new Exception("Operator not found");
            }

        }

        public override object VisitEquaExpr([NotNull] GrammarParser.EquaExprContext context)
        {
            dynamic leftValue = Visit(context.conditionalexpression(0));

            if (leftValue is string s)
            {
                if (s.Contains('"'))
                {
                    leftValue = s.Trim(new char[] { '"' });
                }
                else
                {
                    leftValue = symbolTable.getSymbol(s).value;
                }
            }

            codeG.Value(context.op.Text);

            dynamic rightValue = Visit(context.conditionalexpression(1));

            if (rightValue is string s1)
            {
                if (s1.Contains('"'))
                {
                    rightValue = s1.Trim(new char[] { '"' });
                }
                else
                {
                    rightValue = symbolTable.getSymbol(s1).value;
                }
            }

            switch (context.op.Type)
            {
                case GrammarParser.COMPEQUAL:
                    return leftValue == rightValue;
                case GrammarParser.NOTEQUAL:
                    return leftValue != rightValue;
                default:
                    throw new Exception("Operator not found");
            }
        }

        public override object VisitAndExpr([NotNull] GrammarParser.AndExprContext context)
        {
            dynamic leftValue = Visit(context.conditionalexpression(0));

            if (leftValue is string s)
            {
                if (s.Contains('"'))
                {
                    leftValue = s.Trim(new char[] { '"' });
                }
                else
                {
                    leftValue = symbolTable.getSymbol(s).value;
                }
            }

            var op = context.op.Text.ToLower();
            codeG.Value(string.Concat(op[0].ToString().ToUpper(), op.AsSpan(1)));

            dynamic rightValue = Visit(context.conditionalexpression(1));

            if (rightValue is string s1)
            {
                if (s1.Contains('"'))
                {
                    rightValue = s1.Trim(new char[] { '"' });
                }
                else
                {
                    rightValue = symbolTable.getSymbol(s1).value;
                }
            }

            return leftValue && rightValue;
        }

        public override object VisitOrExpr([NotNull] GrammarParser.OrExprContext context)
        {
            dynamic leftValue = Visit(context.conditionalexpression(0));

            if (leftValue is string s)
            {
                if (s.Contains('"'))
                {
                    leftValue = s.Trim(new char[] { '"' });
                }
                else
                {
                    leftValue = symbolTable.getSymbol(s).value;
                }
            }

            codeG.Value(context.op.Text);

            dynamic rightValue = Visit(context.conditionalexpression(1));

            if (rightValue is string s1)
            {
                if (s1.Contains('"'))
                {
                    rightValue = s1.Trim(new char[] { '"' });
                }
                else
                {
                    rightValue = symbolTable.getSymbol(s1).value;
                }
            }

            return leftValue || rightValue;
        }

        public override object VisitVarexpression([NotNull] GrammarParser.VarexpressionContext context)
        {
            string var = context.VAR().GetText();

            codeG.Variable(var);

            return var;

        }
        public override object VisitIfthen([NotNull] GrammarParser.IfthenContext context)
        {
            codeG.IfStart();

            Visit(context.conditionalexpression());

            codeG.IfThen();

            symbolTable.scope++;
            symbolTable.openScope();
            Visit(context.block());
            symbolTable.closeScope();
            symbolTable.scope--;

            codeG.endIf();

            return null;
        }

        public override object VisitIfelse([NotNull] GrammarParser.IfelseContext context)
        {
            codeG.IfStart();

            Visit(context.conditionalexpression());

            codeG.IfThen();

            symbolTable.scope++;
            symbolTable.openScope();
            Visit(context.block(0));
            symbolTable.closeScope();
            symbolTable.scope--;

            codeG.elseStatement();

            symbolTable.scope++;
            symbolTable.openScope();
            Visit(context.block(1));
            symbolTable.closeScope();
            symbolTable.scope--;

            codeG.endIf();

            return null;
        }

        public override object VisitWhilestmt([NotNull] GrammarParser.WhilestmtContext context)
        {
            codeG.WhilestmtStart();

            Visit(context.conditionalexpression());

            codeG.NewLine();

            symbolTable.scope++;
            symbolTable.openScope();
            foreach (var item in context.declaration())
            {
                Visit(item);
            }
            symbolTable.closeScope();
            symbolTable.scope--;

            codeG.WhilestmtEnd();

            return null;

        }

        public override object VisitSum([NotNull] GrammarParser.SumContext context)
        {

            var startVar = context.VAR(0).GetText();
            var endVar = context.VAR(1).GetText();

            var startVarNumber = Regex.Replace(startVar, "[^0-9]", "");
            int startVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(startVar, "[^A-Z]", ""), 0);

            var endVarNumber = Regex.Replace(endVar, "[^0-9]", "");
            int endVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(endVar, "[^A-Z]", ""), 0);


            dynamic result = 0;
            for (int j = startVarLetterUnicode; j <= endVarLetterUnicode; j++)
            {
                for (int i = int.Parse(startVarNumber); i <= int.Parse(endVarNumber); i++)
                {
                    dynamic val = symbolTable.getSymbol(char.ConvertFromUtf32(j) + i);
                    if (val.value is int k)
                    {
                        result = result + k;
                    }
                    else if (val.value is float kf)
                    {
                        result = result + kf;
                    }
                }
            }

            codeG.sum(startVar, endVar);

            return result;
        }

        public override object VisitAverage([NotNull] GrammarParser.AverageContext context)
        {
            var startVar = context.VAR(0).GetText();
            var endVar = context.VAR(1).GetText();

            var startVarNumber = Regex.Replace(startVar, "[^0-9]", "");
            int startVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(startVar, "[^A-Z]", ""), 0);

            var endVarNumber = Regex.Replace(endVar, "[^0-9]", "");
            int endVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(endVar, "[^A-Z]", ""), 0);


            dynamic result = 0;
            int index = 0;
            for (int j = startVarLetterUnicode; j <= endVarLetterUnicode; j++)
            {
                for (int i = int.Parse(startVarNumber); i <= int.Parse(endVarNumber); i++)
                {
                    dynamic val = symbolTable.getSymbol(char.ConvertFromUtf32(j) + i);

                    if ((object)val == null)
                    {
                        continue;
                    }
                    if (val.value is int k)
                    {
                        index++;
                        result = result + k;
                    }
                    else if (val.value is float kf)
                    {
                        index++;
                        result = result + kf;
                    }
                }
            }
            result = result / index;

            codeG.average(startVar, endVar);

            return result;
        }

        public override object VisitMin([NotNull] GrammarParser.MinContext context)
        {
            var startVar = context.VAR(0).GetText();
            var endVar = context.VAR(1).GetText();

            var startVarNumber = Regex.Replace(startVar, "[^0-9]", "");
            int startVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(startVar, "[^A-Z]", ""), 0);

            var endVarNumber = Regex.Replace(endVar, "[^0-9]", "");
            int endVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(endVar, "[^A-Z]", ""), 0);


            dynamic result = 0;
            for (int j = startVarLetterUnicode; j <= endVarLetterUnicode; j++)
            {
                for (int i = int.Parse(startVarNumber); i <= int.Parse(endVarNumber); i++)
                {
                    dynamic val = symbolTable.getSymbol(char.ConvertFromUtf32(j) + i);

                    if ((object)val == null)
                    {
                        continue;
                    }
                    if (result == 0)
                    {
                        result = val.value;
                    }
                    if (val.value < result)
                    {
                        result = val.value;
                    }
                }
            }

            codeG.MinFunction(startVar, endVar);

            return result;
        }

        public override object VisitMax([NotNull] GrammarParser.MaxContext context)
        {
            var startVar = context.VAR(0).GetText();
            var endVar = context.VAR(1).GetText();

            var startVarNumber = Regex.Replace(startVar, "[^0-9]", "");
            int startVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(startVar, "[^A-Z]", ""), 0);

            var endVarNumber = Regex.Replace(endVar, "[^0-9]", "");
            int endVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(endVar, "[^A-Z]", ""), 0);


            dynamic result = 0;
            for (int j = startVarLetterUnicode; j <= endVarLetterUnicode; j++)
            {
                for (int i = int.Parse(startVarNumber); i <= int.Parse(endVarNumber); i++)
                {
                    dynamic val = symbolTable.getSymbol(char.ConvertFromUtf32(j) + i);

                    if ((object)val == null)
                    {
                        continue;
                    }
                    if (result == 0)
                    {
                        result = val.value;
                    }
                    if (val.value > result)
                    {
                        result = val.value;
                    }
                }
            }

            codeG.MaxFunction(startVar, endVar);

            return result;
        }

        public override object VisitCount([NotNull] GrammarParser.CountContext context)
        {
            var startVar = context.VAR(0).GetText();
            var endVar = context.VAR(1).GetText();

            var startVarNumber = Regex.Replace(startVar, "[^0-9]", "");
            int startVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(startVar, "[^A-Z]", ""), 0);

            var endVarNumber = Regex.Replace(endVar, "[^0-9]", "");
            int endVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(endVar, "[^A-Z]", ""), 0);


            dynamic index = 0;
            for (int j = startVarLetterUnicode; j <= endVarLetterUnicode; j++)
            {
                for (int i = int.Parse(startVarNumber); i <= int.Parse(endVarNumber); i++)
                {
                    dynamic val = symbolTable.getSymbol(char.ConvertFromUtf32(j) + i);

                    if ((object)val == null)
                    {
                        continue;
                    }
                    if (val.value is int k)
                    {
                        index++;
                    }
                    else if (val.value is float kf)
                    {
                        index++;
                    }
                }
            }
            codeG.Count(startVar, endVar);
            return index;
        }

        public override object VisitCountif([NotNull] GrammarParser.CountifContext context)
        {
            var startVar = context.VAR(0).GetText();
            var endVar = context.VAR(1).GetText();
            int specific = int.Parse(context.specific.Text);

            var startVarNumber = Regex.Replace(startVar, "[^0-9]", "");
            int startVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(startVar, "[^A-Z]", ""), 0);

            var endVarNumber = Regex.Replace(endVar, "[^0-9]", "");
            int endVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(endVar, "[^A-Z]", ""), 0);


            dynamic index = 0;
            for (int j = startVarLetterUnicode; j <= endVarLetterUnicode; j++)
            {
                for (int i = int.Parse(startVarNumber); i <= int.Parse(endVarNumber); i++)
                {
                    dynamic val = symbolTable.getSymbol(char.ConvertFromUtf32(j) + i);

                    if ((object)val == null)
                    {
                        continue;
                    }
                    if (val.value is int k)
                    {
                        index++;
                    }
                    else if (val.value is float kf)
                    {
                        index++;
                    }
                }
            }
            codeG.Count(startVar, endVar, specific);
            return index;
        }


        public override object VisitSort([NotNull] GrammarParser.SortContext context)
        {
            var startVar = context.VAR(0).GetText();
            var endVar = context.VAR(1).GetText();
            var destVar = context.VAR(2).GetText();
            var order = context.BOOL().GetText();

            var result = symbolTable.getSymbol(context.VAR(2).GetText());

            var startVarNumber = Regex.Replace(startVar, "[^0-9]", "");
            int startVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(startVar, "[^A-Z]", ""), 0);

            var endVarNumber = Regex.Replace(endVar, "[^0-9]", "");
            int endVarLetterUnicode = char.ConvertToUtf32(Regex.Replace(endVar, "[^A-Z]", ""), 0);

            List<dynamic> sortArray = new List<dynamic>();
            for (int j = startVarLetterUnicode; j <= endVarLetterUnicode; j++)
            {
                for (int i = int.Parse(startVarNumber); i <= int.Parse(endVarNumber); i++)
                {
                    Symbol? val = symbolTable.getSymbol(char.ConvertFromUtf32(j) + i);

                    if (val == null)
                    {
                        continue;
                    }
                    else
                    {
                        sortArray.Add(val.value);
                    }
                }
            }
            sortArray.Sort();
            if (result == null)
            {
                result = new Symbol();
                result.value = sortArray.ToArray();
                symbolTable.addSymbol(context.VAR(2).GetText(), result);
            }
            else
            {
                result.value = sortArray.ToArray();
                symbolTable.updateSymbol(context.VAR(2).GetText(), result);
            }
            codeG.SortFunction(startVar, endVar, destVar, order);
            return true;

        }

        public override object VisitVlookup(GrammarParser.VlookupContext context)
        {
            var start = context.VAR(0).GetText();
            var end = context.VAR(1).GetText();
            var index = context.INTEGER().GetText();

            var startNumber = Regex.Replace(start, "[^0-9]", "");
            var startLetter = Regex.Replace(start, "[^A-Z]", "");

            var endNumber = Regex.Replace(end, "[^0-9]", "");
            var endLetter = Regex.Replace(end, "[^A-Z]", "");
            var searchTerm = context.constant().GetText();
            if (searchTerm is string)
            {
                searchTerm = searchTerm.Replace("\"", "");
            }
            int columnSpan = ((int)Convert.ToChar(char.Parse(endLetter)) - (int)Convert.ToChar(char.Parse(startLetter))) + 1;

            if (columnSpan == 1)
            {
                throw new Exception("You need to select multiple columns");
            }
            else if (columnSpan < int.Parse(index))
            {
                throw new Exception("Value column out of range");
            }

            var valColumn = (int)Convert.ToChar(char.Parse(startLetter)) + int.Parse(index) - 1;

            IDictionary<dynamic, dynamic> lookup = new Dictionary<dynamic, dynamic>();

            for (int i = int.Parse(startNumber); i <= int.Parse(endNumber); i++)
            {
                try{
                dynamic? key = symbolTable.getSymbol(startLetter + i).value;
                Symbol? val = symbolTable.getSymbol(char.ConvertFromUtf32(valColumn) + i);
                lookup.Add(key, val);
                }
                catch(Exception e){
                    continue;
                }
            }
            codeG.VLookUpFunction(searchTerm, start, end, int.Parse(index), bool.Parse(context.BOOL().GetText()));
            return string.Format("\"{0}\"", lookup[searchTerm].value);
        }
    }


}
