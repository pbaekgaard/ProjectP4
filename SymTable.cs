using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP4
{
    public class SymTable
    {
        public enum symbolType
        {
            Number,
            Text,
            Bool
        }

        public Dictionary<string, symbolType> SymbolTable;

        public SymTable()
        {
            SymbolTable = new Dictionary<string, symbolType>();
        }
        
        public bool addSymbol(symbolType type,string name) 
        {
            if (SymbolTable.ContainsKey(name))
            {
                return false;
            }
            else
            {
                this.SymbolTable.Add(name, type);
                return true;
            }
        }

        public symbolType? getSymbol(string name)
        {
            if (SymbolTable.ContainsKey(name))
            {
                return SymbolTable[name];
            } else
            {
                return null;
            }
        }

    }
}

