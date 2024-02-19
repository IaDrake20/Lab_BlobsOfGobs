using System.Drawing.Printing;

namespace API_BlobsOfGobs
{
    public class OrderGob
    {
        private Guid customerid;
        private Guid flavorid;
        private Guid ordergobid;
        private int number;

        public Guid OrderGobID
        {
            get { return ordergobid; }
            set { ordergobid = value; }
        }

        public Guid FlavorID { 

            get { return flavorid; }
            set { flavorid = value; }
        }

        public Guid CustomerID {

            get { return customerid; } 
            set {  customerid = value; } 
        }

        public int Quantity
        {
            get { return number; }
            set { number = value; }
        }

        

    }
}
