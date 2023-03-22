using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Design_Patterns.Composite
{
    public class Folder : Component
    {
        List<Component> itemsSavedOnComputer = new List<Component>();
        public Folder(string name) : base(name)
        {
        }

        public override void Add(Component folder)
        {
            itemsSavedOnComputer.Add(folder);
            File.WriteAllText("Composte-Pattern folder creation", folder.ToString());
        }
        public override void Remove(Component folder)
        {
            itemsSavedOnComputer.Remove(folder);
            File.Delete(folder.ToString());
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth)+ name);
            foreach (Component folder in itemsSavedOnComputer)
            {
                Console.WriteLine(new string('-',depth+2));
            }
        }

    }
}
