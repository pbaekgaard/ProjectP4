using Antlr4.Runtime.Misc;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ProjectP4
{
    public class Visitors : GrammarBaseVisitor<object?>
    {
        public SymTable symbolTable = new();

        public CodeGenerator codeG = new();

        public override object VisitAssignnew([NotNull] GrammarParser.AssignnewContext context)
        {
            var name = context.VAR().GetText();

            var type = context.types().GetText();

            dynamic value = Visit(context.expression());

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
                    if (EvaluateOperation(value.Item1, value.Item2, value.Item3) is bool val)
                    {
                        value = val;
                        break;
                    }
                    else
                    {
                        throw new Exception(String.Format("{0} is not a boolean", value));
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

            codeG.DeclareVariable(name, value);

            return null;
        }
        public override object VisitAssigndec([NotNull] GrammarParser.AssigndecContext context)
        {

            dynamic varname = context.VAR().GetText();

            dynamic value = Visit(context.expression());

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

            if (context.Parent.Parent.GetType().FullName == "GrammarParser+WhilestmtContext")
            {
                return null;
            }

            codeG.AssignVariable(varname, value);
            return null;
        }
        public override object? VisitConstant([NotNull] GrammarParser.ConstantContext context)
        {
            if (context.INTEGER() != null)
            {
                return int.Parse(context.INTEGER().GetText());
            }
            if (context.FLOAT() != null)
            {
                return float.Parse(context.FLOAT().GetText(), CultureInfo.InvariantCulture);
            }
            if (context.BOOL() != null)
            {
                return bool.Parse(context.BOOL().GetText());
            }
            if (context.STRING() != null)
            {
                var input = context.STRING().GetText();
                //input = input.Trim(new char[] { '"' });
                return input;
            }
            return null;
        }
        public override object VisitOperatorexpression([NotNull] GrammarParser.OperatorexpressionContext context)
        {
            var operatorValue = context.@operator().GetText();

            dynamic leftValue = Visit(context.expression(0));
            dynamic rightValue = Visit(context.expression(1));

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
            if (rightValue is string s2)
            {
                if (s2.Contains('"'))
                {
                    rightValue = s2.Trim(new char[] { '"' });
                }
                else
                {
                    rightValue = symbolTable.getSymbol(s2).value;
                }
            }


            return EvaluateOperation(leftValue,operatorValue, rightValue);

        }

        public override object VisitBooleanexpression([NotNull] GrammarParser.BooleanexpressionContext context)
        {
            dynamic operatorValue = context.op.Text;
            dynamic leftValue = Visit(context.expression(0));
            dynamic rightValue = Visit(context.expression(1));
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
            if (rightValue is string s2)
            {
                if (s2.Contains('"'))
                {
                    rightValue = s2.Trim(new char[] { '"' });
                }
                else
                {
                    rightValue = symbolTable.getSymbol(s2).value;
                }
            }
            if (leftValue is int)
            {
                leftValue = (float)leftValue;
            }
            if (rightValue is int)
            {
                rightValue = (float)Convert.ToDouble(rightValue);
            }

            if (leftValue is string && rightValue.GetType() == leftValue.GetType() && (operatorValue is "==" or "!="))
                return (leftValue, operatorValue, rightValue);
            else if (leftValue is bool && rightValue.GetType() == leftValue.GetType() && (operatorValue is "AND" or "OR" or "==" or "!="))
                return (leftValue, operatorValue, rightValue);
            else if ((leftValue is int || leftValue is float) && (rightValue is int || rightValue is float) && (operatorValue is "<" or ">" or "<=" or ">=" or "==" or "!="))
                return (leftValue, operatorValue, rightValue);
            else
                throw new Exception("Invalid Comparison");
        }

        public override object VisitCondexpression([NotNull] GrammarParser.CondexpressionContext context)
        {
            dynamic operatorValue = context.op.Text;
            dynamic leftValue = Visit(context.expression(0));
            dynamic rightValue = Visit(context.expression(1));
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
            if (rightValue is string s2)
            {
                if (s2.Contains('"'))
                {
                    rightValue = s2.Trim(new char[] { '"' });
                }
                else
                {
                    rightValue = symbolTable.getSymbol(s2).value;
                }
            }
            if (leftValue is int)
            {
                leftValue = (float)Convert.ToDouble(leftValue);
            }
            if (rightValue is int)
            {
                rightValue = (float)Convert.ToDouble(rightValue);
            }
            if (leftValue is string && rightValue.GetType() == leftValue.GetType() && (operatorValue is "==" or "!="))
                return EvaluateOperation(leftValue, operatorValue, rightValue);
            else if (leftValue is bool && rightValue.GetType() == leftValue.GetType() && (operatorValue is "AND" or "OR" or "==" or "!="))
                return EvaluateOperation(leftValue, operatorValue, rightValue);
            else if ((leftValue is int || leftValue is float) && (rightValue is int || rightValue is float) && (operatorValue is "<" or ">" or "<=" or ">=" or "==" or "!="))
                return EvaluateOperation(leftValue, operatorValue, rightValue);
            else
                throw new Exception("Invalid Comparison");
        }


        public override object VisitVarexpression([NotNull] GrammarParser.VarexpressionContext context)
        {
            string var = context.VAR().GetText();
            return var;

        }
        public override object VisitIfthen([NotNull] GrammarParser.IfthenContext context)
        {
            codeG.startIf(context.conditionalexpression());
            symbolTable.scope++;
            symbolTable.openScope();
            Visit(context.block());
            symbolTable.closeScope();
            symbolTable.scope--;
            codeG.endIf();

            return null;
        }

        public override object VisitWhilestmt([NotNull] GrammarParser.WhilestmtContext context)
        {
            dynamic compare = Visit(context.conditionalexpression());


            while (EvaluateOperation(compare.Item1, compare.Item2, compare.Item3))
            {
                symbolTable.scope++;
                symbolTable.openScope();
                foreach (var declaration in context.declaration())
                {
                    Visit(declaration);
                }
                symbolTable.closeScope();
                symbolTable.scope--;
                compare = Visit(context.conditionalexpression());
            }

            var test = context.Start.InputStream.GetText(Interval.Of(context.conditionalexpression().Start.StartIndex, context.conditionalexpression().Stop.StopIndex));

            codeG.While(test, context);

            return null;
        }

        public override object VisitIfelse([NotNull] GrammarParser.IfelseContext context)
        {
            dynamic compare = Visit(context.conditionalexpression());

            codeG.startIf(compare);
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

        public override object VisitSum([NotNull] GrammarParser.SumContext context)
        {
            //var test = context.Start.InputStream.GetText(Interval.Of(context.Parent().Start.StartIndex, decl.Stop.StopIndex)));

            var test = context.Parent.Parent.GetText();

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
            return index;
        }

        public override object VisitSort([NotNull] GrammarParser.SortContext context)
        {
            var startVar = context.VAR(0).GetText();
            var endVar = context.VAR(1).GetText();

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
                return true;
            }
            else
            {
                result.value = sortArray.ToArray();
                symbolTable.addSymbol(context.VAR(2).GetText(), result);
                return true;
            }

        }


        private dynamic EvaluateOperation(dynamic lv, string opr, dynamic rv)
        {
            switch (opr)
            {
                case "+": return lv + rv;
                case "-": return lv - rv;
                case "*": return lv * rv;
                case "/": return lv / rv;
                case "<": return lv < rv;
                case ">": return lv > rv;
                case "<=": return lv <= rv;
                case "AND": return lv && rv;
                case "OR": return lv || rv;
                case ">=": return lv <= rv;
                case "%": return lv % rv;
                case "==": return lv == rv;
                case "!=": return lv != rv;
                default:
                    throw new Exception("Does not fungo");
                    break;
            }
        }
    }


}
