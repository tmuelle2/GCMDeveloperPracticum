using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMDeveloperPracticum
{
    class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Dish(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
