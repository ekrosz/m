using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika_2
{
    public class SystemLinkedList : List<Person>
    {
        public void Display()
        {
            if (Count == 0)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("List is empty");
                Console.WriteLine("-------------------------------------");
                return;
            }

            foreach (var person in this)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}\n");
                Console.WriteLine("-------------------------------------");
            }
        }
    }
}
