using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;

namespace ProjectP4
{
    public class CodeGenerator
    {
        public string Code { get; set; }

        public CodeGenerator()
        {
            Code = string.Empty;
        }

        public void startSub(string sourceName)
        {
            //Sub procedures cannot contain "."
            sourceName = sourceName.Trim('.');
            if (sourceName.Contains("."))
            {
                int pos = sourceName.IndexOf(".");
                sourceName = sourceName.Remove(pos, 1);
            }

            this.Code += string.Format("Sub {0} ()\n", sourceName);
        }

        public void endSub()
        {
            this.Code += string.Format("End Sub\n");
        }

        public void DeclareVariable(string name, dynamic value)
        {
            if (value is int i)
            {
                this.Code += string.Format("Dim {0} As Double\n", name);
                this.Code += string.Format("{0} = ", name);
            }
            else if (value is bool b)
            {
                this.Code += string.Format("Dim {0} As Boolean\n", name);
                this.Code += string.Format("{0} = ", name);
            }
            else if (value is string s)
            {
                this.Code += string.Format("Dim {0} As String\n", name);
                this.Code += string.Format("{0} = ", name);
            }
        }

        public void SetCell(string variable)
        {
            this.Code += string.Format("Range(\"{0}\").Value = ", variable);
        }

        public void AssignVariable(string name)
        {
            this.Code += string.Format("{0} = ", name);
        }

        public void AssignValue(dynamic value)
        {
            if (value is int)
            {
                this.Code += string.Format("{0}.0\n", value);
            }
            else
                this.Code += string.Format("{0}\n", value);
        }
        public void startIf()
        {
            this.Code += string.Format("If ");
        }

        public void thenIf()
        {
            this.Code += string.Format("Then\n");
        }

        public void conditional(dynamic cond)
        {
            if (cond is GrammarParser.ConditionalexpressionContext)
            {
                if (cond.ChildCount == 1 || cond.ChildCount == 0)
                {
                    this.Code += string.Format("{0} ", cond.GetText());
                }
            }
            else
                this.Code += string.Format("{0} ", cond.Text);
        }

        public void elseStatement()
        {
            this.Code += string.Format("Else\n");
        }

        public void endIf()
        {
            this.Code += string.Format("End If\n");
        }

        public void OperatorExp(GrammarParser.ExpressionContext leftv, GrammarParser.ExpressionContext rightv, string op)
        {
            if (leftv.GetType().Name == "VarexpressionContext")
            {
                this.Code += string.Format("Range(\"{0}\").Value ", leftv.GetText());
            }
            else
            {
                this.Code += string.Format("{0} ", leftv.GetText());
            }

            this.Code += string.Format("{0} ", op);

            if (rightv.GetType().Name == "VarexpressionContext")
            {
                this.Code += string.Format("Range(\"{0}\").Value\n", rightv.GetText());
            }
            else
            {
                this.Code += string.Format("{0}\n", rightv.GetText());
            }
        }

        public void While(dynamic compare, dynamic context)
        {
            string condition = "";
            List<string> conditions = new();
            GetChildrenFromConditional(compare, conditions);
            foreach (string cond in conditions)
            {
                condition += string.Format("{0} ", cond);
            }
            this.Code += string.Format("Do while {0}\n", condition);

            foreach (dynamic decl in context.declaration())
            {
                this.Code += string.Format("{0}\n", context.Start.InputStream.GetText(Interval.Of(decl.Start.StartIndex, decl.Stop.StopIndex)));
            }
            this.Code += string.Format("Loop\n");
        }

        public void sum(string start, string end)
        {

            this.Code += string.Format("WorksheetFunction.Sum(Range(\"{0}:{1}\"))\n", start, end);
        }

        public void average(dynamic start, dynamic end)
        {
            this.Code += string.Format("WorksheetFunction.AVERAGE(Range(\"{0}:{1}\"))\n", start, end);
        }


        public void GetChildrenFromConditional(IParseTree child, List<string> childlist)
        {
            if (child.ChildCount == 1)
            {
                childlist.Add(child.GetChild(0).GetText());
            }
            else if (child.ChildCount == 0)
            {
                if (child.GetText() == "AND")
                {
                    childlist.Add("And");
                }
                else if (child.GetText() == "OR")
                {
                    childlist.Add("Or");
                }
                else if (child.GetText() == "!=")
                {
                    childlist.Add("<>");
                }
                else if (child.GetText() == "==")
                {
                    childlist.Add("=");
                }
                else
                {
                    childlist.Add(child.GetText());
                }
            }
            else
            {
                for (int i = 0; i < child.ChildCount; i++)
                {
                    GetChildrenFromConditional(child.GetChild(i), childlist);
                }
            }
        }

        public void MaxFunction(string first, string last)
        {
            this.Code += string.Format("WorksheetFunction.Max(Range(\"{0}:{1}\"))\n", first, last);
        }
        public void MinFunction(string first, string last)
        {
            this.Code += string.Format("WorksheetFunction.Min(Range(\"{0}:{1}\"))\n", first, last);
        }

        public void SortFunction(string first, string last, string dest, string order)
        {
            string sortedDestLetter = new String(dest.Where(c => Char.IsLetter(c) && Char.IsUpper(c)).ToArray());
            int sortedDestDigit = int.Parse(new String(dest.Where(c => Char.IsDigit(c)).ToArray()));
            string sortedLastLetter = new String(last.Where(c => Char.IsLetter(c) && Char.IsUpper(c)).ToArray());
            int LastDigit = int.Parse(new String(last.Where(c => Char.IsDigit(c)).ToArray()));
            int FirstDigit = int.Parse(new String(first.Where(c => Char.IsDigit(c)).ToArray()));
            int sortedLastDigit = sortedDestDigit + LastDigit - FirstDigit;
            string sortedLast = string.Format("{0}{1}", sortedDestLetter, sortedLastDigit);

            this.Code += string.Format("Range(\"{0}:{1}\").Copy Destination:=Range(\"{2}\")\n", first, last, dest);
            if (order == "true")
            {
                this.Code += string.Format("Range(\"{0}:{1}\").Sort Key1:=Range(\"{0}\"), Order1:=xlAscending, Header:=xlNo\n", dest, sortedLast);
            }
            else if (order == "false")
            {
                this.Code += string.Format("Range(\"{0}:{1}\").Sort Key1:=Range(\"{0}\"), Order1:=xlDescending, Header:=xlNo", dest, sortedLast);
            }
        }

        public void Count(string first, string last)
        {
            this.Code += string.Format("WorksheetFunction.Count(Range(\"{0}:{1}\"))\n", first, last);
        }

        public void Count(string first, string last, int specific)
        {
            this.Code += string.Format("WorksheetFunction.CountIf(Range(\"{0}:{1}\"), {2})\n", first, last, specific);
        }
    }
}
