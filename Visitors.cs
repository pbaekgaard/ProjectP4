using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ProjectP4.Symbol;
using static ProjectP4.SymTable;

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
            var startVarLetter = Regex.Replace(startVar, "[^A-Z]", "");
            int startVarLetterUnicode = char.ConvertToUtf32(startVarLetter, 0);

            var endVarNumber = Regex.Replace(endVar, "[^0-9]", "");
            var endVarLetter = Regex.Replace(endVar, "[^A-Z]", "");
            int endVarLetterUnicode = char.ConvertToUtf32(endVarLetter, 0);

            for (int i = int.Parse(startVarNumber); i <= int.Parse(endVarNumber); i++)
            {

            }

            return null;
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
