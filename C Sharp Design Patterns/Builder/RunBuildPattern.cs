using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Design_Patterns.Builder
{
    public class RunBuildPattern
    {
        public static void Run()
        {
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();    

            director.Cunstruct(b1);
            Product p1 = b1.GetResult();
            p1.Show();

            director.Cunstruct(b2);
            Product p2 = b2.GetResult();
            p2.Show();


        }
    }
}
