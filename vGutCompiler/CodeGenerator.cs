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

        public void AssignVariable(string name, dynamic value)
        {
            if (value is int i)
            {
                this.Code += string.Format("Dim {0} As Integer\n", name);
                this.Code += string.Format("{0} = {1}\n", name, i);
            }
            else if (value is float f)
            {
                this.Code += string.Format("Dim {0} As Single\n", name);
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
    }
}
