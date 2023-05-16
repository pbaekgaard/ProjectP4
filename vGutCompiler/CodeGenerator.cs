using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public void AssignVariable(string name)
        {
            this.Code += string.Format("Range(\"{0}\").Value = ", name);
        }

        public void UpdateVariable(string name)
        {
            this.Code += string.Format("Range(\"{0}\").Value = ", name);
        }

        public void Value(dynamic value)
        {
            if (value.GetType() != typeof(string) && value % 1 == 0)
            {
                this.Code += string.Format("{0}.0 ", value);
            }
            else if (value is int || value is float || value is double)
            {
                this.Code += string.Format("{0} ", value.ToString(CultureInfo.InvariantCulture));
            } else
            {
                this.Code += string.Format("{0} ", value);
            }
        }

        public void Variable(string name)
        {
            this.Code += string.Format("Range(\"{0}\").Value ", name);
        }
        public void WhilestmtStart()
        {
            this.Code += string.Format("While ");
        }
        public void WhilestmtEnd()
        {
            this.Code += string.Format("Wend\n");
        }

        public void IfStart()
        {
            this.Code += string.Format("If ");
        }
        public void IfThen()
        {
            this.Code += string.Format("Then\n");
        }
        public void elseStatement()
        {
            this.Code += string.Format("Else\n");
        }
        public void endIf()
        {
            this.Code += string.Format("End If\n");
        }
        public void NewLine()
        {
            this.Code += string.Format("\n");
        }
        public void sum(string start, string end)
        {
            this.Code += string.Format("WorksheetFunction.Sum(Range(\"{0}:{1}\"))", start, end);
        }
        public void average(dynamic start, dynamic end)
        {
            this.Code += string.Format("WorksheetFunction.AVERAGE(Range(\"{0}:{1}\"))", start, end);
        }
        public void MaxFunction(string start, string end)
        {
            this.Code += string.Format("WorksheetFunction.Max(Range(\"{0}:{1}\"))", start, end);
        }
        public void MinFunction(string start, string end)
        {
            this.Code += string.Format("WorksheetFunction.Min(Range(\"{0}:{1}\"))", start, end);
        }
        public void Count(string first, string last)
        {
            this.Code += string.Format("WorksheetFunction.Count(Range(\"{0}:{1}\"))", first, last);
        }
        public void Count(string first, string last, int specific)
        {
            this.Code += string.Format("WorksheetFunction.CountIf(Range(\"{0}:{1}\"), {2})", first, last, specific);
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
        public void VLookUpFunction(dynamic search, string start, string end, int column_index, bool aprox_match = false)
        {
            if (search is string)
                this.Code += string.Format("WorksheetFunction.VLOOKUP(\"{0}\", Range(\"{1}:{2}\"), {3}, {4})", search, start, end, column_index, aprox_match);
            else
                this.Code += string.Format("WorksheetFunction.VLOOKUP({0}, Range(\"{1}:{2}\"), {3}, {4})", search, start, end, column_index, aprox_match);
        }

    }
}
