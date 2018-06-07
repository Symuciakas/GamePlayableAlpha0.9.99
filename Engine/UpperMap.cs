using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class UpperMap
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int[,] TerrainID = new int[14, 7];
        public UpperMap(int id, string name, int[,] terrainid)
        {
            ID = id;
            Name = name;
            TerrainID = terrainid;
        }
    }
}
