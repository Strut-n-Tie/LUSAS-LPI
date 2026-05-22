using Lusas.LPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace truss_generator
{
    public class Processor
    {
        private IFModeller m_modeller;

        public Processor(IFModeller modeller)
        {
            m_modeller = modeller;
        }

        public void contructTruss(DataContainer dataContainer)
        {

        }
    }
}
