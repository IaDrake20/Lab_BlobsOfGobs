using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GobGUI.Models
{
    class GobFlavors
    {
        //IAN: Order ID
        private Guid id = Guid.NewGuid();

        [Key]
        public Guid OrderID
        {
            get { return id; }
            set { id = value; }
        }

        private Guid c_id = Guid.NewGuid();

        public Guid CustomerID
        {
            get { return c_id; }
            set { c_id = value; }
        }

        private List<GobFlavors> _orders = new List<GobFlavors>();
        public List<GobFlavors> _Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        private bool isPaid = false;
        public bool IsPaid
        {
            get { return isPaid; }
            set { isPaid = value; }
        }
    }
}
