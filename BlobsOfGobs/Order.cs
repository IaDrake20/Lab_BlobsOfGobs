namespace BlobsOfGobs
{
    /**
     * IAN: an order should contain a guid, list of gobs bought, bool tracking whether the order is paid for
     * 
     * 
     **/
    public class Order
    {
        //IAN: Order ID
        private Guid id = Guid.NewGuid();
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        private List<Gob> orders = new List<Gob>();
        public List<Gob> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        private bool isPaidFor = false;
        public bool IsPaidFor
        {
            get { return isPaidFor; }
            set { isPaidFor = value; }
        }
    }
}
