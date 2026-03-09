using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH_Visualizer_v2.Modal
{
    public class DHParameter
    {
        public double Theta { get; set; }
        public double LinkOffset { get; set; }
        public double LinkLength { get; set; }
        public double Alpha { get; set; }

        public jointType Jointype { get; set; }


}

    public enum jointType
    {
        R,
        P
    }
}
