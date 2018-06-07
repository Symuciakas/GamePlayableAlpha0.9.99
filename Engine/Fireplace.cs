using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Fireplace
    {
        public int ID { get; set; }
        public int LocationMap { get; set; }
        public int LocationXY { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public Fireplace(int id, int locationmap, int locationxy, string image1, string image2)
        {
            ID = id;
            LocationMap = locationmap;
            LocationXY = locationxy;
            Image1 = image1;
            Image2 = image2;
        }
    }
}
