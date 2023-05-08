using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
            else if (value is float f)
            {
                this.Code += string.Format("Dim {0} As Double\n", name);
                this.Code += string.Format("{0} = {1}\n", name, f);
            }
            else if (value is bool b)
            {
                this.Code += string.Format("Dim {0} As Boolean\n", name);
                this.Code += string.Format("{0} = {1}\n", name, b);
            }
            else if (value is string s)
            {
                this.Code += string.Format("Dim {0} As String\n", name);
                this.Code += string.Format("{0} = {1}\n", name, s);
            }
        }

        public void AssignVariable(string name, dynamic value) {
            if (value is int i)
            {
                this.Code += string.Format("{0} = {1}.0\n", name, i);
            }
            else if (value is float f)
            {
                this.Code += string.Format("{0} = {1}\n", name, f);
            }
            else if (value is bool b)
            {
                this.Code += string.Format("{0} = {1}\n", name, b);
            }
            else if (value is string s)
            {
                this.Code += string.Format("{0} = {1}\n", name, s);
            }
        }

        public void startIf(dynamic compare) {
          this.Code += string.Format("If {0} {1} {2} Then\n", compare.Item1, compare.Item2, compare.Item3);
        }

        public void elseStatement() {
          this.Code += string.Format("Else\n");
        }

        public void endIf() {
          this.Code += string.Format("End If");
        }

        public void average(dynamic start, dynamic end) {
            this.Code += string.Format("Application.WorksheetFunction.Average(Range(\"{0}:{1}\"))\n", start, end);
        }
    }
}
