using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Gender
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Gender(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
