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
          this.Code += string.Format("Test");
        }
    }
}
