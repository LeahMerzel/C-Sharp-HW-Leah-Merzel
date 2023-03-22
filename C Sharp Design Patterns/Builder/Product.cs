using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Design_Patterns.Builder
{
    public class Product
    {
        private List<string> _parts = new List<string>();
        public void Add(string part)
        { 
            _parts.Add(part); 
        }
        public void Show()
        {
            Console.WriteLine("\nProduct Parts -------");
            _parts.ForEach(x => Console.WriteLine(x));
        }
    }
}
