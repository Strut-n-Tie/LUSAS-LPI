using Lusas.LPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truss_generator
{
    public class DataContainer
    {
        public double L { get; set; }
        public double H { get; set; }
        public int n { get; set; }
        public string material_attribute_name { get; set; }
        public string mesh_attribte_name { get; set; }
        public string geometric_attribte_top_chord_name { get; set; }
        public string geometric_attribte_bottom_chord_name { get; set; }
        public string geometric_attribte_diagonal_name { get; set; }

    }
}
