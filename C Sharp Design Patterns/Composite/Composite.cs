using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Design_Patterns.Composite
{
    public class Composite : Component
    {
        List<Component> children = new List<Component>();
        public Composite(string name) : base(name)
        {
        }
        public override void Add(Component component)
        {
            children.Add(component);
        }
        public override void Remove(Component component)
        {
            children.Remove(component);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) +name);
            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }

    }
}
