using System;
using System.Collections.Generic;
using System.Text;

namespace Q50Remote.Models
{
    public class CarLocationModel
    {
        public string Id { get; set; }
        public double Cog { get; set; }
        public double Alt { get; set; }
        public double Sog { get; set; }
        public string UTC { get; set; }
        public double Altitude { get; set; }
        public DateTime Ts { get; set; }
        public double Nsat { get; set; }
        public LatLanModel Location { get; set; }
    }

    public class LatLanModel {

        public double Lat { get; set; }
        public double Lon { get; set; }
    }

}
