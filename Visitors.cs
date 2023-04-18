using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Text;
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
                input = input.Trim(new char[] { '"' });
                return input;
            }
            return null;
        }
        public override object VisitOperatorexpression([NotNull] GrammarParser.OperatorexpressionContext context)
        {
            var operatorValue = context.@operator().GetText();

            dynamic leftValue = Visit(context.expression(0));
            dynamic rightValue = Visit(context.expression(1));

            return Op(operatorValue, leftValue, rightValue);

        }

        public override object VisitVarexpression([NotNull] GrammarParser.VarexpressionContext context)
        {
            Symbol var = symbolTable.getSymbol(context.VAR().GetText());

            return var.value;

        }
        public override object VisitIfthen([NotNull] GrammarParser.IfthenContext context)
        {
            dynamic? compare = Visit(context.expression());
            if (compare)
            {
                symbolTable.scope++;
                symbolTable.openScope();
                Visit(context.declaration());
                symbolTable.scope--;
            }
            return null;
        }
        public override object VisitIfelse([NotNull] GrammarParser.IfelseContext context)
        {
            dynamic compare = Visit(context.expression());

            if (compare)
            {
                var dec1 = Visit(context.declaration(0));
                var dec2 = Visit(context.declaration(1));
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
