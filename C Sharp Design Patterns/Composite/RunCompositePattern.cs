using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Design_Patterns.Composite
{
    public class RunCompositePattern
    {
        public static void Run() 
        {
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            root.Display(1);

            Composite fileExplorer = new Composite("fileExplorer");
            fileExplorer.Add(new Folder("Folder A"));
            fileExplorer.Add(new Folder("Folder B"));

            ChildFile file = new ChildFile("fiel in no folder");
            fileExplorer.Add(file);

            Composite folder = new Composite("Folder with files");
            folder.Add(new ChildFile("file A"));
            folder.Add(new ChildFile("file B"));

            fileExplorer.Add(folder);
            fileExplorer.Display(1);

            Console.ReadKey();


        }
    }
}
