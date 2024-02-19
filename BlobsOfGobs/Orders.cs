using System.ComponentModel.DataAnnotations;

namespace API_BlobsOfGobs
{
    /**
     * IAN: an order should contain a guid, list of gobs bought, name, bool tracking whether the order is paid for
     * 
     * 
     **/
    public class Orders
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
            get { return id; }
            set { id = value; }
        }

        private List<Gob> _orders = new List<Gob>();
        public List<Gob> _Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        private bool isPaidFor = false;
        public bool IsPaidFor
        {
            get { return isPaidFor; }
            set { isPaidFor = value; }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
