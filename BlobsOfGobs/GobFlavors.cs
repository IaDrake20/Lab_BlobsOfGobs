using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace API_BlobsOfGobs
{
    public class GobFlavors
    {
        //IAN: I added this to set up the controller, for the future I'm not sure if every single gob needs a String
        private String id = "";

        [Key]
        public String FlavorID
        {
            get { return id; }
            set { id = value; }
        }

        private string name = "";
        public string FlavorName
        {
            get { return name; }
            set { name = value; }
        }
    }
}
