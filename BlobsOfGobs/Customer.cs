﻿namespace BlobsOfGobs
{
    /**
     * IAN: Customer composed of a guid to for referencing, name, and order(s)
     **/
    public class Customer
    {
        private Guid _guid = new Guid();
        public Guid _GUID 
        {
            get { return this._guid; }
            set { this._guid = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { this._name = value; }
        }

        //IAN: not sure to use Gob or some kind of order class
        private List<Gob> orders = new List<Gob>();
        public List<Gob> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }
    }
}
