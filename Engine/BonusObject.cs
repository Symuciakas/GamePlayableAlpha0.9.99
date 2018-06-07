using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class RandomObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageAdress { get; set; }
        public RandomObject(int id, string name, string imageadress)
        {
            ID = id;
            Name = name;
            ImageAdress = imageadress;
        }
    }
}
