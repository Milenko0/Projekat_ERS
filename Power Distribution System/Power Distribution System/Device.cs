using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Distribution_System
{
    internal class Device
    {
        private string name;
        private int powerDraw;

        public Device(){ }

        public Device(string name, int powerDraw)
        {
            Name = name;
            PowerDraw = powerDraw;
        }

        public string Name
        {
            get
            { return name;}
            set
            { if (value != name) { name = value;} }
        }

        public int PowerDraw
        {
            get { return powerDraw; }
            set { powerDraw = value; }
        }

    }
}
