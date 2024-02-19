using System.ComponentModel.DataAnnotations;

namespace API_BlobsOfGobs
{
    /**
     * IAN: Customer composed of a guid to for referencing, name, and order(s)
     **/
    public class Customers
    {
        private Guid _guid = new Guid();

        [Key]
        public Guid CustomerID
        {
            get { return _guid; }
            set { _guid = value; }
        }

        private string _fname;
        public string Fname
        {
            get { return _fname; }
            set { _fname = value; }
        }

        private string _lname;
        public string Lname
        {
            get { return _lname; }
            set { _lname = value; }
        }

        //IAN: not sure to use Gob or some kind of order class
        private List<GobFlavors> orders = new List<GobFlavors>();
        public List<GobFlavors> Orders
        {
            get { return orders; }
            set { orders = value; }
        }
    }
}
