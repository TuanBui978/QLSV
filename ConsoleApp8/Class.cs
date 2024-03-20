using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    [Serializable]
    public class Class
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }

        public Class() { }
        public Class(int id, string name, string faculty)
        {
            Id = id;
            Name = name;
            Faculty = faculty;
        }

    }
}
