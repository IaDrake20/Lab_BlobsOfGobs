using System.Drawing.Printing;

namespace API_BlobsOfGobs
{
    public class OrderGob
    {
        private String flavorid;
        private String ordergobid;
        private int number;

        public String OrderGobID
        {
            get { return ordergobid; }
            set { ordergobid = value; }
        }

        public String FlavorID { 

            get { return flavorid; }
            set { flavorid = value; }
        }

        public int Quantity
        {
            get { return number; }
            set { number = value; }
        }

        

    }
}
