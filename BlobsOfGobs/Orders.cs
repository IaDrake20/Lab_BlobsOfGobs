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
        private string id = "";

        [Key]
        public string OrderID
        {
            get { return id; }
            set { id = value; }
        }

        private string c_id = "";

        public string CustomerID
        {
            get { return c_id; }
            set { c_id = value; }
        }

        private bool isPaid = false;
        public bool IsPaid
        {
            get { return isPaid; }
            set { isPaid = value; }
        }
    }
}
