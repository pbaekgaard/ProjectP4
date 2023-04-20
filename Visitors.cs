﻿using Antlr4.Runtime.Misc;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ProjectP4
{
    public class Visitors : GrammarBaseVisitor<object?>
    {
        public SymTable symbolTable = new();
        public override object VisitAssignnew([NotNull] GrammarParser.AssignnewContext context)
        {
            var name = context.VAR().GetText();

            var type = context.types().GetText();

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
            dynamic value = Visit(context.expression());

            dynamic varname = context.VAR().GetText();

            Symbol var = symbolTable.getSymbol(varname);

            var.value = value;

            symbolTable.updateSymbol(varname, var);
            

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
            

            return Op(operatorValue, leftValue, rightValue);

        }

        public override object VisitVarexpression([NotNull] GrammarParser.VarexpressionContext context)
        {
            string var = context.VAR().GetText();

            return var;

        }
        public override object VisitIfthen([NotNull] GrammarParser.IfthenContext context)
        {
            dynamic? compare = Visit(context.expression());
            if (compare)
            {
                symbolTable.scope++;
                symbolTable.openScope();
                Visit(context.declaration());
                symbolTable.closeScope();
                symbolTable.scope--;
            }
            return null;
        }

        public override object VisitWhilestmt([NotNull] GrammarParser.WhilestmtContext context)
        {
            dynamic? compare = Visit(context.expression());
            while (compare)
            {
                symbolTable.scope++;
                symbolTable.openScope();
                Visit(context.declaration());
                symbolTable.closeScope();
                symbolTable.scope--;
                compare = Visit(context.expression());
            }
            return null;
        }

        public override object VisitIfelse([NotNull] GrammarParser.IfelseContext context)
        {
            dynamic compare = Visit(context.expression());

            if (compare)
            {
                symbolTable.scope++;
                symbolTable.openScope();
                Visit(context.declaration(0));
                symbolTable.closeScope();
                symbolTable.scope--;

            } else
            {
                symbolTable.scope++;
                symbolTable.openScope();
                Visit(context.declaration(1));
                symbolTable.closeScope();
                symbolTable.scope--;
            }
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


        private dynamic Op(string opr,dynamic lv,dynamic rv)
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
                default:
                    throw new Exception("Does not fungo");
                    break;
            }
        }
    }
    

}
