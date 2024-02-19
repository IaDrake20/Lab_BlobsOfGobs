using System.ComponentModel.DataAnnotations;

namespace API_BlobsOfGobs
{
    /**
     * IAN: Customer composed of a String to for referencing, name, and order(s)
     **/
    public class Customers
    {
        private String _String = "";

        [Key]
        public String CustomerID
        {
            get { return _String; }
            set { _String = value; }
        }

        private string? _fname;
        public string Fname
        {
            get { return _fname; }
            set { _fname = value; }
        }

        private string? _lname;
        public string Lname
        {
            get { return _lname; }
            set { _lname = value; }
        }
    }
}
