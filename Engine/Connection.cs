using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Connection
    {
        public int Map1 { get; set; }
        public int Map2 { get; set; }
        public int Terrain1 { get; set; }
        public int Terrain2 { get; set; }
        public int LevelRequirement { get; set; }
        public int ItemRequirement { get; set; }
        public Connection(int m1, int m2, int t1, int t2, int level, int item)
        {
            Map1 = m1;
            Map2 = m2;
            Terrain1 = t1;
            Terrain2 = t2;
            LevelRequirement = level;
            ItemRequirement = item;
        }
    }
}
