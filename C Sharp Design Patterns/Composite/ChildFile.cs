using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Design_Patterns.Composite
{
    public class ChildFile : Component
    {
        public ChildFile(string name) : base(name)
        {
        }

        public override void Add(Component file)
        {
        }
        public override void Remove(Component c)
        {
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }

    }
}
