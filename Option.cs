using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Option
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Option(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
