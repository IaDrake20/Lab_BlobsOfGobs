using System.Reflection.Metadata.Ecma335;

namespace BlobsOfGobs
{
    public class Gob
    {
        private string name = 0;
        public string Name
        {
            get { return this.name; }
            set { this.name = value;}
        }

        private int numberBought = 0;
        public int NumberBought
        {
            get { return this.numberBought; }
            set { this.numberBought = value; }
        }
    }
}
