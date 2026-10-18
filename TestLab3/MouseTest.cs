using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net_lab3.Classes;
namespace TestLab3
{
    [TestClass]
    public class MouseTest
    {
        [TestMethod]
        public void TestMouseCreation()
        {
            var mouse = new Mouse("Test Mouse", 49.99, ConnectionType.USB, 5);
            Assert.AreEqual("Test Mouse", mouse.Name);
            Assert.AreEqual(49.99, mouse.Price);
            Assert.AreEqual(ConnectionType.USB, mouse.ConnectionType);
            Assert.AreEqual(5, mouse.NumberOfButtons);
        }

        [TestMethod]
        public void TestMouseConnection()
        {
            var mouse = new Mouse("Test Mouse", 49.99, ConnectionType.USB, 5);
            Assert.IsFalse(mouse.Connected);
            mouse.Connect();
            Assert.IsTrue(mouse.Connected);
            mouse.Disconnect();
            Assert.IsFalse(mouse.Connected);
        }

        [TestMethod]
        public void TestMouseClicksSpeed()
        {
            var mouse = new Mouse("Test Mouse", 49.99, ConnectionType.USB, 5);
            int clicksSpeed = mouse.GetClicksSpeed();
            Assert.AreEqual(50, clicksSpeed);
        }
    }
}
