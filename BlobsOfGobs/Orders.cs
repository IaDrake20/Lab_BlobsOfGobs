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
