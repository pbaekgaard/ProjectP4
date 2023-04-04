using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP4
{
    public enum symbolType
    {
        Number,
        Text,
        Bool
    }
    public class Symbol
    {
        public string Name { get; set; }
        public symbolType Type { get; set; }

    }
    public class SymTable : GrammarBaseVisitor<IDictionary<string, Symbol>>  
    {
        public Dictionary<string, symbolType> table;
        private int depthCounter = 0;
        public void openScope (){
            depthCounter++;
        }
        public void closeScope()
        {
            depthCounter--;
        }
        public void enterSymbol(Symbol symbol)
        {
            table.Add(symbol.Name, symbol.Type);
        }
        public void retrieveSymbol(string name)
        {
            try
            {
                symbolType val = table[name];
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void declaredLocally(string name) 
        { 
        }
        
    }
}

