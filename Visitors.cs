using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectP4.SymTable;

namespace ProjectP4
{
    public class Visitors : GrammarBaseVisitor<object?>
    {
        public SymTable symbolTable = new();
        public override object? VisitAssignment([NotNull] GrammarParser.AssignmentContext context)
        {
            var name = context.VAR().GetText();

            var type = context.types().GetText();

            var value = Visit(context.expression());

            Symbol symbol = new();

            bool result = Enum.TryParse(type, out Symbol.symbolType sym);

            if (result)
            {
                symbol.type = sym;
                symbol.value = value;
                symbolTable.addSymbol(name, symbol);
            } else
            {
                throw new Exception("type is not valid");
            }

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
                return context.STRING().GetText();
            }
            return null;
        }
        public override object VisitOperatorexpression([NotNull] GrammarParser.OperatorexpressionContext context)
        {
            var operatorValue = context.@operator().GetText();

            var leftValue = Visit(context.expression(0));
            var rightValue = Visit(context.expression(1));

            switch (operatorValue)
            {
                case "+": return Plus(leftValue,rightValue);
                case "-": return Minus(leftValue,rightValue);

                default:
                    break;
            }

            return null;
        }


        private object Plus(object? left, object? right)
        {
            if (left is int l && right is int r)
            {
                return l + r;
            }
            else if (left is float fl && right is float fr)
            {
                return fl + fr;
            }

            throw new Exception("Values can not be added together");
        }
        private object Minus(object? left, object? right)
        {
            if (left is int l && right is int r)
            {
                return l - r;
            }
            else if (left is float fl && right is float fr)
            {
                return fl - fr;
            }

            throw new Exception("Values can not be subtracted together");
        }


    }



}
