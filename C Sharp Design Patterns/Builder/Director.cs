using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Design_Patterns.Builder
{
    public class Director
    {
        public void Cunstruct(Builder builder) 
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }
}
