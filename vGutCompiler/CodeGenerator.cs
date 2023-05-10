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

        public void SetCell(string variable) {
          this.Code += string.Format("Range(\"{0}\").Value = ", variable);
        }

        public void AssignVariable(string name)
        {
                this.Code += string.Format("{0} = ", name);
        }

        public void AssignValue(dynamic value) {
          if (value is int) {
            this.Code+= string.Format("{0}.0\n", value);
          } else
          this.Code += string.Format("{0}\n", value);
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

        public void OperatorExp(GrammarParser.ExpressionContext leftv, GrammarParser.ExpressionContext rightv, string op)
        {
            if (leftv.GetType().Name == "VarexpressionContext")
            {
                this.Code += string.Format("Range(\"{0}\").Value ",leftv.GetText());
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

        public void sum(string start, string end)
        {

            this.Code += string.Format("Application.WorksheetFunction.Sum(Range(\"{0}:{1}\"))\n", start, end);
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

        public void MaxFunction(string first, string last){
          this.Code += string.Format("WorksheetFunction.Max(Range(\"{0}:{1}\"))\n",first,last);
        }
    }
}
