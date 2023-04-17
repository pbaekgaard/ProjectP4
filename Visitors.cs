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
        public override object? VisitAssignment([NotNull] GrammarParser.AssignmentContext context)
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


            switch (operatorValue)
            {
                case "+": return leftValue + rightValue;
                case "-": return leftValue - rightValue;
                case "*": return leftValue * rightValue;
                case "/": return leftValue / rightValue;
                case "<": return leftValue < rightValue;
                case ">": return leftValue > rightValue;
                case "<=": return leftValue <= rightValue;
                case "AND": return leftValue && rightValue;
                case "OR": return leftValue || rightValue;
                case ">=": return leftValue <= rightValue;
                case "%": return leftValue % rightValue;
                case "==": return leftValue == rightValue;

                default:
                    throw new Exception("Does not fungo");
                    break;
            }

            return null;
        }

        public override object VisitVarexpression([NotNull] GrammarParser.VarexpressionContext context)
        {
            var operatorValue = context.@operator().GetText();


            Symbol leftValue = symbolTable.getSymbol(context.VAR(0).GetText());
            Symbol rightValue = symbolTable.getSymbol(context.VAR(1).GetText());

            Console.WriteLine(leftValue.type);
            Console.WriteLine(rightValue.type);

            switch(leftValue.type,rightValue.type)
            {
                case (symbolType.number, symbolType.number):
                    
                    break;
            }

            return null;
        }

        public override object VisitIfstmt([NotNull] GrammarParser.IfstmtContext context)
        {
            Console.WriteLine(context.expression().GetText());
            return null;
        }


    }

}
