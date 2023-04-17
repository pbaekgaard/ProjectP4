using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectP4
{
    public class Symbol
    {
        public enum symbolType
        {
            text,
            number,
            @bool
        }
        public symbolType type { get; set; }
        public dynamic value { get; set; }

    }
    public class SymTable
    {
        
        public int scope { get; set; }
        public List<Dictionary<string, Symbol>> scopedSymbolTable { get; set; }
        

        public SymTable()
        {
            this.scope = 0;
            this.scopedSymbolTable = new();
            this.scopedSymbolTable.Insert(this.scope,new Dictionary<string, Symbol> { });
        }
        public void openScope()
        {
            this.scopedSymbolTable.Insert(this.scope, new Dictionary<string, Symbol> { });
        }

        public void closeScope()
        {
            if (this.scopedSymbolTable.Count == 1)
            {
                throw new Exception("Can't remove global scope");
            } else
            {
                this.scopedSymbolTable.RemoveAt(this.scope);
            }
        }

        public void addSymbol(string name, Symbol type)
        {
            if (this.scopedSymbolTable[this.scope].ContainsKey(name))
            {
                throw new Exception(string.Format("symbol {0} already exists in the table", name));
            } 
            else
            {
                this.scopedSymbolTable[this.scope].Add(name, type);
            }
        }

        public Symbol getSymbol(string name)
        {
            foreach (var item in this.scopedSymbolTable)
            {
                if (item.ContainsKey(name))
                {
                    Symbol value;
                    item.TryGetValue(name,out value);
                    return value;
                }
            }
            throw new Exception(String.Format("{0} does not exist", name));
        }

        public void updateSymbol(string name, Symbol type)
        {
            foreach (var item in this.scopedSymbolTable)
            {
                if (item.ContainsKey(name))
                {
                    item[name] = type;
                }
            }
            throw new Exception(String.Format("{0} does not exist", name));
        }

    }
}

