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

        public void DeclareVariable(string name, dynamic value)
        {
            if (value is int i)
            {
                this.Code += string.Format("Dim {0} As Double\n", name);
                this.Code += string.Format("{0} = {1}.0\n", name, i);
                this.Code += string.Format("Range(\"{0}\").Value = {1}\n", name, i);
            }
            else if (value is float f)
            {
                this.Code += string.Format("Dim {0} As Double\n", name);
                this.Code += string.Format("{0} = {1}\n", name, f);
                this.Code += string.Format("Range(\"{0}\").Value = {1}\n", name, f);
            }
            else if (value is bool b)
            {
                this.Code += string.Format("Dim {0} As Boolean\n", name);
                this.Code += string.Format("{0} = {1}\n", name, b);
                this.Code += string.Format("Range(\"{0}\").Value = {1}\n", name, b);
            }
            else if (value is string s)
            {
                this.Code += string.Format("Dim {0} As String\n", name);
                this.Code += string.Format("{0} = {1}\n", name, s);
                this.Code += string.Format("Range(\"{0}\").Value = {1}\n", name, s);
            }
        }

        public void AssignVariable(string name, dynamic value)
        {
            if (value is int i)
            {
                this.Code += string.Format("{0} = {1}.0\n", name, i);
                this.Code += string.Format("Range(\"{0}\").Value = {1}\n", name, i);
            }
            else 
            {
                this.Code += string.Format("{0} = {1}\n", name, value);
                this.Code += string.Format("Range(\"{0}\").Value = {1}\n", name,value);
            }
        }

        public void startIf(GrammarParser.ConditionalexpressionContext compare)
        {
            string condition = "";
            List<IParseTree> conditions = new();
            GetChildrenFromConditional(compare, conditions);
            foreach (IParseTree cond in conditions)
            {
                if (cond.GetText() == "AND")
                {
                    condition += string.Format("And ");
                }
                else
                    condition += string.Format("{0} ", cond.GetText());
            }
            this.Code += string.Format("If {0}Then\n", condition);
        }

        public void elseStatement()
        {
            this.Code += string.Format("Else\n");
        }

        public void endIf()
        {
            this.Code += string.Format("End If");
        }

        public void sum(string start, string end)
        {
            this.Code += string.Format("Application.WorksheetFunction.SUM(\"{0}:{1}\")\n", start, end);
        } 
     
        public void average(dynamic start, dynamic end) {
            this.Code += string.Format("Application.WorksheetFunction.AVERAGE(Range(\"{0}:{1}\"))\n", start, end);
        }
        //Bare et eksempel
        public void While(dynamic compare, dynamic context)
        {
            this.Code += string.Format("Do while {0}\n",compare);

            foreach (dynamic decl in context.declaration())
            {
                this.Code += string.Format("{0}\n", context.Start.InputStream.GetText(Interval.Of(decl.Start.StartIndex, decl.Stop.StopIndex)));
            }

            this.Code += string.Format("Loop\n");
        }

        public void GetChildrenFromConditional(IParseTree child, List<IParseTree> childlist)
        {
            if (child.ChildCount == 1)
            {
                childlist.Add(child.GetChild(0));
            }
            else if (child.ChildCount == 0)
            {
                childlist.Add(child);
            }
            else
            {
                for (int i = 0; i < child.ChildCount; i++)
                {
                    GetChildrenFromConditional(child.GetChild(i), childlist);
                }
            }
        }
    }
}
