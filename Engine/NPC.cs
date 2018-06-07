using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class NPC
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageAdress { get; set; }
        public string Monologue { get; set; }
        public int OfferedQuest { get; set; }
        public string MonologueAfterQuest1 { get; set; }
        public string MonologueAfterQuest { get; set; }
        public int LocationMap { get; set; }
        public int LocationXY { get; set; }
        public NPC(int id, string name, string imageadress, string monologue, int offeredquest, string monologueafterquest1, string monologueafterquest, int locationmap, int locationxy)
        {
            ImageAdress = imageadress;
            ID = id;
            Name = name;
            Monologue = monologue;
            OfferedQuest = offeredquest;
            MonologueAfterQuest1 = monologueafterquest1;
            MonologueAfterQuest = monologueafterquest;
            LocationXY = locationxy;
            LocationMap = locationmap;
        }
    }
}
