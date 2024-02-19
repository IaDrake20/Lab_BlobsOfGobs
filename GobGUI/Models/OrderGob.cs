using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GobGUI.Models
{
    internal class OrderGob
    {
        private Guid customerid;
        private Guid flavorid;
        private Guid ordergobid;

        public Guid OrderGobID
        {
            get { return ordergobid; }
            set { ordergobid = value; }
        }

        public Guid FlavorID
        {

            get { return flavorid; }
            set { flavorid = value; }
        }

        public Guid CustomerID
        {

            get { return customerid; }
            set { customerid = value; }
        }
    
    }
}
