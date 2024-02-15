using System.Reflection.Metadata.Ecma335;

namespace BlobsOfGobs.Models
{
    public class Gob
    {
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
