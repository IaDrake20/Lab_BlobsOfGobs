using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace API_BlobsOfGobs
{
    public class Gob
    {
        //IAN: I added this to set up the controller, for the future I'm not sure if every single gob needs a GUID
        private Guid id = Guid.NewGuid();

        [Key]
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int numberBought = 0;

        public int NumberBought
        {
            get { return numberBought; }
            set { numberBought = value; }
        }
    }
}
