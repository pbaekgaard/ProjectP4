using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP4
{
    public class Visitors : GrammarBaseVisitor<object?>
    {
        public Dictionary<string, object?> Variables { get; set; } = new();
        public override object? VisitAssignment([NotNull] GrammarParser.AssignmentContext context)
        {
            var name = context.VAR().GetText();

            var value = Visit(context.expression());

            return null;
        }

        public override object? VisitConstant([NotNull] GrammarParser.ConstantContext context)
        {
            if (context.INTEGER() != null)
            {
                return int.Parse(context.INTEGER().GetText());
            }

            return null;
        }





    }



}
