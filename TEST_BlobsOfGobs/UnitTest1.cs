using Xunit;
using API_BlobsOfGobs;

namespace TEST_BlobsofGobs
{
    public class APITests
    {
        [Fact]
        public void Orders_SetAndGetProperties_Success()
        {
            
            var order = new Orders();

            
            order.OrderID = "12345";
            order.CustomerID = "67890";
            order.IsPaid = true;

            
            Assert.Equal("12345", order.OrderID);
            Assert.Equal("67890", order.CustomerID);
            Assert.True(order.IsPaid);
        }

        [Fact]
        public void GobFlavors_SetAndGetProperties_Success()
        {
            
            var gobFlavor = new GobFlavors();

           
            gobFlavor.FlavorID = "flavor123";
            gobFlavor.FlavorName = "Chocolate";

            
            Assert.Equal("flavor123", gobFlavor.FlavorID);
            Assert.Equal("Chocolate", gobFlavor.FlavorName);
        }

        [Fact]
        public void Customers_SetAndGetProperties_Success()
        {
            
            var customer = new Customers();

            
            customer.CustomerID = "12345";
            customer.Fname = "John";
            customer.Lname = "Doe";

            
            Assert.Equal("12345", customer.CustomerID);
            Assert.Equal("John", customer.Fname);
            Assert.Equal("Doe", customer.Lname);
        }

        [Fact]
        public void OrderGob_SetAndGetProperties_Success()
        {
            
            var orderGob = new OrderGob();

            
            orderGob.OrderGobID = "12345";
            orderGob.FlavorID = "flavor123";
            orderGob.Quantity = 5;
            orderGob.OrderID = "67890";

            
            Assert.Equal("12345", orderGob.OrderGobID);
            Assert.Equal("flavor123", orderGob.FlavorID);
            Assert.Equal(5, orderGob.Quantity);
            Assert.Equal("67890", orderGob.OrderID);
        }
    }
}