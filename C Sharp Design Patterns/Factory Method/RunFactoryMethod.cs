using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Design_Patterns.Factory_Method
{
    public class RunFactoryMethod
    {
        public static void RunFactory()
        {
            Document[] documents = new Document[2];
            documents[0] = new Resume();
            documents[1] = new Report();

            foreach (Document document in documents) 
            {
                Console.WriteLine("\n" + document.GetType().Name +"--");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }

            Console.ReadKey();
        }
    }
}
