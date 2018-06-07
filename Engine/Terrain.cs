using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Terrain
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageAdress { get; set; }
        public bool Walkable { get; set; }
        public Terrain(int id, string name, string imageAdress, bool walkable)
        {
            ImageAdress = imageAdress;
            ID = id;
            Name = name;
            Walkable = walkable;
        }
    }
}
